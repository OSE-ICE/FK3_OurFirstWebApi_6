namespace FK3_OurFirstWebApi_6.Models.DTO
{
    public class StudentDTO
    {
        public StudentDTO()
        {
            Courses = new List<CourseDTO>();
        }
        public int Id { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        
        public List<CourseDTO>? Courses { get; set; }
    }
}
