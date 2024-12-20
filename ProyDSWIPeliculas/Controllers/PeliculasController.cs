using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProyDSWIPeliculas.DAO;
using ProyDSWIPeliculas.Models;


namespace ProyDSWIPeliculas.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly PeliculasDAO dao;

        public PeliculasController(PeliculasDAO _dao)
        {
            dao = _dao;
        }

        // GET: PeliculasController
        public ActionResult IndexPeliculas()
        {
            var listado = dao.ListarPeliculas();
            //
            return View(listado);
        }

        // GET: PeliculasController/Details/5
        public ActionResult DetailsPeliculas(int id)
        {
            return View(dao.BuscarPelicula(id));
        }

        // GET: PeliculasController/Create
        public ActionResult CreatePeliculas()
        {

            Peliculas nuevo = new Peliculas();

            ViewBag.idiomas = new SelectList(
                dao.traerIdiomas(), "cod_idio", "nom_idio");
            //
            return View();

        }

        // GET: PeliculasController/Edit/5
        public ActionResult EditPelicula(int id)
        {
            var pelicula = dao.BuscarPelicula(id);
            if (pelicula == null)
            {
                TempData["mensaje"] = "Película no encontrada.";
                return RedirectToAction(nameof(IndexPeliculas));
            }

            ViewBag.idiomas = new SelectList(
                dao.traerIdiomas(), "cod_idio", "nom_idio");
            //
            return View(pelicula);

        }

        // POST: PeliculasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPelicula(Peliculas obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["mensaje"] =
                        dao.GrabarPeliculas(obj, 2);
                }
                return RedirectToAction(nameof(IndexPeliculas));
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            //
            ViewBag.idiomas = new SelectList(
                 dao.traerIdiomas(), "cod_idio", "nom_idio");
            //
            return View(obj);

        }

        // POST: PeliculasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePeliculas(Peliculas obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["mensaje"] =
                        dao.GrabarPeliculas(obj, 1);
                }
                return RedirectToAction(nameof(IndexPeliculas));
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            //
            ViewBag.idiomas = new SelectList(
                 dao.traerIdiomas(), "cod_idio", "nom_idio");
            //
            return View(obj);

        }

        public ActionResult Delete(int id)
        {
            TempData["mensaje"] = dao.EliminarPelicula(id);

            return RedirectToAction(nameof(IndexPeliculas));
         }

      
    }
}
