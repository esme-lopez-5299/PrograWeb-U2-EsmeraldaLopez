using System;
using System.Collections.Generic;

namespace Practica4_Materias.Models
{
    public partial class Carreras
    {
        public Carreras()
        {
            Materias = new HashSet<Materias>();
        }

        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Plan { get; set; }
        public string Especialidad { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Materias> Materias { get; set; }
    }
}
