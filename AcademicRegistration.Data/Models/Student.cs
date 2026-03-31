using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AcademicRegistration.Data.Exceptions;

namespace AcademicRegistration.Data.Models
{
    [Table("students")]
    public class Student : BaseEntity
    {
        [Required]
        [Column("name"), MaxLength(50)]
        public string Name { get; private set; } = string.Empty;

        [Column("age")]
        public int Age { get; private set; }

        [Required]
        [Column("enrollment"), MaxLength(9)]
        public string Enrollment { get; private set; } = string.Empty;

        protected Student() { }

        public Student(string name, int age, string enrollment)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidNameException("Name cannot be null, empty or whitespace.");

            if (age < 7 || age > 100)
                throw new InvalidAgeException("Age must be between 7 and 100.");

            if (string.IsNullOrWhiteSpace(enrollment))
                throw new InvalidEnrollmentException("Enrollment cannot be null, empty or whitespace.");

            if (enrollment.Length != 9)
                 throw new InvalidEnrollmentException("Enrollment must be exactly 9 characters.");

            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Enrollment = enrollment;
        }

    }
}
