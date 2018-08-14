using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace DojoSurveyValid.Models
{
    public class FormData
    {
        [Required]
        [MinLength(2, ErrorMessage="You need to have at least 2 characters for the name")]
        [MaxLength(20, ErrorMessage="You cannot exceed 20 characters for the name")]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        // public List<SelectListItem> Locations {get;} = new List<SelectListItem>
        // {
        //     new SelectListItem {Value="Seattle", Text="Seattle"},
        //     new SelectListItem {Value="Washington D.C.", Text="Washington D.C."},
        //     new SelectListItem {Value="Redmond W.A.", Text="Redmond W.A."},
        //     new SelectListItem {Value="Austin Texas", Text="Austin Texas"}
        // };

        [Required]
        [Display(Name="Favorite Language")]
        public string Language { get; set; }
        // public List<SelectListItem> Languages {get;} = new List<SelectListItem>
        // {
        //     new SelectListItem {Value="PHP", Text="PHP"},
        //     new SelectListItem {Value="C#", Text="C#"},
        //     new SelectListItem {Value="C++", Text="C++"},
        //     new SelectListItem {Value="JavaScript", Text="JavaScript"}
        // };
        
        [MinLength(5, ErrorMessage="You must have at least 5 characters for the comment")]
        [MaxLength(100, ErrorMessage="You cannot exceed 100 characters for the comment")]
        [Display(Name="Comment")]
        public string Comment { get; set; }
    }
}