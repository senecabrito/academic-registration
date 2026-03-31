using System.ComponentModel.DataAnnotations;

namespace AcademicRegistration.Data.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; protected set; }
    }
}
