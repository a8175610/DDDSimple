using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Sample.Application.DTO.DTOS;
using DDD.Sample.Application.Interface;
using DDD.Sample.Domain.Aggregate;
using DDD.Sample.Domain.Event.DomainEvents;
using DDD.Sample.Domain.Repository.Interface;
using DDD.Sample.Infrastructure.Helper;
using DDD.Sample.Infrastructure.Interface;
using DDD.Sample.Infrastructure.Interface.DomainEventCore;
using DDD.Sample.Infrastructure.Result;

namespace DDD.Sample.Application
{
    /// <summary>
    /// Student服务
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBus _eventBus;

        public StudentService(IStudentRepository studentRepository, 
            IUnitOfWork unitOfWork,
            IEventBus eventBus)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _eventBus = eventBus;
        }

        /// <summary>
        /// 获取指定id的StudengDto
        /// </summary>
        /// <param name="id">Student.Id</param>
        /// <returns>StudentDTO</returns>
        public StudentDTO Get(Guid id)
        {
            var student = _studentRepository.GetByExpression(r => r.Id == id).FirstOrDefault();
            return student.MapTo<StudentDTO>();
        }

        /// <summary>
        /// 获取所有StudentDto
        /// </summary>
        /// <returns>IList<StudentDTO></returns>
        public IList<StudentDTO> GetAll()
        {
            var studentList = _studentRepository.GetByExpression(r => true);
            return studentList.MapToList<StudentDTO>();
        }

        /// <summary>
        /// 获取指定名称的StudentDTO
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IList<StudentDTO> GetByName(string name)
        {
            var studentList = _studentRepository.GetByExpression(r => r.Name == name);
            return studentList.MapToList<StudentDTO>();
        }

        /// <summary>
        /// 添加Student信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="age">年龄</param>
        /// <returns></returns>
        public Result AddStudent(string name, int age)
        {
            var errMsg = "添加学生信息失败";
            try
            {
                var student = new Student
                {
                    Name = name,
                    Age = age
                };
                _studentRepository.Add(student);
                var result = _unitOfWork.Commit();
                //使用事件总线进行事件发布
                var studentAddedEvent = new StudentAddedEvent
                {
                    Id = Guid.NewGuid(),
                    Student = student,
                    TimeSpan = DateTime.Now
                };
                _eventBus.PublishAsync<StudentAddedEvent>(studentAddedEvent);
                return result ? Result.Success() : Result.Fail(errMsg);
            }
            catch (Exception e)
            {
                LogHelper.WriteLog(errMsg, e);
                return Result.Fail(errMsg);
            }
        }

        /// <summary>
        /// 删除Student信息
        /// </summary>
        /// <param name="id">Student.Id</param>
        /// <returns></returns>
        public Result DeleteStudent(Guid id)
        {
            var errMsg = "删除学生信息失败";
            try
            {
                var student = _studentRepository.GetByExpression(r => r.Id == id).FirstOrDefault();
                if (student == null)
                    return Result.Fail("找不到对应学生.");

                _studentRepository.Delete(student);
                var result = _unitOfWork.Commit();
                return result ? Result.Success() : Result.Fail(errMsg);
            }
            catch (Exception e)
            {
                LogHelper.WriteLog(errMsg, e);
                return Result.Fail(errMsg);
            }
        }

        /// <summary>
        /// 更新Student信息
        /// </summary>
        /// <param name="id">Student.Id</param>
        /// <param name="name">姓名</param>
        /// <param name="age">年龄</param>
        /// <returns></returns>
        public Result UpdateStudent(Guid id, string name, int age)
        {
            var errMsg = "修改学生信息失败";
            try
            {
                var student = _studentRepository.GetByExpression(r => r.Id == id).FirstOrDefault();
                if(student == null)
                    return Result.Fail("找不到对应学生.");

                student.ModifyInfo(name, age);
                _studentRepository.Modify(student);
                var result = _unitOfWork.Commit();
                return result ? Result.Success() : Result.Fail(errMsg);
            }
            catch (Exception e)
            {
                LogHelper.WriteLog(errMsg, e);
                return Result.Fail(errMsg);
            }
        }
    }
}
