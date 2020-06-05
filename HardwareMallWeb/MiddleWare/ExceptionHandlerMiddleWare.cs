using HardwareMall.Tool;
using HardwareMall.Web.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HardwareMall.Web.MiddleWare
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// 全局异常捕获
        /// Dgs 2020-01-16 12:10
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logHelper"></param>
        public ExceptionHandlerMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// 判断是否异常
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private async Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            if (exception == null) return;
            await WriteExceptionAsync(context, exception).ConfigureAwait(false);
        }

        /// <summary>
        /// 返回友好的提示
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private async Task WriteExceptionAsync(HttpContext context, System.Exception exception)
        {
            var route = context.Request.Path.ToString().ToLower();
            var IsApi = route.Split('/').Contains("api");
            //记录日志
            LogService.Error($"Url:[{route}],Error:[{exception.Message}]");
            LogService.Trace($"Url:[{route}],Error:[{exception.Message}],Trace:[{exception.StackTrace}]");
            var resMessage = string.Empty;
            //返回友好的提示
            var response = context.Response;
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var Condition = ConfigHelper.Configuration["Condition"];
            if (Condition == "1")
            {
                resMessage = "服务器出错，请联系管理员";
            }
            else
            {
                resMessage = exception.Message;
            }
            response.ContentType = "application/json";
            if (IsApi)
            {
                var res = new ApiResult();
                res.Success = false;
                res.Code = 0;
                res.Message = resMessage;
                await response.WriteAsync(res.ToJson()).ConfigureAwait(false);
                return;
            }
            else
            {
                context.Response.Redirect("/Error/E500");
                return;
            }
        }

        /// <summary>
        /// 对象转为Xml
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static string Object2XmlString(object o)
        {
            StringWriter sw = new StringWriter();
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                serializer.Serialize(sw, o);
            }
            catch
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Dispose();
            }
            return sw.ToString();
        }


    }

    /// <summary>
    /// 扩展方法，将中间件暴露出去
    /// </summary>
    public static class ExceptionMiddleWare
    {
        /// <summary>
        /// 权限检查
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleWare>();
        }
    }
}
