using HardwareMall.Tool;
using Model.HardwareMall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareMall.Cache
{
    /// <summary>
    /// 所有缓存的静态对象
    /// </summary>
    public static class CacheStaticObj
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        public static string Email;

        /// <summary>
        /// 产品分类集合
        /// </summary>
        public static List<ModW_ProductType> ProductTypeList;

        /// <summary>
        /// 购物车信息
        /// </summary>
        public static List<ShoppingCartDto> ShoppingCart;

        /// <summary>
        /// 联系电话
        /// </summary>
        public static string Tel;

        /// <summary>
        /// 备案号
        /// </summary>
        public static string RecordNum;


        public static List<ModM_HomeElement> HomeElement;

        /// <summary>
        /// FaceBook跳转地址
        /// </summary>
        public static string FaceBookUrl;

        /// <summary>
        /// 英文站Url
        /// </summary>
        public static string EnglishUrl= ConfigHelper.Configuration["EnglishUrl"].ToString();

        /// <summary>
        /// 中文站Url
        /// </summary>
        public static string ChineseUrl = ConfigHelper.Configuration["ChineseUrl"].ToString();
    }
}
