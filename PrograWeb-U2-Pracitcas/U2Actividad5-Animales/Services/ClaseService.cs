using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U2Actividad5_Animales.Models;

namespace U2Actividad5_Animales.Services
{
    public class ClaseService
    {
        public List<Clase> Clases { get; set; }

       
    public ClaseService()
    {
            using(animalesContext context = new animalesContext())
            {
            animalesContext contexto = new animalesContext();
            Clases = contexto.Clase.OrderBy(x => x.Nombre).ToList();
            }
           
        }
    }
}
