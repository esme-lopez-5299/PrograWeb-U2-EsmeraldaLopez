using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U2Practica5_SweetBakery.Models;

namespace U2Practica5_SweetBakery.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Productos")]
        public IActionResult Productos()
        {
            sweetbakeryContext contexto = new sweetbakeryContext();
            ProductosViewModel vm = new ProductosViewModel();

            var categorias = contexto.Categorias
                .Include(x => x.Productos).OrderBy(x=>x.Nombre)
                .Select(x=>new ProductosViewModel
                {NombreCategoria=x.Nombre, Productos=x.Productos.OrderBy(y=>y.Nombre)});//Explicit Loading

            //Otra opción:
            //var categorias = contexto.Productos
            //    .Include(x => x.IdCategoriaNavigation)
            //    .GroupBy(x => x.IdCategoriaNavigation.Nombre)
            //    .Select(x => new ProductosViewModel { NombreCategoria = x.Key, Productos = x });


            //3ra opción sin linq
            //List<ProductosViewModel> categorias=new List<ProductosViewModel>();
            //foreach (var item in contexto.Categorias.Include(x=>x.Productos))

            //{
            //    ProductosViewModel mv = new ProductosViewModel
            //    {
            //        NombreCategoria = item.Nombre,
            //        Productos = item.Productos
            //    };
            //    categorias.Add(mv);
            //}

          return View(categorias);
        }

    }

    
}
