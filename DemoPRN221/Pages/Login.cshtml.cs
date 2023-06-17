using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using Repository.Models;
using System.Drawing.Printing;

namespace DemoPRN221.Pages
{
    public class LoginModel : PageModel
    {
        public readonly HraccountServices _hraccountServices;
        public LoginModel(HraccountServices hraccountServices)
        {
            _hraccountServices= hraccountServices;
        }
        [BindProperty]
        public Hraccount Account { get; set; } = default!;
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var account = _hraccountServices.GetAll().FirstOrDefault(p => p.Email.Equals(Account.Email) && p.Password.Equals(Account.Password) && p.MemberRole.Value == 1);
            if (account == null)
            {
                ViewData["Message"] = "You not have permission";
                return Page();
            }
            HttpContext.Session.SetString("email",account.Email);
            return RedirectToPage("./Index");
        }
    }
}
