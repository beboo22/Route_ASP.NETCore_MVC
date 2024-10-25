using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev._1stproj.DAL.Models.Department;
using LinkDev._1stproj.DAL.Presistance.Repositories.DepartmentRep;
using LinkDev._1stproj.DAL.Presistance.UnitofWork;
using LinkDev._1stProj.BLL.Entity.DeptEntity;

namespace LinkDev._1stProj.BLL.Services.DepartmentServ
{
    public class DepartmentService : IServicesDepartment
    {
        //private IRepositoryDepartment _uni.IRepositoryDepartment;
        private readonly IUnitOfWork _uni;

        public DepartmentService(IUnitOfWork uni)
        {
            _uni = uni;
        }

        //public DepartmentService(IRepositoryDepartment depR)
        //{
        //    _uni.IRepositoryDepartment = depR;
        //}

        public IEnumerable<DepartmentToReturnDto> GetAllDepartments()
        {
            var items = _uni.IRepositoryDepartment.GetAllIQueryable().ToList();
            foreach (var item in items)
            {
                yield return new DepartmentToReturnDto()
                {
                    ID = item.ID,
                    Name = item.Name,
                    code = item.code,
                    Description = item.Description,
                    CreationDate = item.CreationDate,
                };
            }
        }

        public DepartmentToReturnDto? GetDepartmentsById(int id)
        {
            var item = _uni.IRepositoryDepartment.GetById(id);
            return item is null ? new DepartmentToReturnDto() : new DepartmentToReturnDto()
            {
                ID = item.ID,
                Name = item.Name,
                code = item.code,
                Description = item.Description,
                CreationDate = item.CreationDate,
            };
        }
        public int CreatedDepartment(CreatedDepartmentDto department)
        {
            var item = new Departments()
            {
                code = department.code,
                Description = department.Description,
                CreationDate = department.CreationDate,
                Name = department.Name,

            };
            return _uni.IRepositoryDepartment.Add(item);
        }

        public bool DeleteDepartment(int id)
        {
            var item = _uni.IRepositoryDepartment.GetById(id);
            return item is not null?_uni.IRepositoryDepartment.Delete(item) > 0 : false;
        }


        public int UpdateDepartment(UpdateDepartmentDto department)
        {
            var item = new Departments()
            {
                ID = department.ID,
                code = department.code,
                Description = department.Description,
                CreationDate = department.CreationDate,
                Name = department.Name,
                LastModifiedBy = 1,
                LastModifiedOn = department.LastModifiedOn,
            };
            return _uni.IRepositoryDepartment.Update(item);
        }
    }
}
