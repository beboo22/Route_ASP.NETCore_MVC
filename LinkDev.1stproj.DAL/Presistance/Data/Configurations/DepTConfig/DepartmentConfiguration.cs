using LinkDev._1stproj.DAL.Models.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev._1stproj.DAL.Presistance.Data.Configurations.DepTConfig
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder.ToTable("Departments");

            //
            builder.Property(d => d.code)
                .IsRequired();   // Make code a required field

            // Property configurations
            builder.Property(d => d.Name)
                .IsRequired()    // Make Name a required field
                .HasMaxLength(100);   // Maximum length for Name


            builder.Property(d => d.Description)
                .HasMaxLength(250);  // Maximum length for Description

            builder.Property(d => d.CreationDate)
                .IsRequired();

            builder.HasMany(d => d.Employees)
                .WithOne(E => E.Department)
                .HasForeignKey(e => e.DepartmentId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
