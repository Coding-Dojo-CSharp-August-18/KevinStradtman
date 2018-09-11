using System;
using System.ComponentModel.DataAnnotations;

namespace ProCat.Models
{
    public abstract class BaseEntity
    {
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
    }
    public class AddProduct : BaseEntity
    {
        [Key]
        public int product_id {get;set;}

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [Display(Name="Product Name")]
        public string name {get;set;}

        [Required]
        [MinLength(5)]
        [Display(Name="Description")]
        public string description {get;set;}
        
        [Required]
        [DataType(DataType.Currency)]
        public decimal price {get;set;}
    }
    public class AddCategory : BaseEntity
    {
        [Key]
        public int category_id {get;set;}

        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        [Display(Name="Category Name")]
        public string name {get;set;}
    }
}