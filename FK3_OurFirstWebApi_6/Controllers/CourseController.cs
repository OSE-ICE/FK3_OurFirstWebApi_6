using FK3_OurFirstWebApi_6.Data.Interfaces;
using FK3_OurFirstWebApi_6.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace FK3_OurFirstWebApi_6.Controllers
{
    [Route("api/courses")]
    [Controller]
    public class CourseController : ControllerBase
    {
        private readonly IRepository _repository;

        public CourseController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCoursesAsync()
        {
            try
            {
                return Ok( await _repository.GetAllCoursesAsync());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Course>> GetCourseByIdAsync(int id)
        { 
            try         
            {

                Course course = await _repository.GetCourseByIdAsync(id);

            if(course == null)
                    {
                    return NotFound();
                }
            else
                {
                    return Ok(course);
                }
            }
        catch (Exception) { 
        
            return StatusCode(500);
        }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseAsync(Course course)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateCourseAsync(course);
                    return CreatedAtAction(nameof(GetCourseByIdAsync), new { id = course.Id }, course);
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
        public async Task<IActionResult> UpdateCourseAsync(int id,[FromBody] Course course)
        {

            try { 
            Course updatedCourse = await _repository.UpdateCourseAsync(id, course);

            if (updatedCourse == null)
            {
                return NotFound();
            }
            else
            {
                return CreatedAtAction(nameof(GetCourseByIdAsync), new { id = updatedCourse.Id }, updatedCourse);
            }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Course>> DeleteCourseAsync(int id)
        {
            try
            {
                bool deleteSuccesfull = await _repository.DeleteCourseAsync(id);

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
