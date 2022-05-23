using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vietjet.com.Data;
using Vietjet.com.Models;

namespace Vietjet.com.Controllers
{
    public class baysController : Controller
    {
        private readonly VietjetcomContext _context;

        public baysController(VietjetcomContext context)
        {
            _context = context;
        }

        // GET: bays
        public async Task<IActionResult> Index(string bayGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.bay
                                            orderby b.Genre
                                            select b.Genre;
            var bays = from b in _context.bay
                        select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                bays = bays.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(bayGenre))
            {
                bays = bays.Where(x => x.Genre == bayGenre);
            }
            var baysGenreVM = new baysGenreViewModel
            {
                Genres = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                bays = await bays.ToListAsync()
            };
            return View(baysGenreVM);
        }
        public async Task<IActionResult> ad(string bayGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.bay
                                            orderby b.Genre
                                            select b.Genre;
            var bays = from b in _context.bay
                       select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                bays = bays.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(bayGenre))
            {
                bays = bays.Where(x => x.Genre == bayGenre);
            }
            var baysGenreVM = new baysGenreViewModel
            {
                Genres = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                bays = await bays.ToListAsync()
            };
            return View(baysGenreVM);
        }

        // GET: bays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bay = await _context.bay
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bay == null)
            {
                return NotFound();
            }

            return View(bay);
        }

        // GET: bays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: bays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] bay bay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bay);
        }

        // GET: bays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bay = await _context.bay.FindAsync(id);
            if (bay == null)
            {
                return NotFound();
            }
            return View(bay);
        }

        // POST: bays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] bay bay)
        {
            if (id != bay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bayExists(bay.Id))
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
            return View(bay);
        }

        // GET: bays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bay = await _context.bay
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bay == null)
            {
                return NotFound();
            }

            return View(bay);
        }

        // POST: bays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bay = await _context.bay.FindAsync(id);
            _context.bay.Remove(bay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bayExists(int id)
        {
            return _context.bay.Any(e => e.Id == id);
        }
    }
}
