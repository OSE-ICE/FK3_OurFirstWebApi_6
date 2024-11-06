using FK3_OurFirstWebApi_6.Data.Interfaces;
using FK3_OurFirstWebApi_6.Models;
using FK3_OurFirstWebApi_6.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace FK3_OurFirstWebApi_6.Data.Repository
{
    public class MockRepository : IRepository
    {

        List<StudentDTO> Students = new List<StudentDTO>()
            {
                new StudentDTO { Id = 1, FirstName = "John", LastName = "Doe" },
                new StudentDTO { Id = 2, FirstName = "Jane", LastName = "Smith" },
                new StudentDTO { Id = 3, FirstName = "Jack", LastName = "Jones" },
                new StudentDTO { Id = 4, FirstName = "Jill", LastName = "Johnson" },
                new StudentDTO { Id = 5, FirstName = "Jim", LastName = "Brown" }
            };

        List<Course> Courses = new List<Course>()
        {
            new Course { Id = 1, Name = "Math" },
            new Course { Id = 2, Name = "Science"},
            new Course { Id = 3, Name = "History",},
            new Course { Id = 4, Name = "English" },
            new Course { Id = 5, Name = "Art" }
        };

        public MockRepository()
        {

        }

        public Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            return null;
        }

        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            return Students.FirstOrDefault(x => x.Id == id)!;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return Courses;

        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return Courses.FirstOrDefault(x => x.Id == id)!;
        }

        public async Task CreateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public async  Task CreateCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task<Course> UpdateCourseAsync(int id, Course course)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourseAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
