using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{
    public class ShoppingCartDto
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string GUID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// 包装Id
        /// </summary>
        public int? PackageId { get; set; }

        /// <summary>
        /// 包装Id
        /// </summary>
        public int? FormatId { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal? Amount { get; set; }
    }
}
