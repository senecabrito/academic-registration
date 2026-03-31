using Mapster;
using AcademicRegistration.Business.DTOs;
using AcademicRegistration.Business.Services.Abstractions;
using AcademicRegistration.Data.Models;
using AcademicRegistration.Data.Repositories.Abstractions;

namespace AcademicRegistration.Business.Services.Impl
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;

        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public List<StudentDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<StudentDTO>>();
        }

        public StudentDTO FindById(Guid id)
        {
            return _repository.FindById(id).Adapt<StudentDTO>();
        }

        public StudentDTO Create(StudentDTO student)
        {
            var entity = student.Adapt<Student>();
            entity = _repository.Create(entity);
            return entity.Adapt<StudentDTO>();
        }

        public StudentDTO Update(StudentDTO student)
        {
            var entity = student.Adapt<Student>();
            entity = _repository.Update(entity);
            return entity.Adapt<StudentDTO>();
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

    }
}
