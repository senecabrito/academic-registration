using AcademicRegistration.Business.DTOs;

namespace AcademicRegistration.Business.Services.Abstractions
{
    public interface IStudentService
    {
        public List<StudentDTO> FindAll();
        StudentDTO FindById(Guid id);
        StudentDTO Create(StudentDTO product);
        StudentDTO Update(StudentDTO product);
        void Delete(Guid id);
    }
}
