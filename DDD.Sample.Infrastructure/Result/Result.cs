using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sample.Infrastructure.Result
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Msg { get; set; }
        public static Result Success(string msg)
        {
            return new Result()
            {
                IsSuccess = true,
                Msg = msg
            };
        }

        public static Result Success()
        {
            return Success(string.Empty);
        }

        public static Result Fail(string msg)
        {
            return new Result()
            {
                IsSuccess = false,
                Msg = msg
            };
        }

        public static Result Fail()
        {
            return Fail(string.Empty);
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }

        public static Result<T> Success(string msg, T data)
        {
            return new Result<T>()
            {
                IsSuccess = true,
                Msg = msg,
                Data = data
            };
        }

        public static Result<T> Success(T data)
        {
            return Success(string.Empty, data);
        }

        public static Result<T> Fail(string msg, T data)
        {
            return new Result<T>()
            {
                IsSuccess = false,
                Msg = msg,
                Data = data
            };
        }

        public static Result<T> Fail(T data)
        {
            return Fail(string.Empty, data);
        }
    }
}
