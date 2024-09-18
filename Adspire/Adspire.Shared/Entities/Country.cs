using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adspire.Shared.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "País")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        public virtual ICollection<State> States { get; set; }

        [Display(Name = "Departamentos")]
        public int StatesNumber => States == null ? 0 : States.Count;
    }
}