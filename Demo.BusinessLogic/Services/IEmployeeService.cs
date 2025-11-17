using Demo.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAll(string EmployeeSearchName);
        EmployeeDetailsDto? GetById(int id);
        int CreatEmp(CreatEmployeeDto creatEmployeeDto); // Fixed missing parameter name
        int UpdateEmp(UpdateEmployeeDto updateEmployeeDto); // Fixed missing parameter name
        bool DeleteEmp(int id);
    }
}
