using LinkDev._1stproj.DAL.Models;
using LinkDev._1stproj.DAL.Models.Employee;
using LinkDev._1stproj.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stproj.DAL.Presistance.Repositories.Genaric
{
    public class GenaricRepositories<T> where T: ModelBase
    {
        private protected _1stProjectDbContext _db;

        public GenaricRepositories(_1stProjectDbContext db)
        {
            _db = db;
        }

        public IQueryable<T> GetAllIQueryable()
        {
            //var query = _db.Set<T>().AsQueryable();

            //// Check if T is Employees
            //if (typeof(T) == typeof(Employees))
            //{
            //    // Use Include for the Department navigation property
            //    return query.Include("Department"); // String-based include
            //}

            //return query;
            return _db.Set<T>();
        }

        public T? GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public int Update(T employees)
        {
            _db.Set<T>().Update(employees);
            return _db.SaveChanges();

        }
        public int Add(T employees)
        {
            _db.Set<T>().Add(employees);
            return _db.SaveChanges();

        }

        public int Delete(T employee)
        {
            if (_db.Entry(employee).State == EntityState.Detached)
                _db.Set<T>().Attach(employee);

            _db.Set<T>().Remove(employee);
            return _db.SaveChanges();
        }



        public int Delete(int id)
        {
            var item = GetById(id);
            return item is null ? 0 : Delete(item);
        }



    }
}
