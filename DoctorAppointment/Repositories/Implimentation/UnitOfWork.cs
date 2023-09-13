using DoctorAppointment.Data;
using DoctorAppointment.Repositories.Implimentation;
using DoctorAppointment.Repositories.Interfaces;
using Hospital.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Implementation
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
	
	   public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;

		}
		public IGenericRepo GenericRepository<T>() where T : class
		{
			IGenericRepo repo = new GenericRepo<T>(_context);
			return repo;
			
		}
		public void Save()
		{
			_context.SaveChanges();
		}
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
