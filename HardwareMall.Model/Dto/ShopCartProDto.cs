using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareMall.Model
{
    /// <summary>
    /// 购物车详情信息Dto
    /// </summary>
    public class ShopCartProDto
    {
        /// <summary>
        /// 标识
        /// </summary>
        public string GUID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public string ProductModel { get; set; }

        /// <summary>
        /// 订货号
        /// </summary>
        public string ProductBill { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// 规格Id
        /// </summary>
        public int? FormatId { get; set; }

        /// <summary>
        /// 规格名称
        /// </summary>
        public string FormatName { get; set; }

        /// <summary>
        /// 包装Id
        /// </summary>
        public int PackageId { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// 价格类型 
        /// </summary>
        public string PriceType { get; set; }

        /// <summary>
        /// 包装名称
        /// </summary>
        public string PackgeName { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// 产品图片
        /// </summary>
        public string ProductImg { get; set; }

        /// <summary>
        /// 包装数量
        /// </summary>
        public int PNum { get; set; }
    }
}
