using System.Linq;
using System.Threading.Tasks;
using DebtorWebApp.Data;
using DebtorWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DebtorWebApp.Pages.Debtors.Invoices
{
    public class ViewInvoiceModel : BasePageModel
    {
        public Invoice Invoice { get; set; }
        public string InvoiceOwnerName { get; set; }
        public ViewInvoiceModel(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet(int id)
        {
           Invoice = Context.Invocies.FirstOrDefault(invoice => invoice.InvoiceId == id);
           if(Invoice == null)
            {
                return NotFound();
            }
            Debtor owner = Context.Debtors.FirstOrDefault(debtor => debtor.DebtorID == Invoice.DebtorID);
            InvoiceOwnerName = (owner.LastName + ", " + owner.FirstName);
            return Page();
        }

        public async Task<IActionResult> OnPostMarkInvoiceAsPaidAsync(int id)
        {
            Invoice = Context.Invocies.FirstOrDefault(invoice => invoice.InvoiceId == id);
            if (Invoice == null)
            {
                return NotFound();
            }
            Invoice.Status = InvoiceStatus.Paid;
            Context.Update(Invoice);
            await Context.SaveChangesAsync();
            return RedirectToPage("./ViewInvoice", new { id });
        }

        public async Task<IActionResult> OnPostMarkInvoiceAsOverdueAsync(int id)
        {
            Invoice = Context.Invocies.FirstOrDefault(invoice => invoice.InvoiceId == id);
            if (Invoice == null)
            {
                return NotFound();
            }
            Invoice.Status = InvoiceStatus.Overdue;
            Context.Update(Invoice);
            await Context.SaveChangesAsync();
            return RedirectToPage("./ViewInvoice", new { id });
        }
    }
}