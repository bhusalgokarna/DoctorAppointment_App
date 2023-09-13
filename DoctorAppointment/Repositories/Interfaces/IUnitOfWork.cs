using DoctorAppointment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Interfaces
{
	public interface IUnitOfWork
	{
        IDbContextTransaction BeginTransaction();
        IGenericRepo GenericRepository<T>() where T : class;
		void Save();
	}
}
