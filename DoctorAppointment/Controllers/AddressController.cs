using DoctorAppointment.Models;
using Hospital.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.Controllers
{
    public class AddressController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get List of Address....
        public async Task<IActionResult> Index()
        {
            IEnumerable<Address> allAddress = await _unitOfWork.GenericRepository<Address>().SelectAll<Address>();
            return View(allAddress);
        }


        //Create New Address....
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Post The New Created Address....
        [HttpPost]
        public async Task<IActionResult> Create(Address address)
        {
            if (address == null)
            {
                return NotFound();
            }
             await _unitOfWork.GenericRepository<Address>().CreateAsync(address);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        // Get Edit Address...
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var editAddress=await _unitOfWork.GenericRepository<Address>().SelectById<Address>(id);
            return View(editAddress);   
        }

        // Post Edited Address....
        [HttpPost]
        public async Task<IActionResult> Edit(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _unitOfWork.GenericRepository<Address>().UpdateAsync(address);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        // Get Address which you want to Delete....
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var deleteAddress = await _unitOfWork.GenericRepository<Address>().SelectById<Address>(id);
            return View(deleteAddress);
        }

        // Post Delete Address....
        [HttpPost]
        public async Task<IActionResult> Delete(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _unitOfWork.GenericRepository<Address>().DeleteAsync(address);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }


        // Get Details of an address.....
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var adress=await _unitOfWork.GenericRepository<Address>().SelectById<Address>(id);
            return View(adress);
        }
    }
}
