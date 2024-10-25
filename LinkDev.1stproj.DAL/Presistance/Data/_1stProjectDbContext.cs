using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using LinkDev._1stproj.DAL.Models.Department;
using System.Reflection;
using LinkDev._1stproj.DAL.Models.Employee;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LinkDev._1stproj.DAL.Models.identity;
using Microsoft.AspNetCore.Identity;


namespace LinkDev._1stproj.DAL.Presistance.Data
{
    public class _1stProjectDbContext : IdentityDbContext<User,Role,int>
    {
        public _1stProjectDbContext(DbContextOptions<_1stProjectDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Employees> Employees { get; set; }

    }
}
