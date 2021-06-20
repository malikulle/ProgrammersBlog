using ProgrammersBlog.Shared.Entities.Concrete;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {

        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, T data, IEnumerable<ValidationError> validationErrors)
        {
            ResultStatus = resultStatus;
            Data = data;
            ValidationErrors = validationErrors;
        }
        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
        }
        public DataResult(ResultStatus resultStatus, string message, T data, IEnumerable<ValidationError> validationErrors)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
            ValidationErrors = validationErrors;
        }
        public DataResult(ResultStatus resultStatus, string message, T data, Exception exception)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
            Exception = exception;
        }
        public DataResult(ResultStatus resultStatus, string message, T data, Exception exception, IEnumerable<ValidationError> validationErrors)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
            Exception = exception;
            ValidationErrors = validationErrors;
        }       
        public T Data { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
    }
}
