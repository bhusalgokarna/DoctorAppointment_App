
using DoctorAppointment.Data;
using DoctorAppointment.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace DoctorAppointment.Repositories.Implimentation
{
    public class GenericRepo<T> : IGenericRepo where T : class
    {
        private readonly ApplicationDbContext dbContext;
        internal DbSet<T> DbSet { get; set; }
        public GenericRepo(ApplicationDbContext context)
        {
            dbContext = context;
            DbSet = dbContext.Set<T>();

        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await dbContext.Set<T>().AddAsync(entity);  //kan lees models van buiten
            /*_ = await dbContext.SaveChangesAsync();*/      //discard (als ik heb geen interesse om de resultat te zien)
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> SelectAll<T>() where T : class
        {
            return _ = await dbContext.Set<T>().ToListAsync();

        }

        public async Task<T> SelectById<T>(int id) where T : class
        {
            // return await DbSet.Find(id);
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            dbContext.Set<T>().Update(entity);
            _ = await dbContext.Set<T>().ToListAsync();
        }
    }
}
