using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U2Practica5_SweetBakery.Models;

namespace U2Practica5_SweetBakery.Models.ViewModels
{
    public class RecetaViewModel
    {
        public Recetas Receta { get; set; }

        public IEnumerable<Recetas> Otras { get; set; }

    }
}
