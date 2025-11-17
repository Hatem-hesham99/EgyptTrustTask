using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Dtos
{
    public class CreatEmployeeDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max length should be 50 character")]
        [MinLength(5, ErrorMessage = "Min length should be 5 characters")]
        public string Name { get; set; } = null!;
        [Range(22, double.MaxValue, ErrorMessage = "age must be at least 22.")] 
        public int? Age { get; set; }
        //[RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$"
        [MinLength(5, ErrorMessage = "Min length should be 5 characters")]
        public string? Address { get; set; }
        [DataType(DataType.Currency)]
        [Range(2000, double.MaxValue, ErrorMessage = "Salary must be at least 2000.")]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        [Required(ErrorMessage = "must be insert Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
