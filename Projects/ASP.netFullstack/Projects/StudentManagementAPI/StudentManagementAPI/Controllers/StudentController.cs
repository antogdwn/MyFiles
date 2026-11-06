using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
using StudentManagementAPI.Services;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IJWTAuthservice authservice;
        public StudentController(AppDbContext context, IJWTAuthservice jWTAuthservice)
        {
            this.context = context;
            authservice = jWTAuthservice;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents(int pageNumber = 1, int pageSize = 2)
        {


            var queryable = context.Students.AsQueryable();
            var res = await queryable
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return res;


        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return student;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent([FromBody] Student student)
        {
            var newStudent = new Student
            {
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
                Course = student.Course
            };
            await context.AddAsync(newStudent);
            await context.SaveChangesAsync();
            //return RedirectToAction("GetStudentById", student.Id);
            return CreatedAtAction("GetStudentById", new { Id = student.Id }, student);

        }
        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            var studentOld = await context.Students.FindAsync(id);
            if (studentOld == null)
            {
                return NotFound();
            }
            studentOld.Name = student.Name;
            studentOld.Email = student.Email;
            studentOld.Age = student.Age;
            studentOld.Course = student.Course;


            await context.SaveChangesAsync();
            //return RedirectToAction("GetStudentById", student.Id);
            return CreatedAtAction("GetStudentById", new { Id = student.Id }, student);


        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var studentOld = await context.Students.FindAsync(id);
            if (studentOld == null)
            {
                return NotFound();
            }
            context.Students.Remove(studentOld);
            await context.SaveChangesAsync();
            //return RedirectToAction("GetStudentById", student.Id);
            return NoContent();

        }
        [HttpGet("Login")]

        //could have used a model class for Login request but for simplicity, I am using query parameters here
        public IActionResult Login([FromQuery] string username, [FromQuery]string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }

            if (authservice.ValidateUser(username, password))
            {

                return Ok(new { Token = authservice.GenerateToken(username) });

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("Search")]
        public async Task<ActionResult<Student>> SearchStudentByName(string Name)
        {
            var student = await context.Students.FirstOrDefaultAsync(x => x.Name == Name);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return student;
            }
        }

       
    }

    //[HttpGet]
    //public async Task<ActionResult<List<Student>>> SearchStudentByPagination(int pageNumber, int pageSize)
    //{
    //    return await context.Students.ToListAsync();




    //}
}
