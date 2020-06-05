using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareMall.Model
{
    public class ProductPageRequestDto
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 页长
        /// </summary>
        public int limit { get; set; }

        /// <summary>
        /// 筛序条件
        /// </summary>
        public List<string> TypeIDArray { get; set; }

        /// <summary>
        /// 大分类Id
        /// </summary>
        public int GetTypeId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 大类型Id
        /// </summary>
        public int BigTypeId { get; set; }

        /// <summary>
        /// 商品推荐Id
        /// </summary>
        public string ReId { get; set; }
    }
}
