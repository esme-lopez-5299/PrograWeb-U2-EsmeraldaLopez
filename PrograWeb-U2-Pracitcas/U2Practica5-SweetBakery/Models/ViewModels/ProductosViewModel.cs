using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace U2Practica5_SweetBakery.Models
{
    public class ProductosViewModel
    {
        public string NombreCategoria { get; set; }
        public IEnumerable<Models.Productos> Productos { get; set; }

    }
}
