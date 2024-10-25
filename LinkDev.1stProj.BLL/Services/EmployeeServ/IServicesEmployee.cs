using LinkDev._1stProj.BLL.Entity.DeptEntity;
using LinkDev._1stProj.BLL.Entity.EmpEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stProj.BLL.Services.EmployeeServ
{
    public interface IServicesEmployee
    {
        public IEnumerable<EmployeeToReturnDto> GetAllEmployees(string search);

        EmployeeToReturnDto? GetEmployeesById(int id);

        public int CreatedEmployee(CreatedEmployeeeDto emp);
        public int UpdateEmployee(UpdateEmoloyeeDto emp);
        bool DeleteEmployee(int id);
    }
}
