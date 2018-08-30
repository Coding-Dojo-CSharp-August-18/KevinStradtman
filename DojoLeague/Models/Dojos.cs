using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models
{
    public class Dojos : BaseEntity
    {
        [Key]
        public long Id {get;set;}

        [Required(ErrorMessage="Dojo name is required")]
        [MinLength(3, ErrorMessage="A minimum of 3 characters is required")]
        [MaxLength(30, ErrorMessage="A maximum of 30 characters is allowed for dojo name")]
        [Display(Name="Dojo Name")]
        public string name {get;set;}

        [Required(ErrorMessage="Dojo location is required")]
        [MinLength(3, ErrorMessage="A minimum of 3 characters is required for dojo location")]
        [MaxLength(30, ErrorMessage="A maximum of 30 characters is allowed for dojo location")]
        [Display(Name="Dojo Location")]
        public string location {get;set;}

        [MinLength(3, ErrorMessage="A minimum of 3 characters is required")]
        [MaxLength(100, ErrorMessage="A maximum of 100 characters is allowed")]
        [Display(Name="Additional Information")]
        public string extra {get;set;}

        public DateTime created_at {get;set;}
        
        public DateTime updated_at {get;set;}

        public ICollection<Ninjas> ninjas {get;set;}

        public Dojos() 
        {
            ninjas = new List<Ninjas>();
        }
    }
}