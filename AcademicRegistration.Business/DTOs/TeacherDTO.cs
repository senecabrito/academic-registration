namespace AcademicRegistration.Business.DTOs
{
    public record TeacherDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int Age { get; init; }
        public decimal Wage { get; init; }
        public string Enrollment { get; init; } = string.Empty;
    }
}
