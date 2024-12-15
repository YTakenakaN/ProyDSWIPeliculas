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

        // GET: PeliculasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeliculasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeliculasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeliculasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
