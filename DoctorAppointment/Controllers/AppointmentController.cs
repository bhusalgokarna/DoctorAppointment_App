using DoctorAppointment.Data;
using DoctorAppointment.Models;
using DoctorAppointment.ViewModels;
using Hospital.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        public AppointmentController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        //Get All Appointments..
        public async Task<IActionResult> Index()
        {
            var getAllAppointment =await _unitOfWork.GenericRepository<Appointment>().SelectAll<Appointment>();
            var vmList = new List<AppointmentViewModel>();
            foreach (var appointment in getAllAppointment)
            {
                AppointmentViewModel viewModel = new AppointmentViewModel();
                viewModel.Id = appointment.Id;
                viewModel.Description = appointment.Description;
                viewModel.CreatedDate = appointment.CreatedDate;
                viewModel.DoctorId = appointment.DoctorId;
                viewModel.PatientId = appointment.PatientId;
                viewModel.DateSlotId = appointment.DateSlotId;
                viewModel.TimeSlotId = appointment.TimeSlotId;
                viewModel.DoctorName = _context.Doctors.Where(x => x.Id == viewModel.DoctorId).First().Name;
                viewModel.PatientName = _context.Patients.Where(x => x.Id == viewModel.PatientId).First().Name;
                viewModel.Bookeddate = _context.DateSlots.Where(x => x.Id == viewModel.DateSlotId).First().AvailableDay;
                viewModel.BookedTime = _context.TimeSlots.Where(x => x.Id == viewModel.TimeSlotId).First().AvailAbleTime;
                vmList.Add(viewModel);
            }
            return View(vmList);
          
        }

        //Create a Appointment..
        [HttpGet]
        public IActionResult Create()
        {
            return  View();
        }



        //Post Appointment Object...
        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            ViewBag.Doctor = new SelectList(await _unitOfWork.GenericRepository<Appointment>().SelectAll<Appointment>(), "Id", "Name");
            try
            {
                await _unitOfWork.GenericRepository<Appointment>().CreateAsync(appointment);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }          
        }



        // Get Edit Object...
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(id==0)
            {
                return NotFound();
            }
            
            AppointmentViewModel viewModel = new AppointmentViewModel();
           await ReturnViewModel(viewModel, id);
            
            return View(viewModel);
        }

        public async Task ReturnViewModel(AppointmentViewModel vm, int id)
        {
            var getAppointmentById = await _unitOfWork.GenericRepository<Appointment>().SelectById<Appointment>(id);
            vm.Description = getAppointmentById.Description;
            vm.DoctorId = getAppointmentById.DoctorId;
            vm.PatientId = getAppointmentById.PatientId;
            vm.DateSlotId = getAppointmentById.DateSlotId;
            vm.TimeSlotId = getAppointmentById.TimeSlotId;
            vm.DoctorName = _context.Doctors.Where(x => x.Id == vm.DoctorId).First().Name;
            vm.PatientName = _context.Patients.Where(x => x.Id == vm.PatientId).First().Name;
            vm.Bookeddate = _context.DateSlots.Where(x => x.Id == vm.DateSlotId).First().AvailableDay;
            vm.BookedTime = _context.TimeSlots.Where(x => x.Id == vm.TimeSlotId).First().AvailAbleTime;
        }
        //Post Edited Object
        [HttpPost]
        public async Task<IActionResult>Edit(Appointment appointment)
        {
            await _unitOfWork.GenericRepository<Appointment>().UpdateAsync(appointment);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        //Get Id To Delete Object...
        [HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			AppointmentViewModel vm=new AppointmentViewModel();
            await ReturnViewModel(vm, id);
			return View(vm);
		}

		//Post Edited Object
		[HttpPost]
		public async Task<IActionResult> Delete(Appointment appointment)
		{
			await _unitOfWork.GenericRepository<Appointment>().DeleteAsync(appointment);
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}

		//All Doctors for dropdown....
		public async Task<JsonResult> Doctor()
        {
          
            var doc= await _unitOfWork.GenericRepository<Doctor>().SelectAll<Doctor>();
            return new JsonResult(doc);
        }

        //DateSlot Based on choosen Doctor Id..
        public async Task<JsonResult> DateSlot(int id)
        {
            //var ds = _context.DateSlots.Where(x => x.DoctorId == id).ToList();
            var ds = await _unitOfWork.GenericRepository<DateSlot>().SelectAll<DateSlot>();
            var date= ds.Where(x=>x.DoctorId==id).ToList();           
            return new JsonResult(date);
        }

        //TimeSlot Based on if it is alredy booked or not....
        public async Task<JsonResult>TimeSlot(int id, int dateId)
        {

            var bookedTimeSlot = await _unitOfWork.GenericRepository<Appointment>().SelectAll<Appointment>();
            var bookedTime = bookedTimeSlot.Where(x => x.DoctorId == id && x.DateSlotId == dateId).Select(t => t.TimeSlotId).ToList();
            var tds = await _unitOfWork.GenericRepository<TimeSlot>().SelectAll<TimeSlot>();
            var returnFreeTimeSlot = tds.Where(x => x.DoctorId == id && !bookedTime.Contains(x.Id)).ToList();
            return new JsonResult(returnFreeTimeSlot);
            
        }
        public async Task<JsonResult>Patient(int id)
        {
            // var ps = _context.Patients.Where(x => x.DoctorId == id).ToList();
            var patient = await _unitOfWork.GenericRepository<Patient>().SelectAll<Patient>();
            var selectedPatient = patient.Where(x => x.DoctorId == id).ToList();            
            return new JsonResult(selectedPatient);
        }

    }
}
