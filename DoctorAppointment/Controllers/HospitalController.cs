﻿using DoctorAppointment.Models;
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
        public async Task<IActionResult> Index()
        {
            ViewBag.Adres = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "City");
            var hospital = await _unitOfWork.GenericRepository<Models.HospitalInfo>().SelectAll<Models.HospitalInfo>();
            ViewBag.Street = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "StreetName");
            ViewBag.City = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "City");
            ViewBag.PostCode = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "PostCode");
            ViewBag.Country = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "Country");
            //var hospital = await _unitOfWork.GenericRepository<Models.HospitalInfo>().SelectAll<Models.HospitalInfo>();
            foreach (var item in hospital)
            {
                if (item?.UrlToPicture != null)
                {
                    string imageUrl = _imageHelper.GetImageUrl(item.UrlToPicture);
                    ViewBag.ImageUrl = imageUrl;
                }
                item.Contacts = _unitOfWork.GenericRepository<Contact>().SelectAll<Contact>().Result.Where(h=>h.HospitalId==item.Id).ToList();
                if (item.Contacts==null)
                {
                    item.Contacts = new List<Contact>();
                }
            }

            return View(hospital);
        }
        public async Task<IActionResult> Contacts()
        {
            ViewBag.Street = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "StreetName");
            ViewBag.City = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "City");
            ViewBag.PostCode = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "PostCode");
            ViewBag.Country = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "Country");
            var hospital = await _unitOfWork.GenericRepository<Models.HospitalInfo>().SelectAll<Models.HospitalInfo>();
            foreach (var item in hospital)
            {
                if (item?.UrlToPicture != null)
                {
                    string imageUrl = _imageHelper.GetImageUrl(item.UrlToPicture);
                    ViewBag.ImageUrl = imageUrl;
                }
                foreach (var con in item.Contacts)
                {
                    ViewBag.Email = con.Email;
                    ViewBag.Phone = con.Phone;
                }
            }
            return View(hospital);
        }
        public async Task<IActionResult> Details(int id)
        {
            var hospital = await _unitOfWork.GenericRepository<Models.HospitalInfo>().SelectById<Models.HospitalInfo>(id);
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
        public async Task<IActionResult> Create(Models.HospitalInfo hospital, IFormFile file)
        {
            if (hospital!=null)
            {
            string fileName = _imageHelper.StoreImage(file);
            hospital.UrlToPicture = fileName;
            await _unitOfWork.GenericRepository<Models.HospitalInfo>().CreateAsync<Models.HospitalInfo>(hospital);
            _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

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
            ViewBag.Addresses = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "StreetName");
            ViewBag.Contact = new SelectList(await _unitOfWork.GenericRepository<Contact>().SelectAll<Contact>(), "Id", "Phone");
        }
    }
}
