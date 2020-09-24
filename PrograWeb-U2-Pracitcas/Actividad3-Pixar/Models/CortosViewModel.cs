using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad3_Pixar.Models
{
    public class CortosViewModel
    {
        //public int IdCategoria { get; set; }
        //public string NombreCategoria { get; set; }

        //public int IdCortometraje { get; set; }
        //public string NombreCortometraje { get; set; }
        //public string DescripcionCorto { get; set; }

        public IEnumerable<Categoria> Categoria { get; set; }

        public IEnumerable<Cortometraje> Cortos { get; set; }
    }
}
