using DebtorWebApp.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtorWebApp.Models
{
    public static class TestData
    {
        public static void Initialize(IServiceProvider service)
        {
            using (var context = new ApplicationDbContext(service.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Debtors.Any()) return;
                context.Debtors.AddRange(
                    new Debtor {
                        Email = "testemail@gmail.com",
                        FirstName = "Test",
                        LastName = "1"
                    },
                     new Debtor
                     {
                         Email = "csmiles@whoknows.com",
                         FirstName = "Carry",
                         LastName = "Smiles"
                     },
                      new Debtor
                      {
                          Email = "branchs@boinks.com",
                          FirstName = "Samuel",
                          LastName = "Branch"
                      }
                    );
                context.SaveChanges();
            }
        }
    }
}
