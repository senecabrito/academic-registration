using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AcademicRegistration.Data.Exceptions;

namespace AcademicRegistration.Data.Models
{
    [Table("teachers")]
    public class Teacher : BaseEntity
    {
        [Required]
        [Column("name"), MaxLength(50)]
        public string Name { get; private set; } = string.Empty;

        [Column("age")]
        public int Age { get; private set; }

        [Column("wage", TypeName = "decimal(18,2)")]
        public decimal Wage { get; private set; }

        [Required]
        [Column("enrollment"), MaxLength(9)]
        public string Enrollment { get; private set; } = string.Empty;

        protected Teacher() { }

        public Teacher(string name, int age, decimal wage, string enrollment)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidNameException("Name cannot be null, empty or whitespace.");

            if (age < 22 || age > 100)
                throw new InvalidAgeException("Age must be between 22 and 100.");

            if (wage < 1500 || wage > 100000)
                throw new InvalidWageException("Wage must be between 1500 and 100000.");

            if (string.IsNullOrWhiteSpace(enrollment))
                throw new InvalidEnrollmentException("Enrollment cannot be null, empty or whitespace.");

            if (enrollment.Length != 9)
                throw new InvalidEnrollmentException("Enrollment must be exactly 9 characters.");

            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Wage = wage;
            Enrollment = enrollment;
        }
    }
}
