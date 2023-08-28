using DoctorAppointment.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Interfaces
{
	public interface IUnitOfWork
	{
		IGenericRepo GenericRepository<T>() where T : class;
		void Save();
	}
}
