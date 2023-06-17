using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Models;

namespace DemoPRN221.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly JobPostingServices _jobPostingServices;
        private readonly CandidateProfileServices _candidateProfileServices;
        public DeleteModel(JobPostingServices jobPostingServices, CandidateProfileServices candidateProfileServices)
        {
            _jobPostingServices = jobPostingServices;
            _candidateProfileServices = candidateProfileServices;
        }

        [BindProperty]
      public CandidateProfile CandidateProfile { get; set; }

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
            else
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }

        public IActionResult OnPost(string id)
        {
            if (id == null || _candidateProfileServices.GetAll() == null)
            {
                return NotFound();
            }
            var candidateprofile = _candidateProfileServices.getById(id);

            if (candidateprofile != null)
            {
                CandidateProfile = candidateprofile;
                _candidateProfileServices.Delete(CandidateProfile);
            }

            return RedirectToPage("./Index");
        }
    }
}
