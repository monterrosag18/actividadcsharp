using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimeEventsWeb.Data;
using AnimeEventsWeb.Models;

namespace AnimeEventsWeb.Controllers
{
    // Controlador para gestionar el CRUD completo de Eventos
    public class EventAdminController : Controller
    {
        private readonly AppDbContext _context;

        public EventAdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EventAdmin (Listado administrativo)
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events);
        }

        // GET: EventAdmin/Create (Formulario de creación)
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventAdmin/Create
        [HttpPost]
        public async Task<IActionResult> Create(Event ev)
        {
            // Nota: El usuario no requiere validaciones estrictas.
            _context.Add(ev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: EventAdmin/Edit/5 (Formulario de edición)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();

            return View(ev);
        }

        // POST: EventAdmin/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Event ev)
        {
            if (id != ev.Id) return NotFound();

            try
            {
                _context.Update(ev);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(ev.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EventAdmin/Delete/5 (Formulario de eliminación)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var ev = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            if (ev == null) return NotFound();

            return View(ev);
        }

        // POST: EventAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev != null)
            {
                _context.Events.Remove(ev);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
