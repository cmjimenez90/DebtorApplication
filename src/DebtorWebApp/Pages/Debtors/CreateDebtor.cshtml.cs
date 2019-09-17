using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtorWebApp.Data;
using DebtorWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DebtorWebApp.Pages.Debtors
{
    public class NewDebtorModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public Debtor Debtor {get; set;}
        
        public NewDebtorModel(ApplicationDbContext context) => this.context = context;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Debtors.Add(Debtor);
            await context.SaveChangesAsync();

            return RedirectToPage("./index");
        }
    }
}