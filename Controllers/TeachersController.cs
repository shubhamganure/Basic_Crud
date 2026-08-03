using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Basic_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        public readonly EmployeeDbContextClass _dbContext;
        public TeachersController(EmployeeDbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("getAllTeachers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            try
            {
                var teachers = await _dbContext.TeacherModels.ToListAsync();
                return Ok(teachers);
                
            }
            catch (System.Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving teachers.");    
            }
            
        }

        [HttpPost("addTeacher")]
        public async Task<IActionResult> AddTeacher([FromBody] TeacherModel teacher)
        {
            try
            {
                await _dbContext.TeacherModels.AddAsync(teacher);
                await _dbContext.SaveChangesAsync();
                return Ok(teacher);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the teacher.");
            }
           
        }
    }
}
