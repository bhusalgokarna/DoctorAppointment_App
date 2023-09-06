using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoctorAppointment.Data;
using DoctorAppointment.Models;
using Hospital.Repository.Interfaces;

namespace DoctorAppointment.Controllers
{
    public class DateSlotsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

		public DateSlotsController(ApplicationDbContext context, IUnitOfWork unitOfWork)
		{
			_context = context;
			_unitOfWork = unitOfWork;
		}

		// GET: DateSlots
		public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DateSlots.Include(d => d.Doctor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DateSlots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DateSlots == null)
            {
                return NotFound();
            }

            var dateSlot = await _context.DateSlots
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dateSlot == null)
            {
                return NotFound();
            }

            return View(dateSlot);
        }

        // GET: DateSlots/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name");
            return View();
        }

        // POST: DateSlots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorId,AvailableDay")] DateSlot dateSlot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dateSlot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name", dateSlot.DoctorId);
            return View(dateSlot);
        }

        // GET: DateSlots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DateSlots == null)
            {
                return NotFound();
            }

            var dateSlot = await _context.DateSlots.FindAsync(id);
            if (dateSlot == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name", dateSlot.DoctorId);
            return View(dateSlot);
        }

        // POST: DateSlots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,AvailableDay")] DateSlot dateSlot)
        {
            if (id != dateSlot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dateSlot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DateSlotExists(dateSlot.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Name", dateSlot.DoctorId);
            return View(dateSlot);
        }

        // GET: DateSlots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DateSlots == null)
            {
                return NotFound();
            }

            var dateSlot = await _context.DateSlots
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dateSlot == null)
            {
                return NotFound();
            }

            return View(dateSlot);
        }

        // POST: DateSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DateSlots == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DateSlots'  is null.");
            }
            var dateSlot = await _context.DateSlots.FindAsync(id);
            if (dateSlot != null)
            {
                _context.DateSlots.Remove(dateSlot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DateSlotExists(int id)
        {
          return (_context.DateSlots?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
