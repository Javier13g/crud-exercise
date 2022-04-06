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
    public class ProvinciaController : Controller
    {
        private DSFEBABR2022Context db = new DSFEBABR2022Context();

        private readonly INotyfService _notyf;
        public ProvinciaController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        // GET: Provincia
        public ActionResult Index()
        {
            return View( db.Provincia.ToList());
        }

        // GET: Provincia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincium = db.Provincia
                .FirstOrDefault(m => m.Id == id);
            if (provincium == null)
            {
                return NotFound();
            }

            return View(provincium);
        }

        // GET: Provincia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provincia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Nombre,Descripcion,Estado,FechaCreacion")] Provincium provincium)
        {
            if (ModelState.IsValid)
            {
                db.Add(provincium);
                db.SaveChanges();
                _notyf.Success("Provincia agregada");
                return RedirectToAction("Index");
            }
            return View(provincium);
        }

        // GET: Provincia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincium =  db.Provincia.Find(id);
            if (provincium == null)
            {
                return NotFound();
            }
            return View(provincium);
        }

        // POST: Provincia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Nombre,Descripcion,Estado,FechaCreacion")] Provincium provincium)
        {
            if (id != provincium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(provincium);
                    _notyf.Success("Provincia editada");
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinciumExists(provincium.Id))
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
            return View(provincium);
        }

        // GET: Provincia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincium = db.Provincia
                .FirstOrDefault(m => m.Id == id);
            if (provincium == null)
            {
                return NotFound();
            }

            return View(provincium);
        }

        // POST: Provincia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var provincium = db.Provincia.Find(id);
            db.Provincia.Remove(provincium);
            _notyf.Success("Provincia eliminada");
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool ProvinciumExists(int id)
        {
            return db.Provincia.Any(e => e.Id == id);
        }
    }
}
