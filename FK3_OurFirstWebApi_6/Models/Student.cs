using System.ComponentModel.DataAnnotations;

namespace FK3_OurFirstWebApi_6.Models
{
    public class Student
    {

        public Student()
        {
            Courses = new List<Course>();
        }
        public int Id { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string SSID { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
