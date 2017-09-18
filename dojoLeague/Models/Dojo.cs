using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace dojoLeague.Models
{
    public class Dojo : BaseEntity
    {
        public Dojo(){
            ninjas = new List<Ninja>();
        }

        [Key]
        public long id { get; set; }
 
        [Required]
        [Display(Name="Dojo Name")]
        public string name { get; set; }
 
        [Required]
        [Display(Name="Dojo Location")]
        public string location { get; set; }
 
        [Required]
        [Display(Name="Additional Dojo Information")]
        public string information { get; set; }

        public ICollection<Ninja> ninjas { get; set; }
    }
}

