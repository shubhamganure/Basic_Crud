using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Basic_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeOnboardingController : ControllerBase
    {
        public readonly EmployeeDbContextClass _dbContext;

        public EmployeeOnboardingController(EmployeeDbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeMasterDetailsViewModel employee)
        {
            try
            {
                EmployeeMasterModel _employee = new EmployeeMasterModel()
                {
                    empId = 0,
                    empName = employee.empName,
                    empMobile = employee.empMobile,
                    empEmail = employee.empEmail
                };
                await _dbContext.EmployeeMasterModels.AddAsync(_employee);
                await _dbContext.SaveChangesAsync();

                EmployeeIdentityDetailsModel _employeeIdentityDetails = new EmployeeIdentityDetailsModel()
                {
                    empId = _employee.empId,
                    aadharCardNo = employee.aadharCardNo,
                    panCardNo = employee.panCardNo,
                    drivingLicenceNo = employee.drivingLicenceNo
                };
                await _dbContext.EmployeeIdentityDetailsModels.AddAsync(_employeeIdentityDetails);
                await _dbContext.SaveChangesAsync();
                // employee.empId = _employee.empId; // Set the empId in the response model
                return Created("Employee created successfully.", employee);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the employee.");
            }
        }
        
        [HttpGet("getEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await (from emp in _dbContext.EmployeeMasterModels
                                 join empIdentity in _dbContext.EmployeeIdentityDetailsModels
                                 on emp.empId equals empIdentity.empId
                                 select new EmployeeMasterDetailsViewModel
                                 {
                                     empId = emp.empId,
                                     empName = emp.empName,
                                     empMobile = emp.empMobile,
                                     empEmail = emp.empEmail,
                                     aadharCardNo = empIdentity.aadharCardNo,
                                     panCardNo = empIdentity.panCardNo,
                                     drivingLicenceNo = empIdentity.drivingLicenceNo
                                 }).ToListAsync();
                return Ok(employees);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving employees.");
            }
        }

        [HttpGet("getEmployeeById/{id}")]
        public async Task<IActionResult> getEmployeeById(int id)
        {
            var empData = _dbContext.EmployeeMasterModels.FirstOrDefault(x => x.empId == id);
            var empIdentityData = _dbContext.EmployeeIdentityDetailsModels.FirstOrDefault(x => x.empId == id);
            if (empData == null || empIdentityData == null)
            {
                return NotFound("Employee not found.");
            }
            return Ok(new EmployeeMasterDetailsViewModel
            {
                empId = empData.empId,
                empName = empData.empName,
                empMobile = empData.empMobile,
                empEmail = empData.empEmail,
                aadharCardNo = empIdentityData.aadharCardNo,
                panCardNo = empIdentityData.panCardNo,
                drivingLicenceNo = empIdentityData.drivingLicenceNo
            });
        }

        [HttpDelete("deleteEmployeeById/{id}")]
        public async Task<IActionResult> deleteEmployeeById(int id)
        {
            var empData = _dbContext.EmployeeMasterModels.FirstOrDefault(x => x.empId == id);
            var empIdentityData = _dbContext.EmployeeIdentityDetailsModels.FirstOrDefault(x => x.empId == id);
            if (empData == null || empIdentityData == null)
            {
                return NotFound("Employee not found.");
            }
            _dbContext.EmployeeMasterModels.Remove(empData);
            _dbContext.EmployeeIdentityDetailsModels.Remove(empIdentityData);
            await _dbContext.SaveChangesAsync();
            return Ok("Employee deleted successfully.");
        }

        [HttpPut("updateEmployeeById/{id}")]
        public async Task<IActionResult> updateEmployeeById(int id, [FromBody] EmployeeMasterDetailsViewModel employee)
        {
            var empData = _dbContext.EmployeeMasterModels.FirstOrDefault(x => x.empId == id);
            var empIdentityData = _dbContext.EmployeeIdentityDetailsModels.FirstOrDefault(x => x.empId == id);
            if (empData == null || empIdentityData == null)
            {
                return NotFound("Employee not found.");
            }
            empData.empName = employee.empName;
            empData.empMobile = employee.empMobile;
            empData.empEmail = employee.empEmail;
            empIdentityData.aadharCardNo = employee.aadharCardNo;
            empIdentityData.panCardNo = employee.panCardNo;
            empIdentityData.drivingLicenceNo = employee.drivingLicenceNo;
            await _dbContext.SaveChangesAsync();
            return Ok("Employee updated successfully.");
        }
    }
}
