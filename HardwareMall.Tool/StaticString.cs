using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareMall.Tool
{
    public static class StaticString
    {
        /// <summary>
        /// 购物车Key
        /// </summary>
        public readonly static string ShopKey = ConfigHelper.Configuration["ShopKey"].ToString();

        /// <summary>
        /// 购物车有效天数
        /// </summary>
        public readonly static string ShopDayTime = ConfigHelper.Configuration["ShopDayTime"].ToString();

        /// <summary>
        /// 产品图片前缀
        /// </summary>
        public readonly static string ImgServerUrl = ConfigHelper.Configuration["ImgServerUrl"].ToString();

    }
}
