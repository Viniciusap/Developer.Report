using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Developer.Report.Models;
using Developer.Report.Services;

namespace Developer.Report.Controllers
{
    public class DeveloperCodersController : Controller
    {
        private readonly DevReportContext _context;

        public DeveloperCodersController(DevReportContext context)
        {
            _context = context;
        }

        // GET: DeveloperCoders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Developers.ToListAsync());
        }

        // GET: DeveloperCoders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developerCoder = await _context.Developers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (developerCoder == null)
            {
                return NotFound();
            }

            return View(developerCoder);
        }

        // GET: DeveloperCoders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeveloperCoders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Adrress,Age")] DeveloperCoder developerCoder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(developerCoder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(developerCoder);
        }

        // GET: DeveloperCoders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developerCoder = await _context.Developers.FindAsync(id);
            if (developerCoder == null)
            {
                return NotFound();
            }
            return View(developerCoder);
        }

        // POST: DeveloperCoders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Adrress,Age")] DeveloperCoder developerCoder)
        {
            if (id != developerCoder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(developerCoder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeveloperCoderExists(developerCoder.Id))
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
            return View(developerCoder);
        }

        // GET: DeveloperCoders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developerCoder = await _context.Developers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (developerCoder == null)
            {
                return NotFound();
            }

            return View(developerCoder);
        }

        // POST: DeveloperCoders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var developerCoder = await _context.Developers.FindAsync(id);
            _context.Developers.Remove(developerCoder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeveloperCoderExists(int id)
        {
            return _context.Developers.Any(e => e.Id == id);
        }
    }
}
