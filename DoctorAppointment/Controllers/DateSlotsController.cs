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
            var dateSlot = await _unitOfWork.GenericRepository<DateSlot>().SelectAll<DateSlot>();
            await ReturnViewBag();
            return View(dateSlot);
		}

		// GET: DateSlots/Details
		public async Task<IActionResult> Details(int id)
        {
            if (id == 0 )
            {
                return NotFound();
            }
			var dateSlot = await _unitOfWork.GenericRepository<DateSlot>().SelectById<DateSlot>(id);
            await ReturnViewBag();
			return View(dateSlot);
        }

        // GET: DateSlots/Create
        public async Task<IActionResult> Create()
        {
			await ReturnViewBag();
			return View();
        }

        // POST: DateSlots/Create
        [HttpPost]      
        public async Task<IActionResult> Create(DateSlot dateSlot)
        {
			await _unitOfWork.GenericRepository<DateSlot>().CreateAsync(dateSlot);
            _unitOfWork.Save();
			return RedirectToAction(nameof(Index));

		}

        // GET: DateSlots/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var dateSlot = await _unitOfWork.GenericRepository<DateSlot>().SelectById<DateSlot>(id);
            await ReturnViewBag();
            return View(dateSlot);
        }

        // POST: DateSlots/Edit      
        [HttpPost]
        public async Task<IActionResult> Edit( DateSlot dateSlot)
        {			
				await _unitOfWork.GenericRepository<DateSlot>().UpdateAsync(dateSlot);
				_unitOfWork.Save();		
				return RedirectToAction(nameof(Index));
        }

        // GET: DateSlots/Delete
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 )
            {
                return NotFound();
            }
			var dateSlot = await _unitOfWork.GenericRepository<DateSlot>().SelectById<DateSlot>(id);
			await ReturnViewBag();
			return View(dateSlot);
		}

        // POST: DateSlots/Delete
        [HttpPost, ActionName("Delete")]        
        public async Task<IActionResult> Delete(DateSlot dateSlot)
        {
			await _unitOfWork.GenericRepository<DateSlot>().DeleteAsync(dateSlot);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

        private bool DateSlotExists(int id)
        {
          return (_context.DateSlots?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task ReturnViewBag()
        {
            var dateSlot = await _unitOfWork.GenericRepository<DateSlot>().SelectAll<DateSlot>();
            foreach (var item in dateSlot)
            {
                ViewData["DoctorId"] = new SelectList(await _unitOfWork.GenericRepository<Doctor>().SelectAll<Doctor>(), "Id", "Name", item.DoctorId);
            }
		}
	}
}
