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
    public class IndexModel : PageModel
    {
        private readonly Repository.Models.CandidateManagementContext _context;
        private readonly CandidateProfileServices _candidateProfileServices;
        public IndexModel(Repository.Models.CandidateManagementContext context, CandidateProfileServices candidateProfileServices)
        {
            _context = context;
            _candidateProfileServices = candidateProfileServices;
        }
        [BindProperty]
        public IList<CandidateProfile> CandidateProfile { get;set; } = default!;
        [BindProperty]
        public string SearchKey { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("email")==null)
            {
                return RedirectToPage("./Login");
            }
            if (_candidateProfileServices.GetAll() != null)
            {
                CandidateProfile = _candidateProfileServices.GetAll();
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (SearchKey==null)
            {
                return RedirectToAction("./index");
            }
            //search by Fullname
            CandidateProfile = _candidateProfileServices.GetAll().Where(p => p.Fullname.Contains(SearchKey)).ToList();
            return Page();
        }
    }
}
