using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace projektAspNet.Models
{
    [Table("Events")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput]
        public int Id { get; set; }
        [Display(Name = "EventName")]
        [Required(ErrorMessage = "EventName is required")]
        public string EventName { get; set; }
        [Required(ErrorMessage = "DateOfEvent is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfEvent { get; set; }
        [Display(Name = "Event_Location")]
        [Required(ErrorMessage = "Event_Location is required")]
        public string Event_Location { get; set; }
    }
}
