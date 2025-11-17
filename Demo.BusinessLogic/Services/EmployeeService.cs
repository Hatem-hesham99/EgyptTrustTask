using AutoMapper;
using Demo.BusinessLogic.Dtos;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services
{
    public class EmployeeService(IEmployeeRepositry _employeeRepositry, IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAll(string? EmployeeSearchName)
        {
            var data = _employeeRepositry.GetAll(EmployeeSearchName);
            var empdto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(data);
            return empdto; 
        }

        public EmployeeDetailsDto? GetById(int id)
        {
            var data = _employeeRepositry.GetById(id);
            if (data == null) return null;
            var empdto = _mapper.Map<Employee, EmployeeDetailsDto>(data);
            return empdto;
        }

        public int CreatEmp(CreatEmployeeDto creatEmployeeDto)
        {
            var emp = _mapper.Map<CreatEmployeeDto, Employee>(creatEmployeeDto);
            return _employeeRepositry.Add(emp);
        }
        public int UpdateEmp(UpdateEmployeeDto updateEmployeeDto)
        {
            var emp = _mapper.Map<UpdateEmployeeDto, Employee>(updateEmployeeDto);

            return _employeeRepositry.Update(emp);
        }


        public bool DeleteEmp(int id)
        {
            //var emp = _employeeRepositry.GetById(id);
            //if (emp is null) return false;
            var isdalet = _employeeRepositry.Delete(id);
            return isdalet > 0 ? true : false;

        }
    }
}
