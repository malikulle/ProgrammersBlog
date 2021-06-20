using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Shared.Entities.Abstract
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; }
        public virtual int CurrentPage { get; set; } = 1;
        public virtual int PageSize { get; set; } = 3;
        public virtual int TotalCount { get; set; } 
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(this.TotalCount, this.PageSize));
        public virtual bool ShowPrevious => this.CurrentPage > 1;
        public virtual bool ShowNext => this.CurrentPage < this.TotalPages;
        public virtual bool IsAscending { get; set; } = false;
    }
}
