using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace projektAspNet.Models
{
    [Table("Routes")]
    public class Routes
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
    }
}
