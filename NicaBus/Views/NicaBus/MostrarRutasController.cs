using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NicaBus.Data;
using NicaBus.Models;

namespace NicaBus.Views.NicaBus
{
    public class MostrarRutasController : Controller
    {
        private readonly NicaBusContext _context;

        public MostrarRutasController(NicaBusContext context)
        {
            _context = context;
        }

        // GET: MostrarRutas
        public async Task<IActionResult> Index()
        {
              return View(await _context.MostrarRuta.ToListAsync());
        }

        // GET: MostrarRutas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MostrarRuta == null)
            {
                return NotFound();
            }

            var mostrarRuta = await _context.MostrarRuta
                .FirstOrDefaultAsync(m => m.id == id);
            if (mostrarRuta == null)
            {
                return NotFound();
            }

            return View(mostrarRuta);
        }

        // GET: MostrarRutas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MostrarRutas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ubicacionActual,destino,idDestino")] MostrarRuta mostrarRuta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mostrarRuta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mostrarRuta);
        }

        // GET: MostrarRutas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MostrarRuta == null)
            {
                return NotFound();
            }

            var mostrarRuta = await _context.MostrarRuta.FindAsync(id);
            if (mostrarRuta == null)
            {
                return NotFound();
            }
            return View(mostrarRuta);
        }

        // POST: MostrarRutas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ubicacionActual,destino,idDestino")] MostrarRuta mostrarRuta)
        {
            if (id != mostrarRuta.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mostrarRuta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MostrarRutaExists(mostrarRuta.id))
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
            return View(mostrarRuta);
        }

        // GET: MostrarRutas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MostrarRuta == null)
            {
                return NotFound();
            }

            var mostrarRuta = await _context.MostrarRuta
                .FirstOrDefaultAsync(m => m.id == id);
            if (mostrarRuta == null)
            {
                return NotFound();
            }

            return View(mostrarRuta);
        }

        // POST: MostrarRutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MostrarRuta == null)
            {
                return Problem("Entity set 'NicaBusContext.MostrarRuta'  is null.");
            }
            var mostrarRuta = await _context.MostrarRuta.FindAsync(id);
            if (mostrarRuta != null)
            {
                _context.MostrarRuta.Remove(mostrarRuta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MostrarRutaExists(int id)
        {
          return _context.MostrarRuta.Any(e => e.id == id);
        }
    }
}
