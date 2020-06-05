using HardwareMall.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareMall.Manage
{
    public class JwtSetting
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }

        /// <summary>
        /// 加密key
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 生命周期
        /// </summary>
        public int Expires { get; set; }
        /// <summary>
        /// 是否验证生命周期
        /// </summary>
        public bool ValidateLifetime { get; set; }
        /// <summary>
        /// 验证头字段
        /// </summary>
        public string HeadField { get; set; }
        /// <summary>
        /// jwt验证前缀
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// 忽略验证的url
        /// </summary>
        public List<string> IgnoreUrls { get; set; }
    }
}
