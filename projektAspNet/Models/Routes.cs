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
        public int Id { get; set; }
        public string RouteName { get; set; }
        //   public virtual ISet<Customer> Customers { get; set; }
        //    public virtual ISet<Reservation> Reservations { get; set; }
        public ICollection<Reservation> Reservation { get; set; }
    }
}
