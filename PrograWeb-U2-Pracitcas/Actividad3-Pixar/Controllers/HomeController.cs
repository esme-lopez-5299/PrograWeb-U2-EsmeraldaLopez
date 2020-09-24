using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Actividad3_Pixar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad3_Pixar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [Route("peliculas")]
        public IActionResult Peliculas()
        {
            pixarContext contexto = new pixarContext();
            var peliculas = contexto.Pelicula.OrderBy(x => x.Nombre);
            return View(peliculas);
        }

        [Route("peliculas/{id}")]
        public IActionResult Bichos(string id)
        {
            pixarContext contexto = new pixarContext();

            var peliparametro = id.Replace("-", " ").ToUpper();            
            var peli = contexto.Pelicula.Include(x=>x.Apariciones).FirstOrDefault(x => x.Nombre.ToUpper() == peliparametro);
            var infoApariciones = contexto.Apariciones.Include(x => x.IdPersonajeNavigation).Include(x => x.IdPeliculaNavigation)
                .Where(x => (x.IdPelicula == peli.Id)).Select(x => x);
            if (peli==null)
            {
                return RedirectToAction("Peliculas");
            }
            else
            {
                BichosViewModel vm = new BichosViewModel();

                vm.Nombre = peli.Nombre;
                vm.Id = peli.Id;
                vm.NombreOriginal = peli.NombreOriginal;
                vm.FechaEstreno = peli.FechaEstreno;
                vm.Descripcion = peli.Descripción;
                vm.Apariciones = infoApariciones;               
                return View(vm);
            }           
        }


        [Route("cortos")]
        public IActionResult Cortos()
        {

            pixarContext contexto = new pixarContext();




            
            CortosViewModel vm = new CortosViewModel();
            var listaCategorias = contexto.Categoria.Include(x => x.Cortometraje).OrderBy(x => x.Nombre);

            vm.Categoria = listaCategorias;



            return View(vm);
        }


        [Route("cortos/{id}")]
        public IActionResult InfoCorto(string id)
        {

            pixarContext contexto = new pixarContext();
            var cortoParametro = id.Replace("-", " ").ToUpper();
            var corto = contexto.Cortometraje.Include(x => x.IdCategoriaNavigation).FirstOrDefault(x => x.Nombre.ToUpper() == cortoParametro);

            if(corto==null)
            {
                return RedirectToAction("Cortos");
            }
            else
            {
                Cortometraje cView = new Cortometraje();
                cView.Id = corto.Id;
                cView.IdCategoria = corto.IdCategoria;
                cView.Nombre = corto.Nombre;
                cView.Descripcion = corto.Descripcion;

                return View(cView);


            }
          
        }
    }
}
