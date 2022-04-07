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
    public class IncidentPagesController : Controller
    {
        private readonly GBCContext _context;

        public IncidentPagesController(GBCContext context)
        {
            _context = context;
        }

        // GET: IncidentPages
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncidentPage.ToListAsync());
        }

        // GET: IncidentPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentPage = await _context.IncidentPage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incidentPage == null)
            {
                return NotFound();
            }

            return View(incidentPage);
        }

        // GET: IncidentPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncidentPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,Title,Description,TechName,DateOpened,DateClosed")] IncidentPage incidentPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidentPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incidentPage);
        }

        // GET: IncidentPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentPage = await _context.IncidentPage.FindAsync(id);
            if (incidentPage == null)
            {
                return NotFound();
            }
            return View(incidentPage);
        }

        // POST: IncidentPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product,Title,Description,TechName,DateOpened,DateClosed")] IncidentPage incidentPage)
        {
            if (id != incidentPage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidentPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentPageExists(incidentPage.Id))
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
            return View(incidentPage);
        }

        // GET: IncidentPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentPage = await _context.IncidentPage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incidentPage == null)
            {
                return NotFound();
            }

            return View(incidentPage);
        }

        // POST: IncidentPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incidentPage = await _context.IncidentPage.FindAsync(id);
            _context.IncidentPage.Remove(incidentPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentPageExists(int id)
        {
            return _context.IncidentPage.Any(e => e.Id == id);
        }
    }
}
