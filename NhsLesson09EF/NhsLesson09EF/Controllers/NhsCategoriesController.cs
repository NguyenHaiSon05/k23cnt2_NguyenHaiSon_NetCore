using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NhsLesson09EF.Models;

namespace NhsLesson09EF.Controllers
{
    public class NhsCategoriesController : Controller
    {
        private readonly NhsBookStoreContext _context;

        public NhsCategoriesController(NhsBookStoreContext context)
        {
            _context = context;
        }

        // GET: NhsCategories
        public async Task<IActionResult> NhsIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: NhsCategories/Details/5
        public async Task<IActionResult> Details(int? nhsId)
        {
            if (nhsId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == nhsId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: NhsCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhsCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NhsIndex));
            }
            return View(category);
        }

        // GET: NhsCategories/Edit/5
        public async Task<IActionResult> Edit(int? nhsId)
        {
            if (nhsId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(nhsId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: NhsCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int nhsId, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (nhsId != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NhsIndex));
            }
            return View(category);
        }

        // GET: NhsCategories/Delete/5
        public async Task<IActionResult> Delete(int? nhsId)
        {
            if (nhsId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == nhsId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: NhsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int nhsId)
        {
            var category = await _context.Categories.FindAsync(nhsId);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NhsIndex));
        }

        private bool CategoryExists(int nhsId)
        {
            return _context.Categories.Any(e => e.CategoryId == nhsId);
        }
    }
}
