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
            var listaProductos = DbProductos.Select(p => new InfoProductoVm { Id = p.Id, Nombre = p.Nombre, Precio = p.Precio }).ToArray();
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

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var producto = DbProductos.FirstOrDefault(p => p.Id.Equals(id));
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CapturaProductoVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var producto = DbProductos.FirstOrDefault(p => p.Id.Equals(model.Id));
            if (!(producto is null))
            {
                DbProductos[DbProductos.IndexOf(producto)] = model;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var producto = DbProductos.FirstOrDefault(p => p.Id.Equals(id));
            return View(producto);
        }


        [HttpGet]
        public IActionResult Delete(string id)
        {
            var producto = DbProductos.FirstOrDefault(p => p.Id.Equals(id));
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id, CapturaProductoVm model)
        {
            var producto = DbProductos.FirstOrDefault(p => p.Id.Equals(id));
            if (!(producto is null))
            {
                DbProductos.Remove(producto);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}