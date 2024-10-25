using LinkDev._1stproj.DAL.Presistance.Data;
using LinkDev._1stproj.DAL.Presistance.Repositories.DepartmentRep;
using LinkDev._1stproj.DAL.Presistance.Repositories.EmployeeRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stproj.DAL.Presistance.UnitofWork
{
    public class UnitofWork : IUnitOfWork
    {
        private _1stProjectDbContext _db { get; }
        public UnitofWork(_1stProjectDbContext db)
        {
            _db = db;
        }

        public IRepositoryEmployee IRepositoryEmployee => new EmployeeRepository(_db);

        public IRepositoryDepartment IRepositoryDepartment => new DepartmentRepository(_db);


        public int Commit()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
