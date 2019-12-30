using System;
using System.Collections.Generic;
using System.Text;
using DebtorWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DebtorWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Debtor> Debtors { get; set; }
        public DbSet<Invoice> Invocies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
