using LinkDev._1stproj.DAL.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stproj.DAL.Models.Department
{
    public class Departments:ModelBase
    {
        public int code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }

        public virtual ICollection<Employees> Employees { get; set; } = new List<Employees>();
    }
}
