using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;
using Repository.Models;

namespace DemoPRN221.Pages
{
    public class CreateModel : PageModel
    {
        private readonly JobPostingServices _jobPostingServices;
        private readonly CandidateProfileServices _candidateProfileServices;
        public CreateModel( JobPostingServices jobPostingServices, CandidateProfileServices candidateProfileServices)
        {
            _jobPostingServices = jobPostingServices;
            _candidateProfileServices = candidateProfileServices;
        }

        public IActionResult OnGet()
        {
            ViewData["PostingId"] = new SelectList(_jobPostingServices.GetAll().ToList(), "PostingId", "PostingId");

            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _candidateProfileServices.Add(CandidateProfile);

            return RedirectToPage("./Index");
        }
    }
}
