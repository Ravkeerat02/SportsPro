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
    public class CustomerManagersController : Controller
    {
        private readonly GBCContext _context;

        public CustomerManagersController(GBCContext context)
        {
            _context = context;
        }

        // GET: CustomerManagers
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerManager.ToListAsync());
        }

        // GET: CustomerManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerManager = await _context.CustomerManager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerManager == null)
            {
                return NotFound();
            }

            return View(customerManager);
        }

        // GET: CustomerManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName,CustomerAddress,CustomerCity,CustomerState,CustomerPostal,Country,CustomerEmail,CustomerPhone")] CustomerManager customerManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerManager);
        }

        // GET: CustomerManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerManager = await _context.CustomerManager.FindAsync(id);
            if (customerManager == null)
            {
                return NotFound();
            }
            return View(customerManager);
        }

        // POST: CustomerManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,CustomerAddress,CustomerCity,CustomerState,CustomerPostal,Country,CustomerEmail,CustomerPhone")] CustomerManager customerManager)
        {
            if (id != customerManager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerManagerExists(customerManager.Id))
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
            return View(customerManager);
        }

        // GET: CustomerManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerManager = await _context.CustomerManager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerManager == null)
            {
                return NotFound();
            }

            return View(customerManager);
        }

        // POST: CustomerManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerManager = await _context.CustomerManager.FindAsync(id);
            _context.CustomerManager.Remove(customerManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerManagerExists(int id)
        {
            return _context.CustomerManager.Any(e => e.Id == id);
        }
    }
}
