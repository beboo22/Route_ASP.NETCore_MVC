using LinkDev._1stproj.DAL.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stProj.BLL.Entity.EmpEntity
{
    public class EmployeeToReturnDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string? Adress { get; set; }
        public decimal salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public DateOnly HiringDate { get; set; }

        public string Gender { get; set; }

        public string EmployeeType { get; set; }
        public int? DepartmentID { get; set; }
        public string? DepartmentName { get; set; }

        public string? image { get; set; }
    }
}
