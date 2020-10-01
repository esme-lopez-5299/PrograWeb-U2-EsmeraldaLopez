using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace U2Actividad5_Animales.Models.ViewModels
{
    public class EspeciesViewModel
    {
        public string NombreClase { get; set; }
        public IEnumerable<Especies> Especies { get; set; }

    }
}
