using Demo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configration
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e => e.EmployeeType).HasConversion(e => e.ToString(), e => (EmployeeType)Enum.Parse(typeof(EmployeeType), e, true));
            // convert enum to string retutn convert to  enum 
            builder.Property(e => e.CreatedOn).HasDefaultValueSql("GetDATE()"); // defualt value
            builder.Property(e => e.LastModifiedOn).HasComputedColumnSql("GetDATE()"); // computed automatic
        }
    }
}
