using LinkDev._1stproj.DAL.Models.Department;
using LinkDev._1stProj.BLL.Entity.DeptEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stProj.BLL.Services.DepartmentServ
{
    public interface IServicesDepartment
    {

        public IEnumerable<DepartmentToReturnDto> GetAllDepartments();

        DepartmentToReturnDto? GetDepartmentsById(int id);

        public int CreatedDepartment(CreatedDepartmentDto department);
        public int UpdateDepartment(UpdateDepartmentDto department);
        bool DeleteDepartment(int id);

    }
}
