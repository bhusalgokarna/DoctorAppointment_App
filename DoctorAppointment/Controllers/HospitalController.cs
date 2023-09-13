using DoctorAppointment.Models;
using DoctorAppointment.Repositories.Interfaces;
using Hospital.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorAppointment.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageHelper _imageHelper;
        public HospitalController(IUnitOfWork unitOfWork,IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
        }
		[Authorize(Roles = "Admin,Doctor")]
		public async Task<IActionResult> Index()
        {
            IEnumerable<HospitalInfo> hospitals = await _unitOfWork.GenericRepository<HospitalInfo>().SelectAll<HospitalInfo>();
            await ReturnViewBag();
            return View(hospitals);
        }

		public async Task<IActionResult> HospitalContact()
		{
            await ReturnViewBag();
			var hospital = await _unitOfWork.GenericRepository<Models.HospitalInfo>().SelectAll<Models.HospitalInfo>();						
			foreach (var item in hospital)
			{
				if (item?.UrlToPicture != null)
				{
					string imageUrl = _imageHelper.GetImageUrl(item.UrlToPicture);
					ViewBag.ImageUrl = imageUrl;
				}
				item.Contacts = _unitOfWork.GenericRepository<Contact>().SelectAll<Contact>()
                    .Result.Where(h => h.HospitalId == item.Id).ToList();
				if (item.Contacts == null)
				{
					item.Contacts = new List<Contact>();
				}
                item.Doctors=_unitOfWork.GenericRepository<Doctor>().SelectAll<Doctor>()
                    .Result.Where(h=>h.HospitalInfoId== item.Id).ToList();  
                if (item.Doctors == null)
                {
                    item.Doctors = new List<Doctor>();
                }
                item.Departments = _unitOfWork.GenericRepository<Department>().SelectAll<Department>()
                   .Result.Where(h => h.HospitalInfoId == item.Id).ToList();
                if (item.Departments == null)
                {
                    item.Departments = new List<Department>();
                }
            }

			return View(hospital);
		}	
        public async Task<IActionResult> Details(int id)
        {
            var hospital = await _unitOfWork.GenericRepository<HospitalInfo>().SelectById<HospitalInfo>(id);
            await ReturnViewBag();
            string imageUrl = _imageHelper.GetImageUrl(hospital.UrlToPicture);
            ViewBag.ImageUrl = imageUrl;         

            return View(hospital);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            await ReturnViewBag();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HospitalInfo hospital, IFormFile file)
        {
            if (hospital!=null)
            {
            string fileName = _imageHelper.StoreImage(file);
            hospital.UrlToPicture = fileName;
            await _unitOfWork.GenericRepository<HospitalInfo>().CreateAsync<HospitalInfo>(hospital);
            _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }
		[Authorize(Roles = "Admin")]
		[HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var hospitalToEdit = await _unitOfWork.GenericRepository<Models.HospitalInfo>().SelectById<Models.HospitalInfo>(id);
            await ReturnViewBag();
            string imageUrl = _imageHelper.GetImageUrl(hospitalToEdit.UrlToPicture);
            ViewBag.ImageUrl = imageUrl;
            return View(hospitalToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.HospitalInfo hospital, IFormFile file)
        {          
            if (hospital != null)
            {
            string fileName = _imageHelper.StoreImage(file);
            hospital.UrlToPicture = fileName; 
            await _unitOfWork.GenericRepository<Models.HospitalInfo>().UpdateAsync(hospital);
            }
           
            return RedirectToAction(nameof(Index));
        }

		[Authorize(Roles = "Admin")]

		[HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var hospitalToDelete = await _unitOfWork.GenericRepository<Models.HospitalInfo>().SelectById<Models.HospitalInfo>(id);
            ViewBag.Img = _imageHelper.GetImageUrl(hospitalToDelete.UrlToPicture);
            await ReturnViewBag();
          
            return View(hospitalToDelete);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Models.HospitalInfo hospital)
        {
            await _unitOfWork.GenericRepository<Models.HospitalInfo>().DeleteAsync(hospital);
            return RedirectToAction(nameof(Index));
        }
        public async Task ReturnViewBag()
        {
            ViewBag.Contact = new SelectList(await _unitOfWork.GenericRepository<Contact>().SelectAll<Contact>(), "Id", "Phone");
            ViewBag.Adres = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "City");
            ViewBag.Street = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "StreetName");
            ViewBag.PostCode = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "PostCode");
            ViewBag.Country = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "Country");
        }
    }
}
