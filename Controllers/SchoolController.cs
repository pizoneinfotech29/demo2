global using Microsoft.EntityFrameworkCore;
using task.Data;
using task.Models;


namespace task.Controllers
{


    [ApiController]
    [Route("[Controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly DataContext _context;
        public SchoolController(DataContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public IActionResult GetAllSchools()
        {
            var schools = _context.Schools.ToList();
            return Ok(schools);
        }

        [HttpGet("GetAllClassesBySchoolId")]
        public IActionResult GetAllClassesBySchoolId(int schoolId)
        {
            var school = _context.Schools.Include(c => c.Classes).FirstOrDefault(c => c.Id == schoolId);
            if (school == null)
            {
                return NotFound("School Not Found");
            }
            return Ok(school.Classes);

        }
        [HttpPost]
        public IActionResult AddSchool (School school)
        {
            _context.Schools.Add(school);
            _context.SaveChanges();
            return Ok(school);
        }

        [HttpPut ("{id}")]
        public IActionResult UpdateSchool (int id, School updatedSchool)
        {
            var school = _context.Schools.Find(id);
            if(school == null)
            {
                return NotFound();
            }
            school.Name = updatedSchool.Name;
            school.Location = updatedSchool.Location;
            _context.SaveChanges();
            return Ok(school);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchool (int id)
        {
            var school = _context.Schools.Find(id);
            if (school == null)
            {
                return NotFound($"The School with id {id} not found.");
            }
            _context.Schools.Remove(school);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
    

