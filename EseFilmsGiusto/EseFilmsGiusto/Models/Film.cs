using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EseFilms.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [MaxLength(150, ErrorMessage = "Massimo {1} caratteri!")]
        public string Titolo { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [Display(Name = "Anno Uscita")]
        public int AnnoUscita { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nome Locandina")]
        public string? NomeLocandina { get; set; }

        [NotMapped]
        [Display(Name = "Locandina")]
        public IFormFile? FileLocandina { get; set; }

    }
}
