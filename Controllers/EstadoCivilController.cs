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
    public class EstadoCivilController : Controller
    {
        private DSFEBABR2022Context db = new DSFEBABR2022Context();
        private readonly INotyfService _notyf;
        public EstadoCivilController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        // GET: EstadoCivil
        public ActionResult Index()
        {
            return View(db.EstadoCivils.ToList());
        }

        // GET: EstadoCivil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoCivil = db.EstadoCivils
                .FirstOrDefault(m => m.Id == id);
            if (estadoCivil == null)
            {
                return NotFound();
            }

            return View(estadoCivil);
        }

        // GET: EstadoCivil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoCivil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Nombre,Descripcion,Estado,FechaCreacion")] EstadoCivil estadoCivil)
        {
            if (ModelState.IsValid)
            {
                db.Add(estadoCivil);
                db.SaveChanges();
                _notyf.Success("Dato agregado");
                return RedirectToAction("Index");
            }
            return View(estadoCivil);
        }

        // GET: EstadoCivil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoCivil =  db.EstadoCivils.Find(id);
            if (estadoCivil == null)
            {
                return NotFound();
            }
            return View(estadoCivil);
        }

        // POST: EstadoCivil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Nombre,Descripcion,Estado,FechaCreacion")] EstadoCivil estadoCivil)
        {
            if (id != estadoCivil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(estadoCivil);
                    _notyf.Success("Dato editado");
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoCivilExists(estadoCivil.Id))
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
            return View(estadoCivil);
        }

        // GET: EstadoCivil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoCivil = db.EstadoCivils
                .FirstOrDefault(m => m.Id == id);
            if (estadoCivil == null)
            {
                return NotFound();
            }

            return View(estadoCivil);
        }

        // POST: EstadoCivil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var estadoCivil = db.EstadoCivils.Find(id);
            db.EstadoCivils.Remove(estadoCivil);
            _notyf.Success("Dato eliminado");
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool EstadoCivilExists(int id)
        {
            return db.EstadoCivils.Any(e => e.Id == id);
        }
    }
}
