using LinkDev._1stproj.DAL.Models;
using LinkDev._1stproj.DAL.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stproj.DAL.Presistance.Repositories.Genaric
{
    public interface IRepositoriesGenaric<T> where T : ModelBase
    {
        public IQueryable<T> GetAllIQueryable();

        public T GetById(int id);

        public int Add(T obj);
        public int Update(T obj);
        public int Delete(T obj);
    }
}
