using DoctorAppointment.Models;
using DoctorAppointment.Repositories.Interfaces;

using Hospital.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace DoctorAppointment.Controllers
{
   
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageHelper _imageHelper;
        public DoctorController(IUnitOfWork unitOfWork,IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
        }

		public async Task<IActionResult> DoctorsInDetails()
		{
			await ReturnViewBag();
			var allDoctor = await _unitOfWork.GenericRepository<Doctor>().SelectAll<Doctor>();
			foreach (var item in allDoctor)
			{
				if (item?.UrlToPicture != null)
				{
					string imageUrl = _imageHelper.GetImageUrl(item.UrlToPicture);
					ViewBag.ImageUrl = imageUrl;
				}
			}
			return View(allDoctor);
		}
		[Authorize(Roles = "Doctor,Admin")]
		public async Task<IActionResult> Index()
        {
            await ReturnViewBag();
            var allDoctor=await _unitOfWork.GenericRepository<Doctor>().SelectAll<Doctor>();
            return View(allDoctor);
        }
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Details(int id)
        {
            var doctor = await _unitOfWork.GenericRepository<Doctor>().SelectById<Doctor>(id);
            await ReturnViewBag();
            ViewBag.ImageUrl = _imageHelper.GetImageUrl(doctor.UrlToPicture);
            return View(doctor);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await ReturnViewBag();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor, IFormFile file)
        {
            if (doctor!=null)
            {
                string fileName = _imageHelper.StoreImage(file);
                doctor.UrlToPicture = fileName;
                await _unitOfWork.GenericRepository<Doctor>().CreateAsync(doctor);
                _unitOfWork.Save();
            }            
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
		[Authorize(Roles = "Admin")]

		public async Task<IActionResult> Edit(int id)
        {

            var vD = await _unitOfWork.GenericRepository<Doctor>().SelectById<Doctor>(id);
            await ReturnViewBag();
            if (vD?.UrlToPicture != null)
            {
                string imageUrl = _imageHelper.GetImageUrl(vD.UrlToPicture);
                ViewBag.ImageUrl = imageUrl;
            }
            return View(vD);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doctor, IFormFile file)
        {
            if (doctor!= null)
            {
                string fileName = _imageHelper.StoreImage(file);
                doctor.UrlToPicture = fileName;
                await _unitOfWork.GenericRepository<Doctor>().UpdateAsync(doctor);
                _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

		[Authorize(Roles = "Admin")]
		[HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var vD = await _unitOfWork.GenericRepository<Doctor>().SelectById<Doctor>(id);
            await ReturnViewBag();
            if (vD?.UrlToPicture != null)
            {
                string imageUrl = _imageHelper.GetImageUrl(vD.UrlToPicture);
                ViewBag.ImageUrl = imageUrl;
            }
            return View(vD);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Doctor doctor, IFormFile file)
        {
            if (doctor != null)
            {
                string fileName = _imageHelper.StoreImage(file);
                doctor.UrlToPicture = fileName;
                await _unitOfWork.GenericRepository<Doctor>().DeleteAsync(doctor);
                _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task ReturnViewBag()
        {
            ViewBag.Departments = new SelectList(await _unitOfWork.GenericRepository<Department>().SelectAll<Department>(), "Id", "Name");
            ViewBag.Hospitals = new SelectList(await _unitOfWork.GenericRepository<Models.HospitalInfo>().SelectAll<Models.HospitalInfo>(), "Id", "Name");
            ViewBag.Genders = new SelectList(await _unitOfWork.GenericRepository<Genre>().SelectAll<Genre>(), "Id", "Gender");
        }
    }
}
