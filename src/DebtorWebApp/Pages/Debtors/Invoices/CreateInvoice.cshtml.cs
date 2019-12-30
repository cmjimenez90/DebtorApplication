
using System.Threading.Tasks;
using DebtorWebApp.Data;
using DebtorWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DebtorWebApp.Pages.Debtors.Invoices
{
    public class CreateInvoiceModel : BasePageModel
    {
        public Invoice Invoice { get; set; }
        public CreateInvoiceModel(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Debtor existingDebtor = await Context.Debtors.FirstOrDefaultAsync(debtor => debtor.DebtorID == id);
            if (null == existingDebtor) return NotFound();
            AuthorizationResult result = await AuthorizationService.AuthorizeAsync(User, existingDebtor, "DebtorEditPolicy");
            if (!result.Succeeded) { return new ForbidResult(); }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id,[Bind("Amount,DueDate")]Invoice invoice) {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Debtor existingDebtor = await Context.Debtors.FirstOrDefaultAsync(debtor => debtor.DebtorID == id);
            if (null == existingDebtor) return NotFound();      
            AuthorizationResult result = await AuthorizationService.AuthorizeAsync(User, existingDebtor, "DebtorEditPolicy");
            if (!result.Succeeded) { return new ForbidResult(); }

            invoice.DebtorID = existingDebtor.DebtorID;
            invoice.Status = InvoiceStatus.Open;

            Context.Invocies.Add(invoice);
            await Context.SaveChangesAsync();
            return RedirectToPage("/Debtors/ViewDebtor", new { id });
        }
    }
}