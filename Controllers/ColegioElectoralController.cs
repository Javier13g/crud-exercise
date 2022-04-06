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
    public class ColegioElectoralController : Controller
    {
        private DSFEBABR2022Context db = new DSFEBABR2022Context();

        private readonly INotyfService _notyf;
        public ColegioElectoralController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        // GET: ColegioElectroralControler
        public ActionResult Index()
        {
            return View(db.ColegioElectorals.ToList());
        }

        // GET: ColegioElectroralControler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colegioElectoral = db.ColegioElectorals
                .FirstOrDefault(m => m.Id == id);
            if (colegioElectoral == null)
            {
                return NotFound();
            }

            return View(colegioElectoral);
        }

        // GET: ColegioElectroralControler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColegioElectroralControler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Codigo,Nombre,Descripcion,Direccion,Telefono,MunicipioId,SectorId,Estado,FechaCreacion")] ColegioElectoral colegioElectoral)
        {
            if (ModelState.IsValid)
            {
                db.Add(colegioElectoral);
                db.SaveChanges();
                _notyf.Success("Dato agregado");
                return RedirectToAction("Index");
            }
            return View(colegioElectoral);
        }

        // GET: ColegioElectroralControler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colegioElectoral = db.ColegioElectorals.Find(id);
            if (colegioElectoral == null)
            {
                return NotFound();
            }
            return View(colegioElectoral);
        }

        // POST: ColegioElectroralControler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Codigo,Nombre,Descripcion,Direccion,Telefono,MunicipioId,SectorId,Estado,FechaCreacion")] ColegioElectoral colegioElectoral)
        {
            if (id != colegioElectoral.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(colegioElectoral);
                    _notyf.Success("Dato editado");
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColegioElectoralExists(colegioElectoral.Id))
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
            return View(colegioElectoral);
        }

        // GET: ColegioElectroralControler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colegioElectoral = db.ColegioElectorals
                .FirstOrDefault(m => m.Id == id);
            if (colegioElectoral == null)
            {
                return NotFound();
            }

            return View(colegioElectoral);
        }

        // POST: ColegioElectroralControler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var colegioElectoral = db.ColegioElectorals.Find(id);
            db.ColegioElectorals.Remove(colegioElectoral);
            _notyf.Success("Dato Eliminado");
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool ColegioElectoralExists(int id)
        {
            return db.ColegioElectorals.Any(e => e.Id == id);
        }
    }
}
