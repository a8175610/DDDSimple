using System;
using System.Collections.Generic;
using DDD.Sample.Application.DTO.DTOS;
using DDD.Sample.Infrastructure.Result;

namespace DDD.Sample.Application.Interface
{
    public interface IStudentService
    {
        StudentDTO Get(Guid id);
        IList<StudentDTO> GetAll();
        IList<StudentDTO> GetByName(string name);
        Result AddStudent(string name, int age);
        Result DeleteStudent(Guid id);
        Result UpdateStudent(Guid id, string name, int age);
    }
}
