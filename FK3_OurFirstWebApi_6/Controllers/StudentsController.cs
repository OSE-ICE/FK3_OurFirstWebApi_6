using FK3_OurFirstWebApi_6.Data.Interfaces;
using FK3_OurFirstWebApi_6.Models;
using FK3_OurFirstWebApi_6.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FK3_OurFirstWebApi_6.Controllers
{

    [Route("api/students")]
    [Controller]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository _repository;

        public StudentsController(IRepository repository)
        {
          _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentDTO>>> GetAllStudents()
        {
            try
            {

                List<StudentDTO> students = await _repository.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            try
            {
                StudentDTO stud = await _repository.GetStudentByIdAsync(id);
                if (stud == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(stud);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody]Student student)
        {
          try
            {
                if (ModelState.IsValid)
                {
                   await _repository.CreateStudentAsync(student);
                    return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, [FromBody] Student student)
        {
            try
            {
                Student stud = await _repository.UpdateStudentAsync(id, student);
                if (stud == null)
                {
                    
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetStudentById), new { id = stud.Id }, stud);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Student>> DeleteStudentAsync(int id)
        {
            try
            {
                bool deleteSuccesfull = await _repository.DeleteStudentAsync(id);

                if (!deleteSuccesfull)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}

