using HardwareMall.Cache;
using HardwareMall.Web.CacheService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareMall.Web.MiddleWare
{
    /// <summary>
    /// 
    /// </summary>
    public class LoadMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ICacheService _cacheService;
        private readonly IUser _user;


        /// <summary>
        /// 项目缓存
        /// Dgs 2020-01-16 12:10
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logHelper"></param>
        public LoadMiddleWare(RequestDelegate next, ICacheService cacheService, IUser user)
        {
            _cacheService = cacheService;
            _user = user;
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            CacheStaticObj.ShoppingCart = _user.ShoppingCart;
            CacheStaticObj.ProductTypeList=_cacheService.GetProductTypeList();
            CacheStaticObj.Tel = _cacheService.GetTel();
            CacheStaticObj.RecordNum = _cacheService.GetRecordNum();
            CacheStaticObj.HomeElement = _cacheService.GetHomeElementInCache();
            CacheStaticObj.FaceBookUrl = _cacheService.GetFaceBookUrl();
            await _next(context);
        }
    }

    /// <summary>
    /// 扩展方法，将中间件暴露出去
    /// </summary>
    public static class LoadMiddleWareTo
    {
        /// <summary>
        /// 注册中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseLoad(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoadMiddleWare>();
        }
    }
}
