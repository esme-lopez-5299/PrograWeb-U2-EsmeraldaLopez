using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practica2_EsmeraldaLopez.Models;

namespace Practica2_EsmeraldaLopez.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ObtenerResultados(Numeros n)
        {
            var respuesta = n.n1 + n.n2;
            return View(respuesta);
        }
    }
}
