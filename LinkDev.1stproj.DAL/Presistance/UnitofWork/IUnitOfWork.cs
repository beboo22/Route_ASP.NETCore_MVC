using LinkDev._1stproj.DAL.Presistance.Repositories.DepartmentRep;
using LinkDev._1stproj.DAL.Presistance.Repositories.EmployeeRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stproj.DAL.Presistance.UnitofWork
{
    public interface IUnitOfWork
    {
        public IRepositoryEmployee IRepositoryEmployee {  get; }
        public IRepositoryDepartment IRepositoryDepartment {  get; }

        int Commit();
    }
}
