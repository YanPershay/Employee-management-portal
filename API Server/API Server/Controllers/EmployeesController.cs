using API_Server.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ManagementPortalContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeesController(IConfiguration configuration, ManagementPortalContext context, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _context = context;
            _webHostEnvironment = webHostEnvironment;  
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] Employee employee)
        {
            var newEmployee = new Employee
            {
                EmployeeName = employee.EmployeeName,
                DepartmentId = employee.DepartmentId,
                DateOfJoining = DateTime.Now,
                PhotoProfileName = employee.PhotoProfileName
            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee;
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> UpdEmployee([FromBody] Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employeeToDelete = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employeeToDelete);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Route("SaveFile")]
        [HttpPost]
        public async Task<ActionResult> SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _webHostEnvironment.ContentRootPath + "/Photos/" + fileName;

                using(var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return Ok(fileName);
            }
            catch(Exception e)
            {
                return new JsonResult("bad.png");
            }
        }
    }
}
