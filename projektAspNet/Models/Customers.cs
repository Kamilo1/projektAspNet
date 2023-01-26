using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace projektAspNet.Models
{
    [Table("Customers")]
    public class Customer
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput]
        public int Id { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname is required")]
        public string LastName { get; set; }
        [Display(Name = "Pesel")]
        [Required(ErrorMessage = "Pesel is required")]
        [StringLength(11)]
        public string Pesel { get; set; }
        [Display(Name = "Telephone")]
        [Required(ErrorMessage = "Telephone is required")]
        [StringLength(9)]
        public string Telephone { get; set; }
        [Display(Name = "CompanyName")]
        public string CompanyName { get; set; }
        [Display(Name = "NIP")]
        [StringLength(10)]
        public string NIP { get; set; }
        public ICollection<Reservation> Reservation { get; set; }


    }
}