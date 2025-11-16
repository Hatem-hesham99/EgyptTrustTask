using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repository
{
    public interface IEmployeeRepositry
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(int id);
        int Add(Employee d);
        int Update(Employee d);
        int Delete(int d);
    }
}
