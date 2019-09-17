using System.Threading.Tasks;
using DebtorWebApp.Data;
using DebtorWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DebtorWebApp.Pages.Debtors
{
    public class ViewDebtorModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public Debtor Debtor { get; set; }

        public ViewDebtorModel(ApplicationDbContext context) => this.context = context;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Debtor = await context.Debtors.Include("Invoices").FirstOrDefaultAsync(item => item.DebtorID == id);

            if (Debtor == null) return NotFound();

            return Page();
        }
    }
}