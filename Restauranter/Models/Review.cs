using System;
using System.ComponentModel.DataAnnotations;

namespace Restauranter.Models
{
    public abstract class BaseEntity
    {
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
    }
    public class Review : BaseEntity
    {
        [Key]
        public int review_id {get;set;}
        [Required(ErrorMessage="Reviewer Name is required")]
        [MinLength(2, ErrorMessage="Reviewer Name has a min length of 2")]
        [MaxLength(30, ErrorMessage="Reviewer Name has a max length of 30")]
        public string name {get;set;}
        [Required(ErrorMessage="Restaurant Name is required")]
        [MinLength(2, ErrorMessage="Restuarant Name has a min length of 2")]
        [MaxLength(30, ErrorMessage="Restuarant Name has a max length of 30")]
        public string rest_name {get;set;}
        [Required(ErrorMessage="Restaurant Name is required")]
        [MinLength(5, ErrorMessage="Review has a min length of 5")]
        public string review {get;set;}
        [Required(ErrorMessage="Visit Date is required")]
        [DataType(DataType.Date)]
        public DateTime visit {get;set;}
        public int rating {get;set;}
        public Review()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }
}