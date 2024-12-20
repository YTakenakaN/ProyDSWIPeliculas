using Microsoft.AspNetCore.Mvc;
using ProyDSWIPeliculas.DAO;
using ProyDSWIPeliculas.Models;

namespace ProyDSWIPeliculas.Controllers
{
    public class SalesController : Controller
    {
        private readonly SalesDAO salesDAO;
        private readonly CarritoDAO carritoDAO; // Asumiendo que existe un DAO para manejar el carrito

        public SalesController(SalesDAO _salesDAO, CarritoDAO _carritoDAO)
        {
            salesDAO = _salesDAO;
            carritoDAO = _carritoDAO;
        }

        // GET: SalesController
        public ActionResult IndexSales()
        {
            var listado = salesDAO.ListarVentas();
            return View(listado);
        }

        // GET: SalesController/CreateSale
        public ActionResult CreateSale()
        {
            var carrito = carritoDAO.ListarCarrito();
            if (carrito.Count == 0)
            {
                TempData["mensaje"] = "No hay productos en el carrito para procesar una venta.";
                return RedirectToAction("IndexCarrito");
            }
            ViewBag.Carrito = carrito; // Pasar el carrito a la vista
            return View();
        }

        // POST: SalesController/CreateSale
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSale(string firstName, string lastName, string cardNumber, DateTime cardExpiry, string cardCVV, string address)
        {
            try
            {
                var carrito = carritoDAO.ListarCarrito();
                if (carrito.Count == 0)
                {
                    TempData["mensaje"] = "No hay productos en el carrito para procesar una venta.";
                    return RedirectToAction("IndexSales");
                }

                // Registrar la venta
                string mensaje = salesDAO.RegistrarVenta(carrito, firstName, lastName, cardNumber, cardExpiry, cardCVV, address);

                TempData["mensaje"] = mensaje;
                return RedirectToAction("IndexSales");
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = "Error al procesar la venta: " + ex.Message;
                return View();
            }
        }
    }
}
