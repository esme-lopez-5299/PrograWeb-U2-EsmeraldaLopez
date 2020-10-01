using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U2Actividad5_Animales.Models;
using U2Actividad5_Animales.Models.ViewModels;

namespace U2Actividad5_Animales.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            animalesContext contexto = new animalesContext();
            IndexViewModel vm=new IndexViewModel();
            vm.Clases = contexto.Clase.OrderBy(x => x.Nombre);
            List<int> arregloNumeros = new List<int> { 1,2,3,4,5};
            Random r = new Random();
            int tempo = r.Next(1, 5);
            vm.NumeroImagen =arregloNumeros.OrderBy(x => r.Next()).First();                      
            return View(vm);
        }

        [Route("{id}")]
        public IActionResult Especies(string id)
        {
            animalesContext contexto = new animalesContext();
            var claseElegida = contexto.Clase.FirstOrDefault(x => x.Nombre.ToUpper() == id.ToUpper());
            if(claseElegida==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                EspeciesViewModel vm = new EspeciesViewModel();
                vm.Especies = contexto.Especies.Include(x => x.IdClaseNavigation).Where(x => x.IdClase == claseElegida.Id);
                vm.NombreClase = claseElegida.Nombre;

                return View(vm);
            }
            
        }
    }
}