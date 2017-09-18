using System;
using System.ComponentModel.DataAnnotations;
 
namespace dojoLeague.Models
{
    public class Ninja : BaseEntity
    {
        [Key]
        public long id { get; set; }
 
        [Required]
        [Display(Name="Ninja Name")]
        public string name { get; set; }
 
        [Required]
        [Display(Name="Ninjaing Level (1-10)")]
        [Range(1,10)]
        public int level { get; set; }
 
        [Display(Name="Optional Description")]
        public string description { get; set; }

        public int dojo_id { get; set; }
        public Dojo dojo { get; set; }
    }
}