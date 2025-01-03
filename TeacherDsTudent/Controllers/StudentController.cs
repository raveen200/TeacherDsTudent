using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherDsTudent.Data;

namespace TeacherDsTudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDBContext _db;

        public StudentController(AppDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            var data = await _db.Students.Include(t => t.Teacher).Select(t => new
            {
                t.StudentID,
                t.StudentName,
                TeacherName = t.Teacher.TeacherName
            }).ToListAsync();

            return Ok(data);
        }
    }
}
