using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapaENT;
using EjercicioAzure.Data;

namespace EjercicioAzure.Controllers
{
    public class PersonasController : Controller
    {
        private readonly EjercicioAzureContext _context;

        public PersonasController(EjercicioAzureContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personas.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsPersona = await _context.Personas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clsPersona == null)
            {
                return NotFound();
            }

            return View(clsPersona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellidos,Telefono,Direccion,Foto,FechaNac,IdDept")] ClsPersona clsPersona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clsPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clsPersona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsPersona = await _context.Personas.FindAsync(id);
            if (clsPersona == null)
            {
                return NotFound();
            }
            return View(clsPersona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellidos,Telefono,Direccion,Foto,FechaNac,IdDept")] ClsPersona clsPersona)
        {
            if (id != clsPersona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clsPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClsPersonaExists(clsPersona.Id))
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
            return View(clsPersona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clsPersona = await _context.Personas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clsPersona == null)
            {
                return NotFound();
            }

            return View(clsPersona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clsPersona = await _context.Personas.FindAsync(id);
            if (clsPersona != null)
            {
                _context.Personas.Remove(clsPersona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClsPersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}
