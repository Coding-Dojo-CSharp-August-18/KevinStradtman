using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public abstract class BaseEntity 
    {
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
    }
    public class RegisterUser : BaseEntity
    {
        [Key]
        public int user_id {get;set;}

        [Required(ErrorMessage="First Name is required")]
        [MinLength(2, ErrorMessage="A minimum of 2 is allowed for first name")]
        [MaxLength(30, ErrorMessage="A maximum of 30 is allowed for first name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Your first name must only contain letters")]
        [Display(Name="First Name")]
        public string first_name {get;set;}

        [Required(ErrorMessage="Last name is required")]
        [MinLength(2, ErrorMessage="A minimum of 2 is allowed for last name")]
        [MaxLength(30, ErrorMessage="A maximum of 30 is allowed for last name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Your last name must only contain letters")]
        [Display(Name="Last Name")]
        public string last_name {get;set;}

        [Required(ErrorMessage="Email is required")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        public string email {get;set;}

        [Required(ErrorMessage="Password is required")]
        [MinLength(4, ErrorMessage="A minimum length of 4")]
        [MaxLength(20, ErrorMessage="A maximum length of 20")]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string password {get;set;}

        [Required(ErrorMessage="Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("password")]
        [Display(Name="Confirm Password")]
        public string confirm {get;set;}
    }

    public class LoginUser : BaseEntity
    {
        [Required(ErrorMessage="Email is required")]
        [EmailAddress(ErrorMessage="This is an email field")]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        public string email {get;set;}

        [Required(ErrorMessage="Password is required")]
        [MinLength(4, ErrorMessage="A minimum length of 4")]
        [MaxLength(20, ErrorMessage="A maximum length of 20")]
        [DataType(DataType.Password)]
        [Display(Name="Password")]

        public string password {get;set;}
    }
     public class AddEventData : BaseEntity
    {
        public int user_id {get;set;}
        [Required(ErrorMessage="Wedder One is required")]
        [MinLength(3, ErrorMessage="Min length of 3")]
        [MaxLength(40, ErrorMessage="Max length of 40")]
        [Display(Name="Wedder One")]
        public string wedder_one {get;set;}

        [Required(ErrorMessage="Wedder Two is required")]
        [MinLength(3, ErrorMessage="Min length of 3")]
        [MaxLength(40, ErrorMessage="Max length of 40")]
        [Display(Name="Wedder Two")]
        public string wedder_two {get;set;}

        [Required(ErrorMessage="Event Date is required")]
        [Display(Name="Event Date")]
        [DataType(DataType.Date)]
        public DateTime event_date {get;set;}

        [Required(ErrorMessage="Address is required")]
        [MinLength(3, ErrorMessage="Min length of 3")]
        [MaxLength(40, ErrorMessage="Max length of 40")]
        [Display(Name="Address")]
        public string address {get;set;}
        public Wedding TheWedding()
        {
            Wedding newWedding = new Wedding
            {
                user_id = this.user_id,
                wedder_one = this.wedder_one,
                wedder_two = this.wedder_two,
                event_date = this.event_date,
                address = this.address
            };
            return newWedding;
        }
    }
}