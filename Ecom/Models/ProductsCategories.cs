using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class ProductsCategories
    {
        [Key]
        public int procat_id {get;set;}
        public int product_id {get;set;}
        public Product Products {get;set;}
        public int category_id {get;set;}
        public Category Categories {get;set;}
    }
}