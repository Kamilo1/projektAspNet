using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace projektAspNet.Models
{
    [Table("Reservations")]
    public class Reservation
    {
        public Reservation()
        {
            Customers = new HashSet<Customer>();
            Routes = new HashSet<Route>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int RouteID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfKayaking { get; set; }
        [Required]
        public string KayakType { get; set; }
        [Required]
        public int NumberOfKayaks { get; set; }
        public virtual ISet<Customer> Customers { set; get; }
        public virtual ISet<Route> Routes { set; get; }
        public Route Route { get; set; }
        public Customer Customer { get; set; }
    }
}
