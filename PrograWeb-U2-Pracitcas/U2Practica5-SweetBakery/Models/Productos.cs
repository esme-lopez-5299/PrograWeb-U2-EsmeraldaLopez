using System;
using System.Collections.Generic;

namespace U2Practica5_SweetBakery.Models
{
    public partial class Productos
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual Categorias IdCategoriaNavigation { get; set; }
    }
}
