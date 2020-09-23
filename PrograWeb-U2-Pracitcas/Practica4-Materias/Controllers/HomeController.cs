using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica4_Materias.Models;

namespace Practica4_Materias.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            mapa_curricularContext contexto = new mapa_curricularContext();

            var carreras = contexto.Carreras.OrderBy(x => x.Nombre);

            return View(carreras);
        }

        [Route("{id}")]
        public IActionResult Informacion(string id)
        {
            //Instanciamos varias veces para no abrir automaticamente
            //las conexiones cuando se conecten los usuarios.
            mapa_curricularContext contexto = new mapa_curricularContext();

            var nombre = id.Replace("-", " ").ToLower();

            var carrera = contexto.Carreras.FirstOrDefault(x=>x.Nombre.ToLower()==nombre);

            if(carrera==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(carrera);
            }            
        }

        [Route("{id}/Reticula")]
        public IActionResult Reticula(string id)
        {
            var nombre = id.Replace("-", " ").ToUpper();

            mapa_curricularContext contexto = new mapa_curricularContext();

            var carrera = contexto.Carreras.Include(x=>x.Materias).FirstOrDefault(x => x.Nombre.ToUpper() == nombre);

            if(carrera==null)
            {
                return RedirectToAction("Index");
            }
            else
            {

            ReticulaViewModel vm = new ReticulaViewModel();//Este se mandará a la vista. Se manda lleno
                                                           //El proceso de llenado se hace en el controlador.

                vm.Nombre = carrera.Nombre;
                vm.Plan = carrera.Plan;
                vm.Creditos = carrera.Materias.Sum(x => x.Creditos);

                vm.Materias = carrera.Materias.OrderBy(x => x.Semestre)
                    .GroupBy(x => x.Semestre).Select(x => x).ToArray();

                //Otra forma de hacerlo.
                //vm.Materias = new List<Materias>[9];
                //for (int i = 0; i <vm.Materias.Length ; i++)
                //{
                //    vm.Materias[i] = contexto.Materias.Where(x => x.Semestre == i + 1);
                //}


                return View(vm);
            }

        }

    }
}
