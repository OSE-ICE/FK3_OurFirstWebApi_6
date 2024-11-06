namespace FK3_OurFirstWebApi_6.Models.DTO
{
    public class CourseDTO
    {
        public CourseDTO()
        {
            Students = new List<Student>();
        }
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Student>? Students { get; set; }
    }
}
