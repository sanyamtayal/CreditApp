using System.ComponentModel.DataAnnotations;

namespace CreditApp.Models
{
    public class CreditRequest
    {
        [Required(ErrorMessage = "Credit amount is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int CreditAmount { get; set; }

        [Required(ErrorMessage = "Term is required")]
        [Range(1, 12, ErrorMessage = "Please enter valid Month")]
        public int TermRepayment { get; set; }

        [Required(ErrorMessage = "PreExisting credit amount is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int PreExistingCreditAmount { get; set; }
    }
}   