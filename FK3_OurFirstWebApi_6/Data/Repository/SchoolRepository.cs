using FK3_OurFirstWebApi_6.Data.Interfaces;
using FK3_OurFirstWebApi_6.Models;
using FK3_OurFirstWebApi_6.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace FK3_OurFirstWebApi_6.Data.Repository
{
    public class SchoolRepository : IRepository
    {
        private readonly SchoolDbContext _dbContext;

        public SchoolRepository()
        {

            _dbContext = new SchoolDbContext();
        }

        public async Task CreateCourseAsync(Course course)
        {
            using (var db = _dbContext)
            {
                await db.Courses.AddAsync(course);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateStudentAsync(Student student)
        {
            using (var db = _dbContext)
            {
                await db.Students.AddAsync(student);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            Course courseToDelete;

            using (var db = _dbContext)
            {
                 courseToDelete = await db.Courses.FirstOrDefaultAsync(c => c.Id == id)!;

                if (courseToDelete == null)
                {
                    //false == delete failure
                    return false;
                }
                else
                {
                    db.Courses.Remove(courseToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }

               
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            Student studentToDelete;

            using (var db = _dbContext)
            {
                studentToDelete = await db.Students.FirstOrDefaultAsync(c => c.Id == id)!;

                if (studentToDelete == null)
                {
                    //false == delete failure
                    return false;
                }
                else
                {
                    db.Students.Remove(studentToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }


            }
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            using (var db = _dbContext)
            {
                return await db.Courses.ToListAsync();
            }
        }

        public async Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            List<Student> students;

            using (var db = _dbContext)
            {
                students = await db.Students.Include(c => c.Courses).ToListAsync();
            }

            List<StudentDTO> listToReturn = new List<StudentDTO>();

            foreach (Student stud in students)
            {
                List<CourseDTO> coursesDTO = stud.Courses.Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Students = null
                }).ToList();

                StudentDTO studToAdd = new StudentDTO
                {
                    Id = stud.Id,
                    FirstName = stud.FirstName,
                    LastName = stud.LastName,
                    
                };

                listToReturn.Add(studToAdd);
            }

            return listToReturn;
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            using (var db = _dbContext)
            {
                return await db.Courses.Include(s => s.Students).FirstOrDefaultAsync(c => c.Id == id)!;
            }
        }

        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            Student s;

            using (var db = _dbContext)
            {
                s = await db.Students.Include(c => c.Courses).FirstOrDefaultAsync(s => s.Id == id)!;
            }

            if (s == null)
            {
                return null;
            }

            List<CourseDTO> coursesDTO = new List<CourseDTO>();

            foreach (Course c in s.Courses)
            {
                CourseDTO dto = new CourseDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Students = null
                };
                coursesDTO.Add(dto);
            }

            StudentDTO studToReturn = new StudentDTO
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Courses = coursesDTO
            };

            return studToReturn;
        }


        public async Task<Course> UpdateCourseAsync(int id, Course course)
        {
            Course courseToUpdate;

            using (var db = _dbContext)
            {
                 courseToUpdate = await db.Courses.FirstOrDefaultAsync(c => c.Id == id)!;

                if (courseToUpdate == null)
                {
                    return null;
                }

                courseToUpdate.Name = course.Name;
                courseToUpdate.Students = course.Students;

                await db.SaveChangesAsync();

                return courseToUpdate;
            }
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            Student studentToUpdate;

            using (var db = _dbContext)
            {
                studentToUpdate = await db.Students.FirstOrDefaultAsync(c => c.Id == id)!;

                if (studentToUpdate == null)
                {
                    return null;
                }

                studentToUpdate.FirstName = student.FirstName;
                studentToUpdate.LastName = student.LastName;
                studentToUpdate.SSID = student.SSID;
                


                await db.SaveChangesAsync();

                return studentToUpdate;
            }
        }
    }
}
