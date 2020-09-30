using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using U2Practica5_SweetBakery.Models;
using U2Practica5_SweetBakery.Models.ViewModels;

namespace U2Practica5_SweetBakery.Controllers
{
    public class RecetasController : Controller
    {
        [Route("Recetas/{id}")]
        public IActionResult Index(string id)
        {

            sweetbakeryContext contexto=new sweetbakeryContext();

            var recetas = contexto.Recetas
                .Where(x => x.IdCategoriaNavigation.Nombre.ToUpper() == id.ToUpper())
                .OrderBy(x => x.Nombre);

            return View(recetas);
        }

        [Route("Receta/{id}")]
        public IActionResult Receta(string id)
        {
            sweetbakeryContext contexto = new sweetbakeryContext();

            var nombre = id.Replace("-", " ").ToUpper();

            var receta = contexto.Recetas.FirstOrDefault(x => x.Nombre.ToUpper() == nombre);

            if (receta == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                RecetaViewModel vm = new RecetaViewModel();
                vm.Receta = receta;
                Random r = new Random();
                vm.Otras = contexto.Recetas.Where(x => x.Id != receta.Id).ToList().OrderBy(x=>r.Next()).Take(3);


                return View(vm);
            }
           
        }
    }
}
