using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U2Practica5_SweetBakery.Models;

namespace U2Practica5_SweetBakery.Services
{
    public class CategoriasService
    {
        public List<Categorias> Categorias { get; set; }

        public CategoriasService()
        {
            using (sweetbakeryContext contexto = new sweetbakeryContext())
            {
                sweetbakeryContext context = new sweetbakeryContext();
                Categorias = context.Categorias.OrderBy(x => x.Nombre).ToList();
            }           
        }
    }
}
