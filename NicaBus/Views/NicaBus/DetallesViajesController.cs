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
    public class DetallesViajesController : Controller
    {
        private readonly NicaBusContext _context;

        public DetallesViajesController(NicaBusContext context)
        {
            _context = context;
        }

        // GET: DetallesViajes
        public async Task<IActionResult> Index()
        {
              return View(await _context.DetallesViaje.ToListAsync());
        }

        // GET: DetallesViajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetallesViaje == null)
            {
                return NotFound();
            }

            var detallesViaje = await _context.DetallesViaje
                .FirstOrDefaultAsync(m => m.id == id);
            if (detallesViaje == null)
            {
                return NotFound();
            }

            return View(detallesViaje);
        }

        // GET: DetallesViajes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetallesViajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,acountId,nameBus,lugarEstacionamiento,costo,horaSalida,horaLlegada,destino,idDestino")] DetallesViaje detallesViaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallesViaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detallesViaje);
        }

        // GET: DetallesViajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetallesViaje == null)
            {
                return NotFound();
            }

            var detallesViaje = await _context.DetallesViaje.FindAsync(id);
            if (detallesViaje == null)
            {
                return NotFound();
            }
            return View(detallesViaje);
        }

        // POST: DetallesViajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,acountId,nameBus,lugarEstacionamiento,costo,horaSalida,horaLlegada,destino,idDestino")] DetallesViaje detallesViaje)
        {
            if (id != detallesViaje.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesViaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesViajeExists(detallesViaje.id))
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
            return View(detallesViaje);
        }

        // GET: DetallesViajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetallesViaje == null)
            {
                return NotFound();
            }

            var detallesViaje = await _context.DetallesViaje
                .FirstOrDefaultAsync(m => m.id == id);
            if (detallesViaje == null)
            {
                return NotFound();
            }

            return View(detallesViaje);
        }

        // POST: DetallesViajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetallesViaje == null)
            {
                return Problem("Entity set 'NicaBusContext.DetallesViaje'  is null.");
            }
            var detallesViaje = await _context.DetallesViaje.FindAsync(id);
            if (detallesViaje != null)
            {
                _context.DetallesViaje.Remove(detallesViaje);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesViajeExists(int id)
        {
          return _context.DetallesViaje.Any(e => e.id == id);
        }
    }
}
