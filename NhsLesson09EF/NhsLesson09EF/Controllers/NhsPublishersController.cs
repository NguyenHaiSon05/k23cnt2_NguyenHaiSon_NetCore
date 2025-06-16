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
    public class NhsPublishersController : Controller
    {
        private readonly NhsBookStoreContext _context;

        public NhsPublishersController(NhsBookStoreContext context)
        {
            _context = context;
        }

        // GET: NhsPublishers
        public async Task<IActionResult> NhsIndex()
        {
            return View(await _context.Publishers.ToListAsync());
        }

        // GET: NhsPublishers/Details/5
        public async Task<IActionResult> Details(int? NhsId)
        {
            if (NhsId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == NhsId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: NhsPublishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhsPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NhsIndex));
            }
            return View(publisher);
        }

        // GET: NhsPublishers/Edit/5
        public async Task<IActionResult> Edit(int? NhsId)
        {
            if (NhsId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers.FindAsync(NhsId);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: NhsPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int NhsId, [Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (NhsId != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.PublisherId))
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
            return View(publisher);
        }

        // GET: NhsPublishers/Delete/5
        public async Task<IActionResult> Delete(int? NhsId)
        {
            if (NhsId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == NhsId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: NhsPublishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int NhsId)
        {
            var publisher = await _context.Publishers.FindAsync(NhsId);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NhsIndex));
        }

        private bool PublisherExists(int NhsId)
        {
            return _context.Publishers.Any(e => e.PublisherId == NhsId);
        }
    }
}
