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
    public class ProductManagersController : Controller
    {
        private readonly GBCContext _context;

        public ProductManagersController(GBCContext context)
        {
            _context = context;
        }

        // GET: ProductManagers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductManager.ToListAsync());
        }

        // GET: ProductManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productManager = await _context.ProductManager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productManager == null)
            {
                return NotFound();
            }

            return View(productManager);
        }

        // GET: ProductManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductCode,ProductName,Price,ReleaseDate")] ProductManager productManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productManager);
        }

        // GET: ProductManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productManager = await _context.ProductManager.FindAsync(id);
            if (productManager == null)
            {
                return NotFound();
            }
            return View(productManager);
        }

        // POST: ProductManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductCode,ProductName,Price,ReleaseDate")] ProductManager productManager)
        {
            if (id != productManager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductManagerExists(productManager.Id))
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
            return View(productManager);
        }

        // GET: ProductManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productManager = await _context.ProductManager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productManager == null)
            {
                return NotFound();
            }

            return View(productManager);
        }

        // POST: ProductManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productManager = await _context.ProductManager.FindAsync(id);
            _context.ProductManager.Remove(productManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductManagerExists(int id)
        {
            return _context.ProductManager.Any(e => e.Id == id);
        }
    }
}
