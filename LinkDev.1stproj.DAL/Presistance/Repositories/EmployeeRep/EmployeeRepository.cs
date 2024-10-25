using LinkDev._1stproj.DAL.Models.Employee;
using LinkDev._1stproj.DAL.Presistance.Data;
using LinkDev._1stproj.DAL.Presistance.Repositories.Genaric;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stproj.DAL.Presistance.Repositories.EmployeeRep
{
    public class EmployeeRepository : GenaricRepositories<Employees> , IRepositoryEmployee
    {
        public EmployeeRepository(_1stProjectDbContext db) : base(db)
        {
        }
        //public Employees GetAllIQueryable()
        //{
        //    var employee = _db.Employees.Find();
        //    if (employee is not null)
        //    {
        //        _db.Entry(employee).Reference(e=>e.Department).Load(); // Explicitly load the Department entity
        //    }
        //    return employee;
        //}
    }
}


#region old
//private _1stProjectDbContext _db;

//public EmployeeRepository(_1stProjectDbContext db)
//{
//    _db = db;
//}

//public IQueryable<Employees> GetAllIQueryable()
//{
//    return _db.Employees;
//}

//public Employees? GetById(int id)
//{
//    return _db.Employees.Find(id);
//}

//public int Update(Employees employees)
//{
//    _db.Employees.Update(employees);
//    return _db.SaveChanges();

//}
//public int Add(Employees employees)
//{
//    _db.Employees.Add(employees);
//    return _db.SaveChanges();

//}

//public int Delete(Employees employee)
//{
//    if (_db.Entry(employee).State == EntityState.Detached)
//        _db.Employees.Attach(employee);

//    _db.Employees.Remove(employee);
//    return _db.SaveChanges();
//}



//public int Delete(int id)
//{
//    var item = GetById(id);
//    return item is null ? 0 : Delete(item);
//} 
#endregion
