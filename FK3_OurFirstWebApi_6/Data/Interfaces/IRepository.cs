using FK3_OurFirstWebApi_6.Models;
using FK3_OurFirstWebApi_6.Models.DTO;

namespace FK3_OurFirstWebApi_6.Data.Interfaces
{
    public interface IRepository
    {
        Task<List<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task CreateStudentAsync(Student student);
        Task CreateCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(int id, Course course);
        Task<Student> UpdateStudentAsync(int id, Student student);

        Task<bool> DeleteStudentAsync(int id);

        Task<bool> DeleteCourseAsync(int id);
    }
}
