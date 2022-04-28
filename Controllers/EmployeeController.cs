using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Contracts;
using EmployeeAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {       
        private readonly IWebHostEnvironment _env;
        private readonly IEmployeeBusiness _employeeRepo;
        
        public EmployeeController(IWebHostEnvironment env, IEmployeeBusiness employeeRepo)
        {
            _env = env;
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public IActionResult GetEmployeeList()
        {
            var result = _employeeRepo.GetEmployee();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetEmployee([FromHeader] int Id)
        {
            var result = _employeeRepo.GetEmployee(Id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            var result = _employeeRepo.AddEmployee(emp);
            return Ok(result);
        }
         
        [HttpPut]
        public IActionResult UpdateEmployee(Employee emp)
        {
            var result = _employeeRepo.UpdateEmployee(emp.Id, emp);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteEmployee([FromHeader]int Id)
        {
            var result = _employeeRepo.DeleteEmployee(Id);
            return Ok(true);
        }
    }
}
