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
    public class MunicipioController : Controller
    {
        private DSFEBABR2022Context db = new DSFEBABR2022Context();
        private readonly INotyfService _notyf;
        public MunicipioController(INotyfService notyf)
        {
            _notyf = notyf;
        }
        // GET: Municipio
        public ActionResult Index()
        {
            var dSFEBABR2022Context = db.Municipios.Include(m => m.Provincia);
            return View( dSFEBABR2022Context.ToList());
        }

        // GET: Municipio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = db.Municipios
                .Include(m => m.Provincia)
                .FirstOrDefault(m => m.Id == id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // GET: Municipio/Create
        public IActionResult Create()
        {
            ViewData["ProvinciaId"] = new SelectList(db.Provincia, "Id", "Nombre");
            return View();
        }

        // POST: Municipio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,ProvinciaId,Nombre,Descripcion,Estado,FechaCreacion")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Add(municipio);
                _notyf.Success("Municipio agregado");
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["ProvinciaId"] = new SelectList(db.Provincia, "Id", "Nombre", municipio.ProvinciaId);
            return View(municipio);
        }

        // GET: Municipio/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return NotFound();
            }
            ViewData["ProvinciaId"] = new SelectList(db.Provincia, "Id", "Nombre", municipio.ProvinciaId);
            return View(municipio);
        }

        // POST: Municipio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,ProvinciaId,Nombre,Descripcion,Estado,FechaCreacion")] Municipio municipio)
        {
            if (id != municipio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(municipio);
                    db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipioExists(municipio.Id))
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
            ViewData["ProvinciaId"] = new SelectList(db.Provincia, "Id", "Nombre", municipio.ProvinciaId);
            return View(municipio);
        }

        // GET: Municipio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = db.Municipios
                .Include(m => m.Provincia)
                .FirstOrDefault(m => m.Id == id);
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // POST: Municipio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var municipio = db.Municipios.Find(id);
            db.Municipios.Remove(municipio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool MunicipioExists(int id)
        {
            return db.Municipios.Any(e => e.Id == id);
        }
    }
}
