using System;
using System.Collections.Generic;

#nullable disable

namespace API_Server.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string PhotoProfileName { get; set; }

        public virtual Department Department { get; set; }
    }
}
