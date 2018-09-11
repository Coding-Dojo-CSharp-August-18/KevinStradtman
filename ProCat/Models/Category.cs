using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProCat.Models
{
    public class Category : BaseEntity 
    {
        [Key]
        public int category_id {get;set;}
        public string name {get;set;}
        public List<CatPro> CatPro {get;set;}
        public Category()
        {
            CatPro = new List<CatPro>();
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }

    }
}