using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaIdentityUltima.Data;
using BibliotecaIdentityUltima.Models;

namespace BibliotecaIdentityUltima.Controllers
{
    public class EditoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EditoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Editores
        public async Task<IActionResult> Index()
        {
              return _context.Editori != null ? 
                          View(await _context.Editori.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Editori'  is null.");
        }

        // GET: Editores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Editori == null)
            {
                return NotFound();
            }

            var editore = await _context.Editori
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editore == null)
            {
                return NotFound();
            }

            return View(editore);
        }

        // GET: Editores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Editore editore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editore);
        }

        // GET: Editores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Editori == null)
            {
                return NotFound();
            }

            var editore = await _context.Editori.FindAsync(id);
            if (editore == null)
            {
                return NotFound();
            }
            return View(editore);
        }

        // POST: Editores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Editore editore)
        {
            if (id != editore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditoreExists(editore.Id))
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
            return View(editore);
        }

        // GET: Editores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Editori == null)
            {
                return NotFound();
            }

            var editore = await _context.Editori
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editore == null)
            {
                return NotFound();
            }

            return View(editore);
        }

        // POST: Editores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Editori == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Editori'  is null.");
            }
            var editore = await _context.Editori.FindAsync(id);
            if (editore != null)
            {
                _context.Editori.Remove(editore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditoreExists(int id)
        {
          return (_context.Editori?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
