
using System.ComponentModel.DataAnnotations;
using IbanNet.DataAnnotations;

namespace DebtorWebApp.Models
{
    public class Debtor
    {
        public int DebtorId { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Iban]
        public string IBAN { get; set; }
        public string CreatorID { get; set; }
    }
}
