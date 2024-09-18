using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adspire.Shared.Entities
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Departamento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        public int? CountryId { get; set; }

        //a uno
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        //de muchos
        public virtual ICollection<City> Cities { get; set; }

        [Display(Name = "Municipios")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}