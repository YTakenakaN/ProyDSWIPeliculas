using Microsoft.AspNetCore.Mvc;
using ProyDSWIPeliculas.DAO;
using ProyDSWIPeliculas.Models;

namespace ProyDSWIPeliculas.Controllers
{
    public class CarritoController : Controller
    {
        private readonly CarritoDAO carritoDAO;

        public CarritoController(CarritoDAO _carritoDAO)
        {
            carritoDAO = _carritoDAO;
        }

        // GET: CarritoController
        public ActionResult IndexCarrito()
        {
            var listado = carritoDAO.ListarCarrito();
            return View(listado);
        }

        // GET: CarritoController/Agregar
        public ActionResult AgregarAlCarrito(int codPeli)
        {
            // Agrega una película al carrito con cantidad inicial de 1
            carritoDAO.AgregarAlCarrito(codPeli, 1);
            TempData["mensaje"] = "Película agregada al carrito correctamente.";
            return RedirectToAction("IndexCarrito");
        }

        // POST: CarritoController/Editar
        [HttpPost]
        public ActionResult EditarCantidadCarrito(int codPeli, int nuevaCantidad)
        {
            try
            {
                carritoDAO.EditarCantidadCarrito(codPeli, nuevaCantidad);
                TempData["mensaje"] = "Cantidad actualizada correctamente.";
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("IndexCarrito");
        }

        // POST: CarritoController/Eliminar
        [HttpPost]
        public ActionResult EliminarDelCarrito(int codPeli)
        {
            try
            {
                carritoDAO.EliminarDelCarrito(codPeli);
                TempData["mensaje"] = "Película eliminada del carrito correctamente.";
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("IndexCarrito");
        }
    }
}
