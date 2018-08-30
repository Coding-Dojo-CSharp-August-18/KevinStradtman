using System;
using System.ComponentModel.DataAnnotations;

namespace TheDojoLeague.Models
{
    public abstract class BaseEntity {}
    public class Ninjas : BaseEntity
    {
        [Key]
        public long Id {get;set;}

        [Required(ErrorMessage="Name is required")]
        [MinLength(2, ErrorMessage="A minimum of 2 characters is required for the name")]
        [MaxLength(30, ErrorMessage="A maximum of 30 characters is allowed for the name")]
        [Display(Name="Ninja Name")]
        public string name {get;set;}

        [Required(ErrorMessage="Ninjaing level is required")]
        [Display(Name="Ninjaing Level (1-10)")]
        public int level {get;set;}
        [Display(Name="Dojo")]
        public int dojo_id {get;set;}

        [MinLength(5, ErrorMessage="A minimum of 5 characters is required for the description")]
        [MaxLength(100, ErrorMessage="A maximum of 100 characters is allowed for the description")]
        [Display(Name="Optional Description")]
        public string description {get;set;}

        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
        public Dojos dojo {get;set;}
    }
}