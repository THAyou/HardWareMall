using Model.HardwareMall;
using System.Collections.Generic;

namespace HardwareMall.Model
{
    public class ProductOrderDto
    {
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string ContactDetails { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 产品信息
        /// </summary>
        public List<ModW_OrderDetails> ProductInfo { get; set; }

        /// <summary>
        /// 购物车GUID
        /// </summary>
        public List<string> ShopId { get; set; }
    }
}
