using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtorWebApp.Data;
using DebtorWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DebtorWebApp.Pages.Debtors
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public IndexModel(ApplicationDbContext context) => this.context = context;
        public IList<Debtor> Debtors { get; set; }

        public async Task OnGetAsync()
        {
            Debtors = await context.Debtors.Include("Invoices").ToListAsync();
        }
    }
}