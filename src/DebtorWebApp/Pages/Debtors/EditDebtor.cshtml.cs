
using System.Threading.Tasks;
using DebtorWebApp.Data;
using DebtorWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DebtorWebApp.Pages.Debtors
{
    public class EditDebtorModel : BaseDebtorPageModel
    {
        public Debtor Debtor { get; set; }

        public EditDebtorModel(ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Debtor = await Context.Debtors.Include("Invoices").FirstOrDefaultAsync(item => item.DebtorID == id);

            if (Debtor == null) return NotFound();

            AuthorizationResult result = await AuthorizationService.AuthorizeAsync(User, Debtor, "DebtorEditPolicy");
            if(result.Succeeded)
            {
                return Page();
            }
            return new ForbidResult();
        }

        public async Task<ActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Debtor debtorToEdit = await Context.Debtors.FirstOrDefaultAsync(item => item.DebtorID == id);


            AuthorizationResult result = await AuthorizationService.AuthorizeAsync(User, debtorToEdit, "DebtorEditPolicy");
            if (result.Succeeded)
            {
                if(await TryUpdateModelAsync<Debtor>(debtorToEdit,"",
                    debtor => debtor.FirstName, debtor => debtor.LastName, debtor => debtor.IBAN, debtor => debtor.Email))
                {
                    try
                    {
                        await Context.SaveChangesAsync();
                        return RedirectToPage("./ViewDebtor", new { id = debtorToEdit.DebtorID });
                    }
                    catch (DbUpdateException)
                    {
                        ModelState.AddModelError("", "Unable to save changes. " +
                       "Try again, and if the problem persists, " +
                       "see your system administrator.");
                    }
                }

                
            }
            return new ForbidResult();    
        }
    }
}