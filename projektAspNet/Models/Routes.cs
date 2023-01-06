using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace projektAspNet.Models
{
    [Table("Routes")]
    public class Routes
    {
        public Routes() 
        {
            Customers = new HashSet<Customers>();
            Reservations= new HashSet<Reservations>();  
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RouteName { get; set; }
        public virtual ISet<Customers> Customers { get; set; }
        public virtual ISet<Reservations> Reservations { get; set; }
    }
}
