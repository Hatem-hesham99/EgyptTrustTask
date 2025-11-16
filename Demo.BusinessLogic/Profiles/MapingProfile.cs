using AutoMapper;
using Demo.BusinessLogic.Dtos;
using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Profiles
{
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
              .ForMember(dis => dis.EmployeeType, src => src.MapFrom(op => op.EmployeeType));
            CreateMap<Employee, EmployeeDetailsDto>()            
                    .ForMember(dis => dis.EmployeeType, src => src.MapFrom(op => op.EmployeeType))
                    .ForMember(dis => dis.HireDate, op => op.MapFrom(src => DateOnly.FromDateTime(src.HireDate)));

            CreateMap<CreatEmployeeDto, Employee>()
                .ForMember(dis => dis.HireDate, op => op.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(dis => dis.HireDate, op => op.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
