using System;
using System.Collections.Generic;
using System.Text;

namespace ScadaApp.Models.Interfaces
{
    public interface IResult
    {
        bool IsSuccessful { get; }
        string Message { get; }
        Exception Exception { get; }
    }
    public interface IResult<TValue> : IResult
    {
        TValue Return { get; }
    }
}
