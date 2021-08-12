using API_Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ManagementPortalContext _context;

        public DepartmentsController(IConfiguration configuration, ManagementPortalContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment([FromBody] Department department)
        {
            var newDepartment = new Department
            {
                DepartmentName = department.DepartmentName
            };

            _context.Departments.Add(newDepartment);
            await _context.SaveChangesAsync();

            return newDepartment;
        }

        [HttpPut]
        public async Task<ActionResult<Department>> UpdDepartment([FromBody] Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();

            return department;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var departmentToDelete = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(departmentToDelete);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
