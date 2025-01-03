using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherDsTudent.Data;

namespace TeacherDsTudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherContoller : ControllerBase
    {
        private readonly AppDBContext _db;

        public TeacherContoller(AppDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult> GetTeachers()
        {
            var Data = await _db.Teachers.Include(t => t.Students)
                                .ToListAsync();
            return Ok(Data);
        }
    }
}
