using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace projektAspNet.Models
{
    [Table("Routes")]
    public class Route
    {
        // public Route() 
        // {
        //     Customers = new HashSet<Customer>();
        //      Reservations= new HashSet<Reservation>();  
        //   }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput]
        public int Id { get; set; }
        [Display(Name = "RouteName")]
        [Required(ErrorMessage = "RouteName is required")]
        public string RouteName { get; set; }
        [Display(Name = "Difficulty")]
        [Required(ErrorMessage = "Difficulty is required")]
        public string Difficulty { get; set; }
        [Display(Name = "Route Length")]
        [Required(ErrorMessage = "Route Length is required")]
        public string Route_Length { get; set; }
        //   public virtual ISet<Customer> Customers { get; set; }
        //    public virtual ISet<Reservation> Reservations { get; set; }
        public ICollection<Reservation> Reservation { get; set; }
    }
}
