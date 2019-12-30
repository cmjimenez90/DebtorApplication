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
                     new Debtor
                     {
                         Email = "csmiles@whoknows.com",
                         FirstName = "Carry",
                         LastName = "Smiles",
                         OwnerID = "75F4B8C7-DA1A-4C60-81F9-0B275FB27D8D"
                     },
                      new Debtor
                      {
                          Email = "branchs@boinks.com",
                          FirstName = "Samuel",
                          LastName = "Branch",
                          OwnerID = "79E497F2-1E23-4294-A216-63624167D4FD"
                      }
                    );
                context.SaveChanges();
            }
        }
    }
}
