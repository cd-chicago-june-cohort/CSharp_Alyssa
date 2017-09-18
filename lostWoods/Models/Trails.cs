using System;
using System.ComponentModel.DataAnnotations;
 
namespace lostWoods.Models
{
    public class Trail : BaseEntity
    {
        [Key]
        public long id { get; set; }
 
        [Required]
        public string name { get; set; }
 
        [Required]
        public double length { get; set; }
 
        public int elev_change { get; set; }
 
        public string longitude { get; set; }
 
        public string latitude { get; set; }

        public string description { get; set; }
    }
}