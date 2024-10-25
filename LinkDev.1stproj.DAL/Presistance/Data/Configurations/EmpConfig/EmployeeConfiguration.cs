using LinkDev._1stproj.DAL.Enums;
using LinkDev._1stproj.DAL.Models.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stproj.DAL.Presistance.Data.Configurations.EmpConfig
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            builder.Property(e => e.Adress).IsRequired(false).HasMaxLength(100).HasColumnType("varchar");
            builder.Property(e => e.salary).HasColumnType("decimal(8,2)");
            builder.Property(e => e.Gender)
                    .HasConversion
                    (
                        G => G.ToString(),
                        G => (Gender)Enum.Parse(typeof(Gender), G)
                    );

            builder.Property(e => e.EmployeeType)
                    .HasConversion
                    (
                        E => E.ToString(),
                        E => (EmployeeType)Enum.Parse(typeof(EmployeeType), E)
                    );





        }
    }
}
