﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Helpers.Abstract
{
    public interface IWritableOptions<out T> : IOptionsSnapshot<T> where T : class, new()
    {
        void Update(Action<T> applyChanges);
    }
}
