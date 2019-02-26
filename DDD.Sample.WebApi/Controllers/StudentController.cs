using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Routing;
using DDD.Sample.Application.DTO.DTOS;
using DDD.Sample.Application.Interface;
using DDD.Sample.Infrastructure.Result;

namespace DDD.Sample.WebApi.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// 获取所有学生信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        public IList<StudentDTO> GetStudentList()
        {
            var resultList = _studentService.GetAll();
            return resultList;
        }

        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public Result AddStudent([FromBody]StudentDTO student)
        {
            try
            {
                var result = _studentService.AddStudent(student.Name, student.Age);
                return result;
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
            
        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("del")]
        public Result DelStudent([FromBody]StudentDTO student)
        {
            try
            {
                var result = _studentService.DeleteStudent(student.Id);
                return result;
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("put")]
        public Result ModifyStudent([FromBody]StudentDTO student)
        {
            try
            {
                var result = _studentService.UpdateStudent(student.Id, student.Name, student.Age);
                return result;
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }
    }
}