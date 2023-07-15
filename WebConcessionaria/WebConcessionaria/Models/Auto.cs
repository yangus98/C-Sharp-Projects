using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebConcessionaria.Models
{
    public enum CasaProduttrice {Fiat,Ferrari,BMW,Citroen} 
    public class Auto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [Display(Name = "Casa produttrice")]
        public CasaProduttrice CasaProduttrice { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "{0} è obbligatorio!")]
        public string? Modello { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        public int Prezzo { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [Display(Name = "Anno di uscita")]
        public int AnnoUscita { get; set; }
    }
}
