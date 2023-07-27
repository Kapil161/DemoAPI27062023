using DemoAPI27062023.Models;
using DemoAPI27062023.Repository.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI27062023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployee Employeeservices;
        public EmployeeController(IEmployee Employee)
        {
            Employeeservices = Employee;
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var results = Employeeservices.GetEmployees();
            if (results.Count > 0 && results != null)
            {
                return Ok(results);
            }
            else
            {
                return NotFound("Employee Not Found !");
            }

        }
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var results = Employeeservices.GetEmployeeById(id);
            if (results != null)
            {
                return Ok(results);
            }
            else
            {
                return NotFound("Employee Not Found !");
            }

        }
        [HttpPost]
        [Route("Post")]
        public IActionResult Post(Employee employee)
        {
            var result = Employeeservices.PostEmployee(employee);
            if (result != null)
            {
                return Ok(employee);
            }
            else
            {
                return Ok();
            }
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if(id==0)
            {
                return BadRequest();

            }
            else
            {
                var result = Employeeservices.DeleteEmployee(id);
                if(result!=null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Employee emp)
        {
            if(emp==null)
            {
                return BadRequest();
            }
            else
            {
                var result = Employeeservices.UpdateEmployee(emp);
                if(result!=null)
                {
                    return Ok(result);

                }
                else
                {
                    return NotFound();
                }
            }
        }
            
    }
}
