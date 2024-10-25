using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stProj.BLL.Entity.DeptEntity
{
    public class DepartmentToReturnDto
    {
        public string? Name { get; set; }
        public int code { get; set; }
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }
        public int ID { get; set; }
    }
}
