using AcademicRegistration.Business.DTOs;

namespace AcademicRegistration.Business.Services.Abstractions
{
    public interface ITeacherService
    {
        public List<TeacherDTO> FindAll();
        TeacherDTO FindById(Guid id);
        TeacherDTO Create(TeacherDTO product);
        TeacherDTO Update(TeacherDTO product);
        void Delete(Guid id);
    }
}
