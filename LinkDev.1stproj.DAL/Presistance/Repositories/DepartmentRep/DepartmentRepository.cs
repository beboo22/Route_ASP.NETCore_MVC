using LinkDev._1stproj.DAL.Models.Department;
using LinkDev._1stproj.DAL.Presistance.Data;
using LinkDev._1stproj.DAL.Presistance.Repositories.Genaric;
using Microsoft.EntityFrameworkCore;

namespace LinkDev._1stproj.DAL.Presistance.Repositories.DepartmentRep
{
    public class DepartmentRepository : GenaricRepositories<Departments>, IRepositoryDepartment
    {
        public DepartmentRepository(_1stProjectDbContext db) : base(db)
        {
        }
    }
}
        #region old
        //private _1stProjectDbContext _db;

        //public employeeRepository(_1stProjectDbContext db)
        //{
        //    _db = db;
        //}

        //public IEnumerable<Department> GetAll(bool WithNoTracking = true)
        //{
        //    //if (WithNoTracking)
        //    //    return _db.Departments.AsNoTracking().ToList();
        //    //return _db.Departments.ToList();

        //    return WithNoTracking? _db.Departments.AsNoTracking().ToList()
        //                         : _db.Departments.ToList();

        //}

        //public Department? GetById(int id)
        //{
        //    //var Items = _db.Departments.Local.FirstOrDefault(d => d.ID == id);
        //    //return Items is not null ? Items : new Department();

        //    return _db.Departments.Find(id);
        //}

        //public int Update(Department department)
        //{

        //    _db.Departments.Update(department);
        //    return _db.SaveChanges();

        //}
        //public int Add(Department department)
        //{
        //    try
        //    {

        //        _db.Departments.Add(department);
        //        return _db.SaveChanges();
        //    }
        //    catch (Exception)
        //    {

        //        throw ;
        //    }
        //}

        //public int Delete(Department department)
        //{
        //    if(_db.Entry(department).State == EntityState.Detached)
        //        _db.Departments.Attach(department);
        //    _db.Departments.Remove(department);
        //    return _db.SaveChanges();
        //}
        //public int Delete(int id)
        //{
        //    var department = _db.Departments.Find(id);
        //    //_db.Departments.Remove(department);
        //    return department is not null ? Delete(department) : 0;// _db.SaveChanges();
        //}

        //public IQueryable<Department> GetAllIQueryable()
        //{
        //    return _db.Departments;
        //} 

        #endregion
