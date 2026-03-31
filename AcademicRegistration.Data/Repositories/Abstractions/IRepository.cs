using AcademicRegistration.Data.Models;

namespace AcademicRegistration.Data.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        public List<T> FindAll();
        public T FindById(Guid id);
        public T Create(T entity);
        public T Update(T entity);
        public void Delete(Guid id);
        public bool Exists(Guid id);
    }
}
