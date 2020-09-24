﻿using System;
using System.Collections.Generic;

namespace Actividad3_Pixar.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Cortometraje = new HashSet<Cortometraje>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cortometraje> Cortometraje { get; set; }
    }
}
