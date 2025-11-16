using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; } // pk
       
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public int Age { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public string? PhoneNumber { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? CreatedOn { get; set; } 
        public DateTime? LastModifiedOn { get; set; }
    }
}
