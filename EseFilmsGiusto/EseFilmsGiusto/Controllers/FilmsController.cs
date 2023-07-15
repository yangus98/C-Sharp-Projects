﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EseFilms.Models;

namespace EseFilmsGiusto.Controllers
{
    public class FilmsController : Controller
    {
        private readonly FilmContext _context;

        public FilmsController(FilmContext context)
        {
            _context = context;
        }

        // GET: Films
        public async Task<IActionResult> Index()
        {
              return _context.Films != null ? 
                          View(await _context.Films.ToListAsync()) :
                          Problem("Entity set 'FilmContext.Films'  is null.");
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Film film)
        {
            if (ModelState.IsValid)
            {
                // Salvo il file
                // Dall'oggetto FileImmagine prendo il nome  e lo copio nella proprietà immagine
                // Devo però mettere un prefisso all'immagine, un qualcosa di casuale
                string nomeFile = Guid.NewGuid().ToString() + "_" + film.FileLocandina.FileName;
                film.NomeLocandina = nomeFile;
                _context.Add(film);
                await _context.SaveChangesAsync();
                // Ho salvato la riga, ora devo salvare il file!
                string path = Directory.GetCurrentDirectory() + @"\wwwroot\immagini\" + nomeFile;
                // ma questa sopra non funziona sotto Linux!
                // La 'Combine' però aggancia le directory col giusto separatore, a second ase Linux  o Win
                string pathFile = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "immagini", nomeFile);
                var stream = new FileStream(pathFile, FileMode.Create);
                film.FileLocandina.CopyTo(stream);
                stream.Close();

                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Ho scelto un immagine nuova? Se si, salvo al posto della vecchia
                    if (film.FileLocandina != null)
                    {
                        // Cancello quella vecchia
                        string OldImg = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot", "immagini", film.NomeLocandina);
                        System.IO.File.Delete(OldImg);
                        // Sostituisco quella nuova
                        string nomeFile = Guid.NewGuid().ToString() + "_" + film.FileLocandina.FileName;
                        film.NomeLocandina = nomeFile;
                        string pathFile = Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot", "immagini", nomeFile);
                        var stream = new FileStream(pathFile, FileMode.Create);
                        film.FileLocandina.CopyTo(stream);
                        stream.Close();
                    }
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Id))
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
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Films == null)
            {
                return Problem("Entity set 'FilmContext.Films'  is null.");
            }
            var film = await _context.Films.FindAsync(id);
            if (film != null)
            {
                _context.Films.Remove(film);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
          return (_context.Films?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
