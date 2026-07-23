using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basic_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly EmployeeDbContextClass _dbContext;
        public EmployeeController(EmployeeDbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllEmployees")]

        public List<EmployeeNewClass> GetAllEmployees()
        {
            var employees = _dbContext.Employees.ToList();
            return employees;
        }

        [HttpPost("AddEmployee")]
        public EmployeeNewClass AddEmployee(EmployeeNewClass employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        [HttpPut("UpdateEmployee")]
        public EmployeeNewClass UpdateEmployee(EmployeeNewClass employee)
        {
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        [HttpDelete("DeleteEmployee/{empId}")]
        public string DeleteEmployee(int empId)
        {
            var employee = _dbContext.Employees.Find(empId);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
                return $"Employee with ID {empId} has been deleted.";
            }
            else
            {
                return $"Employee with ID {empId} not found.";
            }
        }

        [HttpGet("GetEmployeeById/{empId}")]
        public EmployeeNewClass GetEmployeeById(int empId)
        {
            var employee = _dbContext.Employees.Find(empId);
            if (employee != null)
            {
                return employee;
            }
            else
            {
                throw new ArgumentException("Employee not found.");
            }
        }
    }
}
