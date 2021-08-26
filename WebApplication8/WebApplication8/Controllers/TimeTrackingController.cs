using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApplication8.Model;
using WebApplication8.EmployeeData;


namespace WebApplication8.Controllers
{
    [ApiController]
    public class TimeTrackingController : ControllerBase
    {
        private iEmployeeData _timeEmployeeData;

        public TimeTrackingController(iEmployeeData timeEmployeeData) {
            _timeEmployeeData = timeEmployeeData;
        }

        [HttpGet]
        [Route("api/[controller]/employee")]
        public IActionResult getAllEmployee() {
            return Ok(_timeEmployeeData.getAllEmployee());
        }
        [HttpGet]
        [Route("api/[controller]/searchName/{employeeName}")]
        public IActionResult searchName(string employeeName)
        {
            return Ok(_timeEmployeeData.searchName(employeeName));
        }

        [HttpGet]
        [Route("api/[controller]/employee/{ID}")]
        public IActionResult getEmployee(Guid ID)
        {
            var employee = _timeEmployeeData.getEmployee(ID);

            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with id : {ID} was not found");
        }
        [HttpPost]
        [Route("api/[controller]/add")]
        public IActionResult AddTimeEmployee(TimeTracking employee)
        {
            _timeEmployeeData.AddTimeEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.ID, employee);
        }
        [HttpDelete]
        [Route("api/[controller]/delete/{ID}")]
        public IActionResult DeleteTimeEmployee(Guid ID)
        {
            var employee = _timeEmployeeData.getEmployee(ID);
             
            if (employee != null)
            {
                _timeEmployeeData.DeleteTimeEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with id : {ID} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/edit/{ID}")]
        public IActionResult EditTimeEmployee(Guid ID, TimeTracking employee)
        {
            var existingEmployee = _timeEmployeeData.getEmployee(ID);

            if (existingEmployee != null)
            {
                employee.ID = existingEmployee.ID;
                _timeEmployeeData.EditTimeEmployee(employee);
            }
            return Ok();
        }

    }
}
