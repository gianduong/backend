using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MISA.Fresher.Core.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Exceptions
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                if (context.Exception is ValidateException exception)
                {
                    var response = new
                    {
                        userMsg = exception.Message,
                        devMsg = Properties.Resources.Error_Exception,
                        Data = exception.Data,
                        traceInfo = exception.StackTrace
                    };
                    context.Result = new ObjectResult(response)
                    {
                        StatusCode = 400,
                    };
                    context.ExceptionHandled = true;
                }
                else
                {
                    var response = new
                    {
                        userMsg = context.Exception.Message,
                        devMsg = Properties.Resources.Error_Exception,
                        traceInfo = context.Exception.StackTrace
                    };
                    context.Result = new ObjectResult(response)
                    {
                        StatusCode = 500,
                    };
                    context.ExceptionHandled = true;
                }
            }

        }
    }
}
