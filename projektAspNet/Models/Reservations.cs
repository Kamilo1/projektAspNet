using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace projektAspNet.Models
{
    [Table("Reservations")]
    public class Reservations
    {
        public Reservations()
        {
            customers = new HashSet<Customers>();
            Routes = new HashSet<Routes>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int RouteID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public string KayakType { get; set; }
        [Required]
        public int NumberOfKayaks { get; set; }
        public virtual ISet<Customers> customers { set; get; }
        public virtual ISet<Routes> Routes { set; get; }
    }
}
