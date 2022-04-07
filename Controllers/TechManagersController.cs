#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GBC.Data;
using GBC.Models;

namespace GBC.Controllers
{
    public class TechManagersController : Controller
    {
        private readonly GBCContext _context;

        public TechManagersController(GBCContext context)
        {
            _context = context;
        }

        // GET: TechManagers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TechManager.ToListAsync());
        }

        // GET: TechManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techManager = await _context.TechManager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (techManager == null)
            {
                return NotFound();
            }

            return View(techManager);
        }

        // GET: TechManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TechManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TechName,TechEmail,TechPhone")] TechManager techManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(techManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(techManager);
        }

        // GET: TechManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techManager = await _context.TechManager.FindAsync(id);
            if (techManager == null)
            {
                return NotFound();
            }
            return View(techManager);
        }

        // POST: TechManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TechName,TechEmail,TechPhone")] TechManager techManager)
        {
            if (id != techManager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(techManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechManagerExists(techManager.Id))
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
            return View(techManager);
        }

        // GET: TechManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techManager = await _context.TechManager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (techManager == null)
            {
                return NotFound();
            }

            return View(techManager);
        }

        // POST: TechManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var techManager = await _context.TechManager.FindAsync(id);
            _context.TechManager.Remove(techManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechManagerExists(int id)
        {
            return _context.TechManager.Any(e => e.Id == id);
        }
    }
}
