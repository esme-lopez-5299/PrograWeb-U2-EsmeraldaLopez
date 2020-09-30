using System;
using System.Collections.Generic;

namespace U2Practica5_SweetBakery.Models
{
    public partial class Categorias
    {
        public Categorias()
        {
            Productos = new HashSet<Productos>();
            Recetas = new HashSet<Recetas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
        public virtual ICollection<Recetas> Recetas { get; set; }
    }
}
