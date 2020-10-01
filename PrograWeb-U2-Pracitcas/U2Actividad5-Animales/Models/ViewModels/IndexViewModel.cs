using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace U2Actividad5_Animales.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Clase> Clases { get; set; }
        public int NumeroImagen { get; set; }

    }
}
