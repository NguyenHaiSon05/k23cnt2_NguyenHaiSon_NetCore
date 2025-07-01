using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenHaiSon_2310900088.Models;

namespace NguyenHaiSon_2310900088.Controllers
{
    public class NhsEmployeesController : Controller
    {
        private readonly NguyenHaiSon2310900088Context _context;

        public NhsEmployeesController(NguyenHaiSon2310900088Context context)
        {
            _context = context;
        }

        // GET: NhsEmployees
        public async Task<IActionResult> NhsIndex()
        {
            return View(await _context.NhsEmployees.ToListAsync());
        }

        // GET: NhsEmployees/Details/5
        public async Task<IActionResult> NhsDetails(int? NhsId)
        {
            if (NhsId == null)
            {
                return NotFound();
            }

            var nhsEmployee = await _context.NhsEmployees
                .FirstOrDefaultAsync(m => m.NhsEmpId == NhsId);
            if (nhsEmployee == null)
            {
                return NotFound();
            }

            return View(nhsEmployee);
        }

        // GET: NhsEmployees/Create
        public IActionResult NhsCreate()
        {
            return View();
        }

        // POST: NhsEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NhsCreate([Bind("NhsEmpId,NhsEmpName,NhsEmpLevel,NhsEmpStartDate,NhsEmpStatus")] NhsEmployee nhsEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhsEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NhsIndex));
            }
            return View(nhsEmployee);
        }

        // GET: NhsEmployees/Edit/5
        public async Task<IActionResult> NhsEdit(int? NhsId)
        {
            if (NhsId == null)
            {
                return NotFound();
            }

            var nhsEmployee = await _context.NhsEmployees.FindAsync(NhsId);
            if (nhsEmployee == null)
            {
                return NotFound();
            }
            return View(nhsEmployee);
        }

        // POST: NhsEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NhsEdit(int NhsId, [Bind("NhsEmpId,NhsEmpName,NhsEmpLevel,NhsEmpStartDate,NhsEmpStatus")] NhsEmployee nhsEmployee)
        {
            if (NhsId != nhsEmployee.NhsEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhsEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhsEmployeeExists(nhsEmployee.NhsEmpId))
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
            return View(nhsEmployee);
        }

        // GET: NhsEmployees/Delete/5
        public async Task<IActionResult> NhsDelete(int? NhsId)
        {
            if (NhsId == null)
            {
                return NotFound();
            }

            var nhsEmployee = await _context.NhsEmployees
                .FirstOrDefaultAsync(m => m.NhsEmpId == NhsId);
            if (nhsEmployee == null)
            {
                return NotFound();
            }

            return View(nhsEmployee);
        }

        // POST: NhsEmployees/Delete/5
        [HttpPost, ActionName("NhsDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int NhsId)
        {
            var nhsEmployee = await _context.NhsEmployees.FindAsync(NhsId);
            if (nhsEmployee != null)
            {
                _context.NhsEmployees.Remove(nhsEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NhsIndex));
        }

        private bool NhsEmployeeExists(int id)
        {
            return _context.NhsEmployees.Any(e => e.NhsEmpId == id);
        }
    }
}
