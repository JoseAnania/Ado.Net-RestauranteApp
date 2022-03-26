using FinalRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalRestaurante.Controllers
{
    public class RestauranteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agregar()
        {
            GestorRestaurante GR = new GestorRestaurante();
            Restaurante R = new Restaurante();
            R.pedido = new Pedido();
            R.nombreMozo = GR.ObtenerNombre();
            return View(R);
        }

        [HttpPost]
        public ActionResult Agregar(Restaurante nuevoPedido)
        {
            GestorRestaurante GR = new GestorRestaurante();
            GR.Agregar(nuevoPedido.pedido);
            return View("Index");
        }
        public ActionResult Eliminar()
        {
            GestorRestaurante GR = new GestorRestaurante();
            Restaurante R = new Restaurante();
            R.pedido = new Pedido();
            R.nombreMozo = GR.ObtenerNombre();
            return View(R);
        }

        [HttpPost]
        public ActionResult Eliminar(Restaurante borrarPedido)
        {
            GestorRestaurante GR = new GestorRestaurante();
            GR.Eliminar(borrarPedido.pedido);
            return View("Index");
        }

        public ActionResult Modificar()
        {
            GestorRestaurante GR = new GestorRestaurante();
            Restaurante R = new Restaurante();
            R.pedido = new Pedido();
            R.nombreMozo = GR.ObtenerNombre();
            return View(R);
        }

        [HttpPost]
        public ActionResult Modificar(Restaurante cambiarPedido)
        {
            GestorRestaurante GR = new GestorRestaurante();
            GR.Modificar(cambiarPedido.pedido);
            return View("Index");
        }
        public ActionResult Listar()
        {
            GestorRestaurante GR = new GestorRestaurante();
            List<PedidoDto> lista = GR.Listar();
            return View(lista);
        }
        public ActionResult Reporte()
        {
            GestorRestaurante GR = new GestorRestaurante();
            ViewData["total"] = GR.Reporte();
            return View();
        }
    }
}
