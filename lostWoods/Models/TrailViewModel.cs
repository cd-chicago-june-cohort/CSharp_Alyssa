using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
 
namespace lostWoods.Models
{
    public class TrailViewModel : BaseEntity
    {
        [Required]
        [Display(Name = "Trail Name")]
        public string name { get; set; }
 
        [Required]
        [Display(Name = "Description")]
        [MinLength(10, ErrorMessage = "Descriptions must be at least 10 characters")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Trail Length")]
        public double length { get; set; }

        [Required]
        [Display(Name = "Elevation Change")]
        public int elev_change { get; set; }
 
        [Required]
        [Display(Name = "Longitude")]
        public string longitude { get; set; }
 
        [Required]
        [Display(Name = "Latitude")]
        public string latitude { get; set; }

        
    }
}