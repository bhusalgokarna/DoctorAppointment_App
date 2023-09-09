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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DoctorAppointment.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public PatientsController(ApplicationDbContext context,IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

      //  GET: Patients
        public async Task<IActionResult> Index()
        {
            var patient=await _unitOfWork.GenericRepository<Patient>().SelectAll<Patient>();
            await ReturnViewBag();
            return View(patient);
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var patient = await _unitOfWork.GenericRepository<Patient>().SelectById<Patient>(id);
            await ReturnViewBag();
            return View(patient);
        }

        // GET: Patients/Create
        public async Task<IActionResult> Create()
        {
            await ReturnViewBag();
            return View();
        }

        // POST: Patient/Create      
        [HttpPost]
        public async Task<IActionResult> Create( Patient patient)
        {
            await _unitOfWork.GenericRepository<Patient>().CreateAsync(patient);
            _unitOfWork.Save();
            return RedirectToAction("Index");   
        }

        // GET: Patient/Edit
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var patient = await _unitOfWork.GenericRepository<Patient>().SelectById<Patient>(id);
            await ReturnViewBag();
            return View(patient);
        }

        // POST: Patient/Edit
        [HttpPost]
        public async Task<IActionResult> Edit( Patient patient)
        {
            await _unitOfWork.GenericRepository<Patient>().UpdateAsync(patient);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        // GET: Patient/Delete
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var patient = await _unitOfWork.GenericRepository<Patient>().SelectById<Patient>(id);
            await ReturnViewBag();
            return View(patient);
        }

        // POST: Patient/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(Patient patient)
        {
            await _unitOfWork.GenericRepository<Patient>().DeleteAsync(patient);  
            return RedirectToAction(nameof(Index));
        }
        private async Task ReturnViewBag()
        {
            var patient=await _unitOfWork.GenericRepository<Patient>().SelectAll<Patient>();
            foreach (var pat in patient)
            {
            ViewData["DepartmentId"] = new SelectList(await _unitOfWork.GenericRepository<Department>().SelectAll<Department>(), "Id", "Name", pat.DepartmentId);
			ViewData["DoctorId"] = new SelectList(await _unitOfWork.GenericRepository<Doctor>().SelectAll<Doctor>(), "Id", "Name", pat.DoctorId);
			ViewData["GenreId"] = new SelectList(await _unitOfWork.GenericRepository<Genre>().SelectAll<Genre>(), "Id", "Gender", pat.GenreId);
			ViewData["HospitalInfoId"] = new SelectList(await _unitOfWork.GenericRepository<HospitalInfo>().SelectAll<HospitalInfo>(), "Id", "Name", pat.HospitalInfoId);
            }
			


		}
	}
}
