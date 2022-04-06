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
    public class TipoSangreController : Controller
    {
        private readonly DSFEBABR2022Context db = new DSFEBABR2022Context();
        // GET: TipoSangre
        public ActionResult Index()
        {
            return View( db.TipoDeSangres.ToList());
        }

        // GET: TipoSangre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeSangre = db.TipoDeSangres
                .FirstOrDefault(m => m.Id == id);
            if (tipoDeSangre == null)
            {
                return NotFound();
            }

            return View(tipoDeSangre);
        }

        // GET: TipoSangre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoSangre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Nombre,Descripcion,Estado,FechaCreacion")] TipoDeSangre tipoDeSangre)
        {
            if (ModelState.IsValid)
            {
                db.Add(tipoDeSangre);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoDeSangre);
        }

        // GET: TipoSangre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeSangre = db.TipoDeSangres.Find(id);
            if (tipoDeSangre == null)
            {
                return NotFound();
            }
            return View(tipoDeSangre);
        }

        // POST: TipoSangre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Nombre,Descripcion,Estado,FechaCreacion")] TipoDeSangre tipoDeSangre)
        {
            if (id != tipoDeSangre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tipoDeSangre); 
                    db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeSangreExists(tipoDeSangre.Id))
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
            return View(tipoDeSangre);
        }

        // GET: TipoSangre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeSangre = db.TipoDeSangres
                .FirstOrDefault(m => m.Id == id);
            if (tipoDeSangre == null)
            {
                return NotFound();
            }

            return View(tipoDeSangre);
        }

        // POST: TipoSangre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tipoDeSangre = db.TipoDeSangres.Find(id);
            db.TipoDeSangres.Remove(tipoDeSangre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool TipoDeSangreExists(int id)
        {
            return db.TipoDeSangres.Any(e => e.Id == id);
        }
    }
}
