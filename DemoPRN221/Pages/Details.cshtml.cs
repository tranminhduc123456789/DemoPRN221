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
    public class DetailsModel : PageModel
    {
        private readonly JobPostingServices _jobPostingServices;
        private readonly CandidateProfileServices _candidateProfileServices;
        public DetailsModel(JobPostingServices jobPostingServices, CandidateProfileServices candidateProfileServices)
        {
            _jobPostingServices = jobPostingServices;
            _candidateProfileServices = candidateProfileServices;
        }

        public CandidateProfile CandidateProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
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
    }
}
