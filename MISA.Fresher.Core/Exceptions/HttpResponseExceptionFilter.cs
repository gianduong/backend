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
    /// <summary>
    /// hàm bắt ngoại lệ chung
    /// </summary>
    /// CreatedBy: NGDuong 18/08/2021)
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                // nếu là hàm exception đã viết săn thì trả về thêm dữ liệu bị lỗi
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
                // nếu không thì trả về lỗi hệ thống mặc định
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
