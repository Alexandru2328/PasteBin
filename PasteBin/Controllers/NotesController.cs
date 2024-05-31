using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PasteBin.Data;
using PasteBin.Models;

namespace PasteBin.Controllers
{
    public class NotesController : Controller
    {
        private readonly PasteBinContext _context;

        public NotesController(PasteBinContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Notes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var notes = await _context.Notes.FirstOrDefaultAsync(m => m.Id == id);
            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Notes notes)
        {
            _context.Add(notes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    
        public async Task<IActionResult> Edit(int? id)
        {
            var notes = await _context.Notes.FindAsync(id);
            return View(notes);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Notes notes)
        {
            _context.Update(notes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var notes = await _context.Notes.FirstOrDefaultAsync(m => m.Id == id);
            return View(notes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notes = await _context.Notes.FindAsync(id);
            _context.Notes.Remove(notes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotesExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
    }
}
