using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NhsLesson10DB.Models;

namespace NhsLesson10DB.Controllers
{
    public class NhsCategoriesController : Controller
    {
        private readonly NhsK23cnt2lesson10DbContext _context;

        public NhsCategoriesController(NhsK23cnt2lesson10DbContext context)
        {
            _context = context;
        }

        // GET: NhsCategories
        public async Task<IActionResult> NhsIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: NhsCategories/Details/5
        public async Task<IActionResult> NhsDetails(int? nhsId)
        {
            if (nhsId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CateId == nhsId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: NhsCategories/Create
        public IActionResult NhsCreate()
        {
            return View();
        }

        // POST: NhsCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NhsCreate([Bind("CateId,CateName,CateStatus")] Category category)
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
        public async Task<IActionResult> NhsEdit(int? nhsId)
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
        public async Task<IActionResult> NhsEdit(int nhsId, [Bind("CateId,CateName,CateStatus")] Category category)
        {
            if (nhsId != category.CateId)
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
                    if (!CategoryExists(category.CateId))
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
        public async Task<IActionResult> NhsDelete(int? nhsId)
        {
            if (nhsId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CateId == nhsId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: NhsCategories/Delete/5
        [HttpPost, ActionName("NhsDelete")]
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
            return _context.Categories.Any(e => e.CateId == nhsId);
        }
    }
}
