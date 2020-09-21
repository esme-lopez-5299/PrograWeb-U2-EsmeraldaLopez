using System;
using System.Collections.Generic;

namespace Practica3_Presidentes.Models
{
    public partial class Estadorepublica
    {
        public Estadorepublica()
        {
            Presidente = new HashSet<Presidente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Presidente> Presidente { get; set; }
    }
}
