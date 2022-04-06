using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crud.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace crud.Controllers
{
    public class CiudadanoEstadoController : Controller
    {
        private DSFEBABR2022Context db = new DSFEBABR2022Context();

        private readonly INotyfService _notyf;
        public CiudadanoEstadoController(INotyfService notyf)
        {
            _notyf = notyf;
        }
        
        // GET: CiudadanoEstado
        public ActionResult Index()
        {
            return View(db.CiudadanoEstados.ToList());
        }

        // GET: CiudadanoEstado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudadanoEstado = db.CiudadanoEstados
                .FirstOrDefault(m => m.Id == id);
            if (ciudadanoEstado == null)
            {
                return NotFound();
            }

            return View(ciudadanoEstado);
        }

        // GET: CiudadanoEstado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CiudadanoEstado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Nombre,Descripcion,Estado,FechaCreacion")] CiudadanoEstado ciudadanoEstado)
        {
            if (ModelState.IsValid)
            {
                db.Add(ciudadanoEstado);
                db.SaveChanges();
                _notyf.Success("Dato agregado");
                return RedirectToAction("Index");
            }
            return View(ciudadanoEstado);
        }

        // GET: CiudadanoEstado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudadanoEstado = db.CiudadanoEstados.Find(id);
            if (ciudadanoEstado == null)
            {
                return NotFound();
            }
            return View(ciudadanoEstado);
        }

        // POST: CiudadanoEstado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Nombre,Descripcion,Estado,FechaCreacion")] CiudadanoEstado ciudadanoEstado)
        {
            if (id != ciudadanoEstado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(ciudadanoEstado);
                    _notyf.Success("Dato editado");
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiudadanoEstadoExists(ciudadanoEstado.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(ciudadanoEstado);
        }

        // GET: CiudadanoEstado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudadanoEstado = db.CiudadanoEstados
                .FirstOrDefault(m => m.Id == id);
            if (ciudadanoEstado == null)
            {
                return NotFound();
            }

            return View(ciudadanoEstado);
        }

        // POST: CiudadanoEstado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var ciudadanoEstado = db.CiudadanoEstados.Find(id);
            db.CiudadanoEstados.Remove(ciudadanoEstado);
            db.SaveChanges();
            _notyf.Success("Dato eliminado");
            return RedirectToAction("Index");
        }

        private bool CiudadanoEstadoExists(int id)
        {
            return db.CiudadanoEstados.Any(e => e.Id == id);
        }
    }
}
