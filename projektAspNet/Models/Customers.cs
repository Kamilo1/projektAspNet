using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace projektAspNet.Models
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        public string LastName { get; set; }
        [Required]
        [Column("pesel")]
        [StringLength(11)]
        public string Pesel { get; set; }
        [Column("company_name")]
        public string CompanyName { get; set; }
        [Column("NIP")]
        [StringLength(10)]
        public string NIP { get; set; }


    }
}
