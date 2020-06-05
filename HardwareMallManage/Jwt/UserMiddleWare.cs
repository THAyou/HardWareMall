using HardwareMall.Web.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareMall.Tool;

namespace HardwareMall.Manage
{
    /// <summary>
    /// 用户验证中间件
    /// </summary>
    public class UserMiddleWare
    {
        private readonly RequestDelegate _next;
        private IJwt _jwt;
        private JwtSetting _setting = new JwtSetting();
        private IConfiguration _configuration;

        public UserMiddleWare(RequestDelegate next, IConfiguration configration)
        {
            _next = next;
            _configuration = configration;
            _configuration.GetSection("JwtSettings").Bind(_setting);

        }

        /// <summary>
        /// 身份验证中间件
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, IJwt jwt)
        {
            _jwt = jwt;
            //请求地址
            var path = context.Request.Path.ToString().ToLower();

            if (_setting.IgnoreUrls.Contains(path))
            {
                await this._next(context);
                return;
            }
            else
            {
                var Cookies = context.Request.Cookies[_setting.HeadField];
                if (string.IsNullOrWhiteSpace(Cookies))
                {
                    //判断是页面还是Api
                    if (path.Split('/').Contains("api"))
                    {
                        ApiResult res = new ApiResult
                        {
                            Code = -101,
                            Message = "未登录,请登录后再进行操作"
                        };
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(res.ToJson()).ConfigureAwait(false);
                        return;
                    }
                    else //如果是页面就重定向去登录
                    {
                        context.Response.Redirect("/User/Login");
                        return;
                    }
                }

                //验证Token是否有效
                if (_jwt.IsToken(Cookies, out Dictionary<string, string> Clims))
                {
                    await _next(context);
                    return;
                }
                else
                {
                    //判断是页面还是Api
                    if (path.Split('/').Contains("api"))
                    {
                        ApiResult res = new ApiResult
                        {
                            Code = -101,
                            Message = "请重新登录后再进行操作"
                        };
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(res.ToJson()).ConfigureAwait(false);
                        return;
                    }
                    else //如果是页面就重定向去登录
                    {
                        context.Response.Redirect("/User/Login");
                        return;
                    }
                }
            }
        }
    }


    /// <summary>
    /// 扩展方法，将中间件暴露出去
    /// </summary>
    public static class UserMiddleWareTo
    {
        /// <summary>
        /// 权限检查
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseUser(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserMiddleWare>();
        }
    }
}
