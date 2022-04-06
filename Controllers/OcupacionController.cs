using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crud.Models;

namespace crud.Controllers
{
    public class OcupacionController : Controller
    {
        private DSFEBABR2022Context db = new DSFEBABR2022Context();
        
        private readonly INotyfService _notyf;
        public OcupacionController(INotyfService notyf)
        {
            _notyf = notyf;
        }
        // GET: Ocupacion
        public ActionResult Index()
        {
            return View(db.Ocupacions.ToList());
        }

        // GET: Ocupacion/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocupacion = db.Ocupacions
                .FirstOrDefault(m => m.Id == id);
            if (ocupacion == null)
            {
                return NotFound();
            }

            return View(ocupacion);
        }

        // GET: Ocupacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ocupacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Nombre,Descripcion,Estado,FechaCreacion")] Ocupacion ocupacion)
        {
            if (ModelState.IsValid)
            {
                db.Add(ocupacion);
                db.SaveChanges();
                _notyf.Success("Ocupacion agregada");
                return RedirectToAction("Index");
            }
            return View(ocupacion);
        }

        // GET: Ocupacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocupacion = db.Ocupacions.Find(id);
            if (ocupacion == null)
            {
                return NotFound();
            }
            return View(ocupacion);
        }

        // POST: Ocupacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Nombre,Descripcion,Estado,FechaCreacion")] Ocupacion ocupacion)
        {
            if (id != ocupacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(ocupacion);
                    db.SaveChanges();
                    _notyf.Success("Ocupacion Editada");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OcupacionExists(ocupacion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ocupacion);
        }

        // GET: Ocupacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ocupacion = db.Ocupacions
                .FirstOrDefault(m => m.Id == id);
            if (ocupacion == null)
            {
                return NotFound();
            }

            return View(ocupacion);
        }

        // POST: Ocupacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var ocupacion = db.Ocupacions.Find(id);
            db.Ocupacions.Remove(ocupacion);
            db.SaveChanges();
            _notyf.Success("Ocupacion Eliminada");
            return RedirectToAction(nameof(Index));
        }

        private bool OcupacionExists(int id)
        {
            return db.Ocupacions.Any(e => e.Id == id);
        } 
    }
}
