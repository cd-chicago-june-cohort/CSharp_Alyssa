using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace restReviews.Models
{
    public class Review : BaseEntity
    {
        [Key]
        public long id { get; set; }
 
        [Required]
        [Display(Name="Reviewer Name")]
        public string author { get; set; }
 
        [Required]
        [Display(Name="Restaurant Name")]
        public string restaurant { get; set; }
 
        [Required]
        [Display(Name="Review")]
        [MinLength(10)]
        public string review { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Date of Visit")]
        public DateTime date { get; set; }

        [Required]
        [Display(Name="Stars")]
        [Range(1,5)]
        public short rating { get; set; }
    }
}

