using DoctorAppointment.Models;
using Hospital.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Controllers
{  
    public class TmeSlotController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TmeSlotController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get TimeSlot List...
        public async Task<IActionResult> Index()
        {
            var time=await _unitOfWork.GenericRepository<TimeSlot>().SelectAll<TimeSlot>();
            await ReturnViewBag();
            return View(time);
        }

        //Create New TimeSlote.....
        [HttpGet]
        public async Task <IActionResult> Create()
        {
           await ReturnViewBag();
           return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TimeSlot time)
        {
            await _unitOfWork.GenericRepository<TimeSlot>().CreateAsync(time);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        //Edit TimeSlot.....Get By Id..
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {  
            var time=await _unitOfWork.GenericRepository<TimeSlot>().SelectById<TimeSlot>(id);
            await ReturnViewBag();           
            return View(time);
        }

        // Post Edited TimeSlot
        [HttpPost]
        public async Task<IActionResult> Edit(TimeSlot time)
        {
            await _unitOfWork.GenericRepository<TimeSlot>().UpdateAsync(time);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        // Delete TimeSlot
        [HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var time = await _unitOfWork.GenericRepository<TimeSlot>().SelectById<TimeSlot>(id);          
            await ReturnViewBag();
            return View(time);
		}

        // Post Edited TimeSlot
        [HttpPost]
		public async Task<IActionResult> Delete(TimeSlot time)
		{
			await _unitOfWork.GenericRepository<TimeSlot>().DeleteAsync(time);
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

			var time = await _unitOfWork.GenericRepository<TimeSlot>().SelectById<TimeSlot>(id);
            await ReturnViewBag();
            return View(time);
		}

        public async Task ReturnViewBag()
        {          
            var time = await _unitOfWork.GenericRepository<TimeSlot>().SelectAll<TimeSlot>();
            foreach (var item in time)
            {
                ViewData["DoctorId"] = new SelectList(await _unitOfWork.GenericRepository<Doctor>().SelectAll<Doctor>(), "Id", "Name", item.DoctorId);

            }
        }
	}
}
