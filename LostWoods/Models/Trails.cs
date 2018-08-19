using System.ComponentModel.DataAnnotations;

namespace LostWoods.Models
{
    public abstract class BaseEntity {}
    public class Trails : BaseEntity
    {
        [Key]
        public long Id {get;set;}
        
        [Required(ErrorMessage="The trail name is required")]
        [MinLength(2, ErrorMessage="A minimum of 2 characters is required for the trail name")]
        [Display(Name="Trail Name")]
        public string name {get;set;}

        [Required(ErrorMessage="Description is required")]
        [MinLength(10, ErrorMessage="A minimum of 10 characters is required for the description")]
        [Display(Name="Description")]
        public string description {get;set;}

        [Required(ErrorMessage="Trail length is required")]
        [Display(Name="Trail Length")]
        public double trail_length {get;set;}

        [Required(ErrorMessage="Elevation is required")]
        [Display(Name="Elevation Change")]
        [Range(-1000, 300000)]
        public long elevation {get;set;}

        [Required(ErrorMessage="Logitude is required")]
        [Display(Name="Longitude")]
        [Range(-180.00000, 180.00000)]
        public double lng {get;set;}

        [Required(ErrorMessage="Latitude is required")]
        [Display(Name="Latitude")]
        [Range(-90.00000, 90.00000)]
        public double lat {get;set;}

    }
}