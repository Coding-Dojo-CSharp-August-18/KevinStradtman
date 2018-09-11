using System.ComponentModel.DataAnnotations;
using ProCat.Models;

namespace ProCat.Models
{
    public class CatPro
    {
        [Key]
        public int pro_cat_id {get;set;}
        public int product_id {get;set;}
        public Product Products {get;set;}
        public int category_id {get;set;}
        public Category Categories {get;set;}
    }
}