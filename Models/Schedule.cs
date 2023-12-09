using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class Schedule
    {
        public int ID { get; set; }
        [Display(Name = "Service Date")]
        [DataType(DataType.Date)]
        
        public DateTime ScheduleDate { get; set; }
        

        public string Location { get; set; }
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }
        [Display(Name = "Hourly Rate")]
        [DataType(DataType.Currency)]
        public int Rate { get; set; }
        [Display(Name = "Session Start Time")]
        public string Start { get; set; }
        [Display(Name = "Session End Time")]
        public string End { get; set; }

    }
}
