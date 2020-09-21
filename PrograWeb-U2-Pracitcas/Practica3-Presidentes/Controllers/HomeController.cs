using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica3_Presidentes.Models;

namespace Practica3_Presidentes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            presidentesContext contexto = new presidentesContext();
            var presidentes = contexto.Presidente.OrderBy(x=>x.Nombre);
            
            return View(presidentes);
        }

        public IActionResult Biografia(int? id)
        {

            if(id==null)
            {
              return RedirectToAction("Index");
            }

            presidentesContext contexto = new presidentesContext();
            var presidente = contexto.Presidente
                .Include(x=>x.IdPartidoPoliticoNavigation)
                .Include(x=>x.IdEstadoRepublicaNavigation)
                .FirstOrDefault(x => x.Id == id);

            if(presidente==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(presidente);
            }
            
        }
    }
}
