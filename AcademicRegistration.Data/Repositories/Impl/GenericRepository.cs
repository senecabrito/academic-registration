using AcademicRegistration.Data.Database.Context;
using AcademicRegistration.Data.Models;
using AcademicRegistration.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AcademicRegistration.Data.Repositories.Impl
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MSSQLContext _context;
        private readonly DbSet<T> _dataset;

        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(Guid id)
        {
            return _dataset.Find(id);
        }

        public T Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            var existingEntity = _dataset.Find(entity.Id);
            if (existingEntity == null)
            {
                throw new NullReferenceException("The entity was not found.");
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var existingEntity = _dataset.Find(id);
            if (existingEntity == null)
            {
                throw new NullReferenceException("The entity was not found.");
            }

            _context.Remove(existingEntity);
            _context.SaveChanges();
        }

        public bool Exists(Guid id)
        {
            return _dataset.Any(e => e.Id == id);
        }

    }
}
