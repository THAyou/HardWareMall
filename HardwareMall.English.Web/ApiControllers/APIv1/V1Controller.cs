using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareMall.Web.CacheService;
using HardwareMall.Web.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareMall.Web.ApiControllers
{
    /// <summary>
    /// 外部调用接口 V1版本
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class V1Controller : ControllerBase
    {
        private readonly ICacheService _cacheService;
        public V1Controller(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        /// <summary>
        /// 重置缓存
        /// </summary>
        /// <returns></returns>
        [HttpDelete("clearCache")]
        public ApiResult ClearCache([FromBody]dynamic data)
        {
            string Key = data.key;
            var res = new ApiResult() { Code=1,Success = true, Message = "调用成功" };
            Task t = new Task(() => _cacheService.ClearCache(Key));
            t.Start();
            return res;
        }
    }
}