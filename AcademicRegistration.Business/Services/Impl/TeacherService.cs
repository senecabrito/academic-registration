using Mapster;
using AcademicRegistration.Business.Services.Abstractions;
using AcademicRegistration.Business.DTOs;
using AcademicRegistration.Data.Repositories.Abstractions;
using AcademicRegistration.Data.Models;

namespace AcademicRegistration.Business.Services.Impl
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> _repository;

        public TeacherService(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        public List<TeacherDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<TeacherDTO>>();
        }

        public TeacherDTO FindById(Guid id)
        {
            return _repository.FindById(id).Adapt<TeacherDTO>();
        }

        public TeacherDTO Create(TeacherDTO teacher)
        {
            var entity = teacher.Adapt<Teacher>();
            entity = _repository.Create(entity);
            return entity.Adapt<TeacherDTO>();
        }

        public TeacherDTO Update(TeacherDTO teacher)
        {
            var entity = teacher.Adapt<Teacher>();
            entity = _repository.Update(entity);
            return entity.Adapt<TeacherDTO>();
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

    }
}
