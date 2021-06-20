using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProgrammersBlog.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.WebMvc.Filters
{
    public class MvcExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly IModelMetadataProvider _metadataProvider;
        private readonly ILogger _logger;

        public MvcExceptionFilter(IWebHostEnvironment env, IModelMetadataProvider metadataProvider, ILogger<MvcExceptionFilter> logger)
        {
            _metadataProvider = metadataProvider;
            _env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (_env.IsDevelopment())
            {
                context.ExceptionHandled = true;
                var Model = new MvcErrorModel();
                var result = new ViewResult()
                {
                    ViewName = "Error",
                    StatusCode = 500,
                    ViewData = new ViewDataDictionary(_metadataProvider, context.ModelState),
                };
                switch (context.Exception)
                {
                    case SqlNullValueException:
                        Model.Message = "Üzgünüz İşleminiz Sırasında Beklenmedik Bir Veritabanı Hatası Oluştu";
                        Model.Detail = context.Exception.Message;
                        result.StatusCode = 500;
                        _logger.LogError(context.Exception, context.Exception.Message);
                        break;
                    case NullReferenceException:
                        Model.Message = "Üzgünüz İşleminiz Sırasında Beklenmedik Bir Null Veriye Rastlandı.";
                        Model.Detail = context.Exception.Message;
                        result.StatusCode = 403;
                        _logger.LogError(context.Exception, context.Exception.Message);
                        break;
                    default:
                        Model.Message = "Üzgünüz İşleminiz Sırasında Beklenmedik Bir Hata Oluştu";
                        result.StatusCode = 500;
                        _logger.LogError(context.Exception, context.Exception.Message);
                        break;
                }

                result.ViewData.Add("MvcErrorModel", Model);
                context.Result = result;
            }

        }
    }
}
