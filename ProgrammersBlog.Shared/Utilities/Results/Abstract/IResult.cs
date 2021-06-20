using ProgrammersBlog.Shared.Entities.Concrete;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus{ get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }
        
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
    }
}
