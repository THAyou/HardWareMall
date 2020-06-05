using HardwareMall.Model;
using Model.HardwareMall;
using Model.HardwareMall_Chinese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareMall.Web.CacheService
{
    /// <summary>
    /// 缓存服务接口
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// 获取首页配置并缓存
        /// </summary>
        /// <returns></returns>
        List<ModM_HomeElement> GetHomeElementInCache();


        /// <summary>
        /// 获取分类信息
        /// </summary>
        List<ModW_ProductType> GetProductTypeList();


        /// <summary>
        /// 获取首页新闻列表，并缓存
        /// </summary>
        /// <param name="NewsType"></param>
        /// <returns></returns>
        List<NewsDto> GetNewsDto(int NewsType);


        /// <summary>
        /// 清理缓存
        /// </summary>
        void ClearCache(string CacheKey = null);

        /// <summary>
        /// 获取页面上的联系电话并缓存
        /// </summary>
        /// <returns></returns>
        string GetTel();


        /// <summary>
        /// 获取页面上的备案号并缓存
        /// </summary>
        /// <returns></returns>
        string GetRecordNum();


        /// <summary>
        /// 获取首页商品推荐，并缓存
        /// </summary>
        /// <returns></returns>
        List<ModM_ProductRe> GetProductRe();

        /// <summary>
        /// 获取FaceBook跳转地址，并缓存
        /// </summary>
        /// <returns></returns>
        string GetFaceBookUrl();


    }
}
