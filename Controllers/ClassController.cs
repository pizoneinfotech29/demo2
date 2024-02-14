global using Microsoft.AspNetCore.Mvc;
using task.Data;

namespace task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly DataContext _context;
        public ClassController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllClasses()
        {
            var classes = _context.Classes.ToList();
            return Ok(classes);
        }

        [HttpGet("GetSchoolByClassId")]
        public IActionResult GetSchoolByClassId(int classId)
        {
            var school = _context.Schools.FirstOrDefault(c => c.Classes.Any(s => s.Id == classId));
            if (school == null)
            {
                return NotFound("SchoolNotFound");
            }
            return Ok(school);
        }

        [HttpPost]
        public IActionResult AddClass (Class classModel)
        {
            _context.Classes.Add(classModel);
            _context.SaveChanges();
            return Ok(classModel);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateClass (int id, Class updatedClass)
        {
            var classModel = _context.Classes.Find(id);
            if (classModel == null)
            {
                return NotFound();
            }

            classModel.Name = updatedClass.Name;
            classModel.NumberOfStudents = updatedClass.NumberOfStudents;

            _context.SaveChanges();
            return Ok(classModel);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClass(int id)
        {
            var classModel = _context.Classes.Find(id);
            if (classModel == null)
            {
                return NotFound($"The Class with id {id} not found.");
            }
            _context.Classes.Remove(classModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
