using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareMall.Web.Model
{
    /// <summary>
    /// API 返回JSON字符串
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }
    }

    public class ApiResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }
    }
}
