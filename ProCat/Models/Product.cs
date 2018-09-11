using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProCat.Models
{
    public class Product : BaseEntity
    {
        [Key]
        public int product_id {get;set;}
        public string name {get;set;}
        public string description {get;set;}
        public decimal price {get;set;}

        public List<CatPro> CatPro {get;set;}
        public Product()
        {
            CatPro = new List<CatPro>();
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }
}