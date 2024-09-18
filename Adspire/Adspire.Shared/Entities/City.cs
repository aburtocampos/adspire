using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adspire.Shared.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Municipio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ame { get; set; }

        public int? IdState { get; set; }

        [ForeignKey("IdState")]
        public State State { get; set; }
    }
}