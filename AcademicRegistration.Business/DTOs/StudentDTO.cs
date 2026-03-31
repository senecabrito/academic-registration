namespace AcademicRegistration.Business.DTOs
{
    public record StudentDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int Age { get; init; }
        public string Enrollment { get; init; } = string.Empty;
    }
}
