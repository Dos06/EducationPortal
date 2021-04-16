using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduPortal.Data;
using EduPortal.Models;

namespace EduPortal.Controllers
{
    public class CourseDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseDetails.Include(c => c.Course);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDetails = await _context.CourseDetails
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseDetails == null)
            {
                return NotFound();
            }

            return View(courseDetails);
        }

        // GET: CourseDetails/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name");
            return View();
        }

        // POST: CourseDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,Description,CourseId")] CourseDetails courseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", courseDetails.CourseId);
            return View(courseDetails);
        }

        // GET: CourseDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDetails = await _context.CourseDetails.FindAsync(id);
            if (courseDetails == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", courseDetails.CourseId);
            return View(courseDetails);
        }

        // POST: CourseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Price,Description,CourseId")] CourseDetails courseDetails)
        {
            if (id != courseDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseDetailsExists(courseDetails.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", courseDetails.CourseId);
            return View(courseDetails);
        }

        // GET: CourseDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDetails = await _context.CourseDetails
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseDetails == null)
            {
                return NotFound();
            }

            return View(courseDetails);
        }

        // POST: CourseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseDetails = await _context.CourseDetails.FindAsync(id);
            _context.CourseDetails.Remove(courseDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseDetailsExists(int id)
        {
            return _context.CourseDetails.Any(e => e.Id == id);
        }
    }
}
