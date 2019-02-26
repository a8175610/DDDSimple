using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DDD.Sample.Application.DTO;
using DDD.Sample.Application.DTO.DTOS;
using DDD.Sample.Domain;
using DDD.Sample.Domain.Aggregate;

namespace DDD.Sample.Application.DTO.DTOMaper.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            //创建默认映射
            CreateMap<StudentDTO, Student>().ReverseMap();
        }
    }
}
