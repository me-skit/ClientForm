using System;
using System.ComponentModel.DataAnnotations;

namespace ClientForm.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [StringLength(13, MinimumLength = 13)]
        public string DPI { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Fecha de Creación")]
        public DateTime CreationDate { get; set; }
    }
}
