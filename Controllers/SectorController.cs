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
    public class SectorController : Controller
    {
        private DSFEBABR2022Context db = new DSFEBABR2022Context();

        // GET: Sector
        public ActionResult Index()
        {
            var dSFEBABR2022Context = db.Sectors.Include(s => s.Municipio);
            return View( dSFEBABR2022Context.ToList());
        }

        // GET: Sector/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = db.Sectors
                .Include(s => s.Municipio)
                .FirstOrDefault(m => m.Id == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // GET: Sector/Create
        public ActionResult Create()
        {
            ViewData["MunicipioId"] = new SelectList(db.Municipios, "Id", "Nombre");
            return View();
        }

        // POST: Sector/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,MunicipioId,Nombre,Descripcion,Estado,FechaCreacion")] Sector sector)
        {
            if (ModelState.IsValid)
            {
                db.Add(sector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["MunicipioId"] = new SelectList(db.Municipios, "Id", "Nombre", sector.MunicipioId);
            return View(sector);
        }

        // GET: Sector/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = db.Sectors.Find(id);
            if (sector == null)
            {
                return NotFound();
            }
            ViewData["MunicipioId"] = new SelectList(db.Municipios, "Id", "Nombre", sector.MunicipioId);
            return View(sector);
        }

        // POST: Sector/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,MunicipioId,Nombre,Descripcion,Estado,FechaCreacion")] Sector sector)
        {
            if (id != sector.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(sector);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectorExists(sector.Id))
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
            ViewData["MunicipioId"] = new SelectList(db.Municipios, "Id", "Nombre", sector.MunicipioId);
            return View(sector);
        }

        // GET: Sector/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = db.Sectors
                .Include(s => s.Municipio)
                .FirstOrDefault(m => m.Id == id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        // POST: Sector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var sector = db.Sectors.Find(id);
            db.Sectors.Remove(sector);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool SectorExists(int id)
        {
            return db.Sectors.Any(e => e.Id == id);
        }
    }
}
