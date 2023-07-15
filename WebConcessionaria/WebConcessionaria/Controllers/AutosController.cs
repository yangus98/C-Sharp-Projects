using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using WebConcessionaria.Models;

namespace WebConcessionaria.Controllers
{
    public class AutosController : Controller
    {
        private readonly AutoContext _context;
        private readonly ILogger<HomeController> _logger;

        public AutosController(AutoContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Autos
        public async Task<IActionResult> Index(string modello, int? prezzo_da, int? prezzo_a, int pageindex = 1)
        {
            var tutti = await _context.Autos.ToListAsync();

            if (modello != null)
                tutti = tutti.Where(c => c.Modello.Contains(modello)).ToList();

            if (prezzo_da.HasValue)
                tutti = tutti.Where(c => c.Prezzo >= prezzo_da).ToList();

            if (prezzo_a.HasValue)
                tutti = tutti.Where(c => c.Prezzo <= prezzo_a).ToList();

            var model = PagingList.Create(tutti, 5, pageindex);

            return View(model);
        }

            // GET: Autos/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autos == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // GET: Autos/Create
        public IActionResult Create()
        {
            _logger.LogError("Auto creata!!!");
            return View();
        }

        // POST: Autos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Auto auto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auto);
        }

        // GET: Autos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autos == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }
            return View(auto);
        }

        // POST: Autos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Auto auto)
        {
            if (id != auto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoExists(auto.Id))
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
            return View(auto);
        }

        // GET: Autos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null || _context.Autos == null)
            {

                return NotFound();
            }

            var auto = await _context.Autos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auto == null)
            {
                return NotFound();
            }
            _logger.LogError("Auto cancellata!!!");
            return View(auto);
        }

        // POST: Autos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autos == null)
            {
                return Problem("Entity set 'AutoContext.Autos'  is null.");
            }
            var auto = await _context.Autos.FindAsync(id);
            if (auto != null)
            {
                _context.Autos.Remove(auto);
            }

            await _context.SaveChangesAsync();
            _logger.LogError("Auto cancellata!!!");
            return RedirectToAction(nameof(Index));
        }

        private bool AutoExists(int id)
        {
          return (_context.Autos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
