using LinkDev._1stproj.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev._1stproj.DAL.Models.Department;


namespace LinkDev._1stproj.DAL.Models.Employee
{
    public class Employees : ModelBase
    {
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string? Adress { get; set; }
        public decimal salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public DateOnly  HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType  { get; set; }


        public int? DepartmentId { get; set; }

        public virtual Departments? Department { get; set; }

        public string? image {  get; set; }

    }
}
