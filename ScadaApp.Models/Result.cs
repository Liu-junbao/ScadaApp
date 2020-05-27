using ScadaApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScadaApp.Models
{
    public struct Result : IResult
    {
        public Result(bool isSuccessful, string message = null, Exception exception = null)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            Exception = exception;
        }
        public Result(string message, Exception exception)
        {
            IsSuccessful = false;
            Message = message;
            Exception = exception;
        }
        public bool IsSuccessful { get; }
        public string Message { get; }
        public Exception Exception { get; }

        public static Result Completed = new Result(true);
    }
    public struct Result<TValue> : IResult<TValue>
    {
        public Result(TValue value)
        {
            Return = value;
            IsSuccessful = true;
            Message = null;
            Exception = null;
        }
        public Result(string message, Exception exception)
        {
            Return = default;
            IsSuccessful = false;
            Message = message;
            Exception = exception;
        }
        public bool IsSuccessful { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public TValue Return { get; }
    }

    public static partial class Extensions
    {
        /// <summary>
        /// 成功执行完成
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IResult AsSuccessful(this object obj) => new Result(true);
        /// <summary>
        /// 执行失败
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static IResult AsFail(this string message) => new Result(false,message);

        /// <summary>
        /// 任务执行异常
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static IResult AsResult(this Exception e) => new Result(e.Message,e);

        /// <summary>
        /// 任务执行成功，返回结果
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IResult<TValue> AsResult<TValue>(this TValue value) => new Result<TValue>(value);
        
        /// <summary>
        /// 任务执行异常
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public static IResult<TValue> AsResult<TValue>(this Exception e) => new Result<TValue>(e.Message,e);
    }
}
