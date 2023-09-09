using DoctorAppointment.Models;
using Hospital.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorAppointment.Controllers
{
    public class ContactController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get List of Contacts....
        public async Task<IActionResult> Index()
        {
            await ViewBagReturn();
            IEnumerable<Contact> allContacts = await _unitOfWork.GenericRepository<Contact>().SelectAll<Contact>();
            return View(allContacts);
        }


        //Create New Contact....
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await ViewBagReturn();
            return View();
        }

        // Post The New Created Contact....
        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (contact == null)
            {
                return NotFound();
            }
            await _unitOfWork.GenericRepository<Contact>().CreateAsync(contact);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        // Get Edit Contact...
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await ViewBagReturn();
            if (id == 0)
            {
                return NotFound();
            }
            var editContact = await _unitOfWork.GenericRepository<Contact>().SelectById<Contact>(id);
            return View(editContact);
        }

        // Post Edited Contact....
        [HttpPost]
        public async Task<IActionResult> Edit(Contact contact)
        {           
            await _unitOfWork.GenericRepository<Contact>().UpdateAsync(contact);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        // Get Contact which you want to Delete....
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await ViewBagReturn();
            if (id == 0)
            {
                return NotFound();
            }
            var deleteContact = await _unitOfWork.GenericRepository<Contact>().SelectById<Contact>(id);
            return View(deleteContact);
        }

        // Post Delete Contact....
        [HttpPost]
        public async Task<IActionResult> Delete(Contact contact)
        {
            await _unitOfWork.GenericRepository<Contact>().DeleteAsync(contact);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }


        // Get Details of a Contact.....
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var contact = await _unitOfWork.GenericRepository<Contact>().SelectById<Contact>(id);
            await ViewBagReturn();
            return View(contact);
        }

        public async Task ViewBagReturn()
        {
            ViewBag.Hospital = new SelectList(await _unitOfWork.GenericRepository<HospitalInfo>().SelectAll<HospitalInfo>(), "Id", "Name");
        }
    }
}
