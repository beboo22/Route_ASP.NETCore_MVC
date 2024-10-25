using LinkDev._1stproj.DAL.Models.Employee;
using LinkDev._1stproj.DAL.Presistance.Repositories.DepartmentRep;
using LinkDev._1stproj.DAL.Presistance.Repositories.EmployeeRep;
using LinkDev._1stproj.DAL.Presistance.UnitofWork;
using LinkDev._1stProj.BLL.common.services.interfaces;
using LinkDev._1stProj.BLL.Entity.EmpEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LinkDev._1stProj.BLL.Services.EmployeeServ
{
    public class EmployeeService : IServicesEmployee
    {
        //private IRepositoryEmployee _uni.IRepositoryEmployee;
        private readonly IUnitOfWork _uni;
        private readonly IAttachmentServices _attachment;

        public EmployeeService(/*IRepositoryEmployee empR*/IUnitOfWork uni, IAttachmentServices attachment)
        {
            //_uni.IRepositoryEmployee = empR;
            _uni = uni;
            _attachment = attachment;
        }


        public IEnumerable<EmployeeToReturnDto> GetAllEmployees(string search)
        {
            var items = _uni.IRepositoryEmployee.GetAllIQueryable().Where(E => E.Name.ToLower().Contains(search.ToLower()) || string.IsNullOrEmpty(search));
            foreach (var item in items)
            {
                yield return new EmployeeToReturnDto
                {
                    ID = item.ID,
                    Name = item.Name,
                    Age = item.Age,
                    HiringDate = item.HiringDate,
                    Adress = item.Adress,
                    salary = item.salary,
                    IsActive = item.IsActive,
                    Email = item.Email,
                    Gender = item.Gender.ToString(),
                    EmployeeType = item.EmployeeType.ToString(),
                    PhoneNumber = item.PhoneNumber,
                    DepartmentID = item.DepartmentId ?? 0,
                    DepartmentName = item.Department?.Name ?? "no",
                    image = item.image,
                };
            }
        }

        public EmployeeToReturnDto? GetEmployeesById(int id)
        {
            var item = _uni.IRepositoryEmployee.GetById(id);
            return new EmployeeToReturnDto
            {
                ID = item.ID,
                Name = item.Name,
                Age = item.Age,
                HiringDate = item.HiringDate,
                Adress = item.Adress,
                salary = item.salary,
                IsActive = item.IsActive,
                Email = item.Email,
                Gender = item.Gender.ToString(),
                EmployeeType = item.EmployeeType.ToString(),
                PhoneNumber = item.PhoneNumber,
                DepartmentName = item.Department?.Name ?? "no",
                image = item.image,
            };

        }

        public int UpdateEmployee(UpdateEmoloyeeDto emp)
        {
            var item = new Employees
            {
                ID = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                HiringDate = emp.HiringDate,
                Adress = emp.Adress,
                salary = emp.salary,
                IsActive = emp.IsActive,
                Email = emp.Email,
                Gender = emp.Gender,
                EmployeeType = emp.EmployeeType,
                PhoneNumber = emp.PhoneNumber,
                DepartmentId = emp.DepartmentID,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
                //image = emp.image,
            };
            if (emp.image is not null)
                item.image = _attachment.upload(emp.image, "Images");
            return _uni.IRepositoryEmployee.Update(item);
        }
        public int CreatedEmployee(CreatedEmployeeeDto emp)
        {
            var item = new Employees
            {
                ID = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                HiringDate = emp.HiringDate,
                Adress = emp.Adress,
                salary = emp.salary,
                IsActive = emp.IsActive,
                Email = emp.Email,
                Gender = emp.Gender,
                EmployeeType = emp.EmployeeType,
                PhoneNumber = emp.PhoneNumber,
                DepartmentId = emp.DepartmentID,
                //image = emp.image,

            };

            if (emp.image is not null)
                item.image = _attachment.upload(emp.image, "Images");
            return _uni.IRepositoryEmployee.Add(item);
        }

        public bool DeleteEmployee(int id)
        {
            var item = _uni.IRepositoryEmployee.GetById(id);
            return item is not null ? _uni.IRepositoryEmployee.Delete(item) > 0 : false;
        }
    }
}
