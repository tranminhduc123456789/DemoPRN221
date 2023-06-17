using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Models;

namespace DemoPRN221.Pages
{
    public class EditModel : PageModel
    {
        private readonly JobPostingServices _jobPostingServices;
        private readonly CandidateProfileServices _candidateProfileServices;

        public EditModel(JobPostingServices jobPostingServices, CandidateProfileServices candidateProfileServices)
        {
            _jobPostingServices = jobPostingServices;
            _candidateProfileServices = candidateProfileServices;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public IActionResult OnGet(string id)
        {
            if (id == null || _candidateProfileServices.GetAll() == null)
            {
                return NotFound();
            }

            var candidateprofile = _candidateProfileServices.GetAll().FirstOrDefault(m => m.CandidateId == id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
            ViewData["PostingId"] = new SelectList(_jobPostingServices.GetAll().ToList(), "PostingId", "PostingId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _candidateProfileServices.Update(CandidateProfile);

            return RedirectToPage("./Index");
        }

        private bool CandidateProfileExists(string id)
        {
            return _candidateProfileServices.GetAll().Any(e => e.CandidateId == id);
        }
    }
}
