
using System.Threading.Tasks;
using DebtorWebApp.Data;
using DebtorWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace DebtorWebApp.Pages.Debtors
{
    [Authorize(Roles = "Administrator")]
    public class NewDebtorModel : BasePageModel
    {   
        public Debtor Debtor { get; set; }

        public NewDebtorModel(ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public  IActionResult OnGet()
        {
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync([Bind("FirstName,LastName,Email,IBAN")]Debtor debtor)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
        
            debtor.OwnerID = UserManager.GetUserId(User);
            Context.Add(debtor);
            await Context.SaveChangesAsync();

            return RedirectToPage("./ViewDebtor", new { id = debtor.DebtorID });
        }
    }
}