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
        public IActionResult Index()
        {
            //Ir a un servicio para obtener la lista de productos
            var listaProductos = new List<InfoProductoVm> {
                new InfoProductoVm {Nombre="Coca cola",Precio =10},
                new InfoProductoVm {Nombre="Sabritas",Precio =9},
                new InfoProductoVm {Nombre="Frutsi",Precio =5},
            };

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
        IActionResult Captura(CapturaProductoVm model)
        {
            if (ModelState.IsValid)
            {
                //Crear un objeto del dominio a partir del modelo de la vista
                //Persistir el objeto del dominio

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}