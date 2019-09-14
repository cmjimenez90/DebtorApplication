using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DebtorWebApp.Models
{
    public class Invoice
    {
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [Required]
        public InvoiceStatus Status {get; set;}
    }

    public enum InvoiceStatus
    {
        Open,
        Paid,
        Overdue
    }
}
