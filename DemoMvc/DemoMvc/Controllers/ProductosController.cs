using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
    public class ProductosController : Controller
    {
        private static readonly List<CapturaProductoVm> DbProductos = new List<CapturaProductoVm>();

        public IActionResult Index()
        {
            //Ir a un servicio para obtener la lista de productos
            var listaProductos = DbProductos.Select(p => new InfoProductoVm { Nombre = p.Nombre, Precio = p.Precio }).ToArray();
            return View(listaProductos);
        }

        //GET /Productos/Captura
        [HttpGet]
        public IActionResult Captura()
        {
            return View();
        }


        //POST /Productos/Captura
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Captura(CapturaProductoVm model)
        {
            if (ModelState.IsValid)
            {
                //Crear un objeto del dominio a partir del modelo de la vista
                //Persistir el objeto del dominio
                DbProductos.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}