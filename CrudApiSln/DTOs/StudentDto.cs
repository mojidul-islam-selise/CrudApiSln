namespace CrudApiSln.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Section { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public float? Age { get; set; }
        public string? Address { get; set; }
    }
}
