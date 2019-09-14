using System;
using System.ComponentModel.DataAnnotations;


namespace DebtorWebApp.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [Required]
        public InvoiceStatus Status {get; set;}
        public string DebtorID { get; set; }
    }

    public enum InvoiceStatus
    {
        Open,
        Paid,
        Overdue
    }
}
