using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class OfferedService
    {
        public int ID { get; set; }
        [Display(Name = "Service Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        
        [Display(Name = "Hourly Rate")]
        [DataType(DataType.Currency)]
        [Required]
        public int Rate { get; set; }

    }
}
