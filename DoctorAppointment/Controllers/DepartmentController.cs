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
            return View(allDepartment);
        }
        public async Task<IActionResult> Acc()
        {
            var allDepartment = await _unitOfWork.GenericRepository<Department>().SelectAll<Department>();
            return View(allDepartment);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<Department>dep=await _unitOfWork.GenericRepository<Department>().SelectAll<Department>();
            return View(dep);
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

            var vD = await _unitOfWork.GenericRepository<Doctor>().SelectById<Doctor>(id);
           // await ReturnViewBag();
            return View(vD);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doctor, IFormFile file)
        {
            if (doctor != null)
            {
                await _unitOfWork.GenericRepository<Doctor>().UpdateAsync(doctor);
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
        public async Task<IActionResult> Delete(Department department, IFormFile file)
        {
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
    }
}
