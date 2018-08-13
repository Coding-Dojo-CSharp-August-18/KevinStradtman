using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Quote
    {
        [Required(ErrorMessage="Name is required")]
        [MinLength(2, ErrorMessage="At least 2 characters are required for the name")]
        [MaxLength(50, ErrorMessage="Only up to 20 characters are allowed for the name")]
        [Display(Name="Name")]
        public string name {get;set;}

        [Required(ErrorMessage="Quote is required")]
        [MinLength(5, ErrorMessage="At least 5 characters are required for the quote")]
        [MaxLength(100, ErrorMessage="Only up to 100 characters are allowed for the quote")]
        [Display(Name="Quote")]
        public string quote_body {get;set;}
    }
}