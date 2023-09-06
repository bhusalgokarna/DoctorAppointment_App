using DoctorAppointment.Models;
using DoctorAppointment.Repositories.Interfaces;
using Hospital.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageHelper _imageHelper;
        public DepartmentController(IUnitOfWork unitOfWork,IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
        }
        public async Task<IActionResult> Index()
        {
            var allDepartment = await _unitOfWork.GenericRepository<Department>().SelectAll<Department>();
            ViewData["HospitalInfo"] = new SelectList(await _unitOfWork.GenericRepository<Models.HospitalInfo>().SelectAll<Models.HospitalInfo>(), "Id", "Name");

            return View(allDepartment);
        }
        public async Task<IActionResult> Services()
        {
            var allDepartment = await _unitOfWork.GenericRepository<Department>().SelectAll<Department>();
            foreach (var item in allDepartment)
            {
				item.Doctors = _unitOfWork.GenericRepository<Doctor>().SelectAll<Doctor>()
					.Result.Where(h => h.DepartmentId == item.Id).ToList();
				if (item.Doctors == null)
				{
					item.Doctors = new List<Doctor>();
				}
			}
			
			return View(allDepartment);
        }      

        [HttpGet]
        public  IActionResult Create()
        {
           // IEnumerable<Department>dep=await _unitOfWork.GenericRepository<Department>().SelectAll<Department>();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (department!= null)
            {
               await _unitOfWork.GenericRepository<Department>().CreateAsync<Department>(department);
                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await ViewBagReturn();
            var vD = await _unitOfWork.GenericRepository<Department>().SelectById<Department>(id);     
            return View(vD);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Department dM )
        {
            if (dM != null)
            {
                await _unitOfWork.GenericRepository<Doctor>().UpdateAsync(dM);
                _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var dep = await _unitOfWork.GenericRepository<Department>().SelectById<Department>(id);
            //await ReturnViewBag();
            return View(dep);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Department department)
        {
            await ViewBagReturn();
            if (department != null)
            {
                await _unitOfWork.GenericRepository<Department>().DeleteAsync(department);
                _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Hospital=new SelectList( await _unitOfWork.GenericRepository<HospitalInfo>().SelectAll<HospitalInfo>(),"Id","Name");
            var selectedDep = await _unitOfWork.GenericRepository<Department>().SelectById<Department>(id);
            
            //var doctors=selectedDep.Doctors;
            //foreach (var doctor in doctors)
            //{
            //    ViewBag.ImageUrl=_imageHelper.GetImageUrl(doctor.UrlToPicture);
            //}
            return View(selectedDep);
        }

       public async Task ViewBagReturn()
        {
            ViewBag.Hospital = new SelectList(await _unitOfWork.GenericRepository<HospitalInfo>().SelectAll<HospitalInfo>(), "Id", "Name");
        }
    }
}
