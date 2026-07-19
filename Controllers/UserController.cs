using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basic_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("getAllStudents")]
        
        public List<Student> getAllStudents()
        {
            List<Student> studentList = new List<Student>()
            {
                new Student(){studentId=1, studentName="Shubham", studentCity="Pune", isActive=true}
            };

            var stud2 = new Student()
            {
                studentId = 2,
                studentName = "Rohit",
                studentCity = "Mumbai",
                isActive = true
            };
            studentList.Add(stud2);

            var stud3 = new Student()
            {
                studentId = 3,
                studentName = "Ramesh",
                studentCity = "Nagpur",
                isActive = false
            };

            studentList.Add(stud3);

            return studentList;
            
        }

        [HttpGet]
        [Route("getAllEmployees")]

        public List<Employee> getAllEmployees()
        {
            List<Employee> employeeList = new List<Employee>()
            {
                new Employee(){employeeId=1, employeeName="Shubham", employeeMobile="1234567890", projectName="Project A"}
            };

            var emp2 = new Employee()
            {
                employeeId = 2,
                employeeName = "Rohit",
                employeeMobile = "0987654321",
                projectName = "Project B"
            };
            employeeList.Add(emp2);

            var emp3 = new Employee()
            {
                employeeId = 3,
                employeeName = "Ramesh",
                employeeMobile = "1122334455",
                projectName = "Project C"
            };

            employeeList.Add(emp3);

            return employeeList;
        }

        // [HttpGet("getEmployeeById")]
        // public Employee getEmployeeById(int id)
        // {
        //     List<Employee> employeeList = getAllEmployees();
        //     var employee = employeeList.FirstOrDefault(e => e.employeeId == id);
        //     if(employee == null)
        //     {
        //         return new Employee(); // Return an empty employee object if not found
        //     }
        //     return employee;
        // }

        [HttpGet("getEmployeeById/{id}")]
        public Employee getEmployeeById(int id)
        {
            List<Employee> employeeList = getAllEmployees();
            var employee = employeeList.FirstOrDefault(e => e.employeeId == id);
            if(employee == null)
            {
                return new Employee(); // Return an empty employee object if not found
            }
            return employee;
        }

        [HttpDelete("deleteEmployeeById/{id}")]
        public bool deleteEmployeeById(int id)
        {
            List<Employee> employeeList = getAllEmployees();
            var employee = employeeList.FirstOrDefault(e => e.employeeId == id);
            if(employee == null)
            {
                return false; // Return false if employee not found
            }
            employeeList.Remove(employee);
            return true; // Return true after deletion
        }

        [HttpGet("getEmployeeByName/{name}")]
        public List<Employee> getEmployeeByName(string name)
        {
            List<Employee> employeeList = getAllEmployees();
            var employee = employeeList.Where(e => e.employeeName.ToLower().StartsWith(name.ToLower())).ToList();
            if(employee == null)
            {
                return new List<Employee>(); // Return an empty list if not found
            }
            return employee;
        }
    }
}
