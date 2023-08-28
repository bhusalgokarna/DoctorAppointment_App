using DoctorAppointment.Models;
using DoctorAppointment.Repositories.Interfaces;
using Hospital.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DoctorAppointment.Models.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageHelper _imageHelper;
      
        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork,IImageHelper imageHelper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
        }

        public  IActionResult Index()
        {       
            return View();			
        }

        public async Task<IActionResult> About()
        {
            var Dep=await _unitOfWork.GenericRepository<Department>().SelectAll<Department>();
            return View(Dep);
        }


        public async Task<IActionResult> SearchDoctor(string searchItem)
        {

            ViewBag.adress = new SelectList(await _unitOfWork.GenericRepository<Address>().SelectAll<Address>(), "Id", "StreetName");          
            var doctor = await _unitOfWork.GenericRepository<Doctor>().SelectAll<Doctor>();
            var searchedDoctor = doctor.Where(s => s.Name == searchItem).ToList();
            foreach (var item in searchedDoctor)
            {
                ViewBag.ImageUrl = _imageHelper.GetImageUrl(item.UrlToPicture);
            }
            
            return View(searchedDoctor);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}