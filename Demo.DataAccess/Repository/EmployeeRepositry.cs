using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repository
{
    public class EmployeeRepositry : IEmployeeRepositry
    {
        private readonly ApplicationDbContext _dbcontext;

        public EmployeeRepositry(ApplicationDbContext dbcontext) // injection 
        {
            _dbcontext = dbcontext;


        }
        // Get All
        public IEnumerable<Employee> GetAll(string? EmployeeSearchName)
        {
            if (!string.IsNullOrWhiteSpace(EmployeeSearchName))
                return _dbcontext.Employees.Where(e => e.Name.ToLower().Contains(EmployeeSearchName.ToLower())).ToList();
                //return _dbcontext.Employees
                //    .Where(e => e.Name.ToLower().Contains(EmployeeSearchName.ToLower())
                //             || e.Email.ToLower().Contains(EmployeeSearchName.ToLower()))
                //    .ToList();
            else
                return _dbcontext.Employees.ToList();

        }
        //GetById
        public Employee? GetById(int id)
        {
            var Employee = _dbcontext.Employees.FirstOrDefault(d => d.Id == id);
            return Employee;
        }
        //Add
        public int Add(Employee d)
        {
            _dbcontext.Employees.Add(d);
            return _dbcontext.SaveChanges();

        }
        //Update
        public int Update(Employee d)
        {
            _dbcontext.Employees.Update(d);
            return _dbcontext.SaveChanges();
        }
        //Delete
        public int Delete(int id)
        {
            var data = _dbcontext.Employees.FirstOrDefault(d => d.Id == id);
            if (data is null) return 0;
            _dbcontext.Employees.Remove(data);
            return _dbcontext.SaveChanges();


        }
    }
}
