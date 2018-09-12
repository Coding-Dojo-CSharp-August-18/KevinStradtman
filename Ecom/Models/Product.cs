using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Product : BaseEntity
    {
        [Key]
        public int product_id {get;set;}
        public string name {get;set;}
        public double price {get;set;}
        public string short_desc {get;set;}
        public string description {get;set;}
        public double weight {get;set;}
        public List<ProductsCategories> ProductsCategories {get;set;}
        public Product()
        {
            ProductsCategories = new List<ProductsCategories>();
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }
}