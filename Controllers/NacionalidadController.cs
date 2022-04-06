using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crud.Models;

namespace crud.Controllers
{
    public class NacionalidadController : Controller
    {
        private DSFEBABR2022Context db = new DSFEBABR2022Context();

        // GET: Nacionalidad
        public ActionResult Index()
        {
            return View(db.Nacionalidads.ToList());
        }

        // GET: Nacionalidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidad = db.Nacionalidads
                .FirstOrDefault(m => m.Id == id);
            if (nacionalidad == null)
            {
                return NotFound();
            }

            return View(nacionalidad);
        }

        // GET: Nacionalidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nacionalidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Nombre,Descripcion,Estado,FechaCreacion")] Nacionalidad nacionalidad)
        {
            if (ModelState.IsValid)
            {
                db.Add(nacionalidad);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nacionalidad);
        }

        // GET: Nacionalidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidad = db.Nacionalidads.Find(id);
            if (nacionalidad == null)
            {
                return NotFound();
            }

            return View(nacionalidad);
        }

        // POST: Nacionalidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Nombre,Descripcion,Estado,FechaCreacion")] Nacionalidad nacionalidad)
        {
            if (id != nacionalidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(nacionalidad);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NacionalidadExists(nacionalidad.Id))
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

            return View(nacionalidad);
        }

        // GET: Nacionalidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacionalidad = db.Nacionalidads
                .FirstOrDefault(m => m.Id == id);
            if (nacionalidad == null)
            {
                return NotFound();
            }

            return View(nacionalidad);
        }

        // POST: Nacionalidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var nacionalidad = db.Nacionalidads.Find(id);
            db.Nacionalidads.Remove(nacionalidad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool NacionalidadExists(int id)
        {
            return db.Nacionalidads.Any(e => e.Id == id);
        }
    }
}