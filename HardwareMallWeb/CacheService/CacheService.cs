using Bll.HardwareMall;
using Microsoft.Extensions.Caching.Memory;
using Model.HardwareMall;
using System.Collections.Generic;
using HardwareMall.Tool;
using HardwareMall.Cache;
using HardwareMall.Model;
using HardwareMall.Tool.EnumHelper;
using Model.HardwareMall_Chinese;
using Bll.HardwareMall_Chinese;

namespace HardwareMall.Web.CacheService
{
    /// <summary>
    /// 缓存服务
    /// </summary>
    public class CacheService : ICacheService
    {
        private readonly BllM_HomeElement _homeElement = Bll.Base.HardwareMall.BllM_HomeElement.Instance();
        private readonly BllW_ProductType _productType = Bll.Base.HardwareMall.BllW_ProductType.Instance();
        private readonly BllM_News _news = Bll.Base.HardwareMall.BllM_News.Instance();
        private readonly BllM_ProductRe _productRe = Bll.Base.HardwareMall_Chinese.BllM_ProductRe.Instance();
        private readonly IMemoryCache _cache;
        private readonly IUser _user;

        public CacheService(IMemoryCache cache, IUser user)
        {
            _user = user;
            _cache = cache;
        }

        /// <summary>
        /// 清理缓存
        /// </summary>
        public void ClearCache(string CacheKey = null)
        {
            if (CacheKey == null)
            {
                //目前所有缓存Key
                string[] CacheKeys = { "HomeElement", "ProductType", "News1", "News2", "Tel", "RecordNum", "Re", "FaceBook" };
                foreach (var k in CacheKeys)
                {
                    var CacheObj = _cache.Get<object>(k);
                    //如果有缓存，就重置缓存为空
                    if (CacheObj != null)
                    {
                        _cache.Set<object>(k, null);
                    }
                }
            }
            else
            {
                var CacheObj = _cache.Get<object>(CacheKey);
                //如果有缓存，就重置缓存为空
                if (CacheObj != null)
                {
                    _cache.Set<object>(CacheKey, null);
                }
            }
        }

        /// <summary>
        /// 读取首页配置并缓存
        /// </summary>
        /// <returns></returns>
        public List<ModM_HomeElement> GetHomeElementInCache()
        {
            var CacheKey = "HomeElement";
            var CacheObj = _cache.Get<List<ModM_HomeElement>>(CacheKey);
            var result = new List<ModM_HomeElement>();
            if (CacheObj == null || CacheObj.Count == 0)
            {
                result = _homeElement.GetHomeElement();
                _cache.Set<List<ModM_HomeElement>>(CacheKey, result);
            }
            else
            {
                result = CacheObj;
            }
            return result;
        }

        /// <summary>
        /// 获取页面上的联系电话并缓存
        /// </summary>
        /// <returns></returns>
        public string GetTel()
        {
            var CacheKey = "Tel";
            var CacheEmail = _cache.Get<string>(CacheKey);
            var result = string.Empty;
            if (string.IsNullOrWhiteSpace(CacheEmail))
            {
                var Info = _homeElement.GetHomeElement((int)HomeElementType.Tel);
                if (Info != null)
                {
                    result = Info.Title;
                }
                _cache.Set(CacheKey, result);
            }
            else
            {
                result = CacheEmail;
            }
            return result;
        }

        /// <summary>
        /// 获取页面上备案号并缓存
        /// </summary>
        /// <returns></returns>
        public string GetRecordNum()
        {
            var CacheKey = "RecordNum";
            var CacheEmail = _cache.Get<string>(CacheKey);
            var result = string.Empty;
            if (string.IsNullOrWhiteSpace(CacheEmail))
            {
                var Info = _homeElement.GetHomeElement((int)HomeElementType.RecordNum);
                if (Info != null)
                {
                    result = Info.Title;
                }
                _cache.Set(CacheKey, result);
            }
            else
            {
                result = CacheEmail;
            }
            return result;
        }

        /// <summary>
        /// 加载产品分类信息
        /// </summary>
        public List<ModW_ProductType> GetProductTypeList()
        {
            var CacheKey = "ProductType";
            var CacheObj = _cache.Get<List<ModW_ProductType>>(CacheKey);
            var result = new List<ModW_ProductType>();
            if (CacheObj == null || CacheObj.Count <= 0)
            {
                result = _productType.GetProductTypeList();
                _cache.Set(CacheKey, result);
            }
            else
            {
                result = CacheObj;
            }
            return result;
        }

        /// <summary>
        /// 获取首页新闻列表，并缓存
        /// </summary>
        /// <returns></returns>
        public List<NewsDto> GetNewsDto(int NewsType)
        {
            var CacheKey = "News" + NewsType;
            var CacheObj = _cache.Get<List<NewsDto>>(CacheKey);
            var result = new List<NewsDto>();
            if (CacheObj == null || CacheObj.Count <= 0)
            {
                result = _news.GetHomeNews(NewsType);
                _cache.Set(CacheKey, result);
            }
            else
            {
                result = CacheObj;
            }
            return result;
        }

        /// <summary>
        /// 获取首页商品推荐，并缓存
        /// </summary>
        /// <returns></returns>
        public List<ModM_ProductRe> GetProductRe()
        {
            var CacheKey = "Re";
            var CacheObj = _cache.Get<List<ModM_ProductRe>>(CacheKey);
            var result = new List<ModM_ProductRe>();
            if (CacheObj == null || CacheObj.Count <= 0)
            {
                result = _productRe.GetProductReList();
                _cache.Set(CacheKey, result);
            }
            else
            {
                result = CacheObj;
            }
            return result;
        }

        /// <summary>
        /// 获取FaceBook地址，并且缓存
        /// </summary>
        /// <returns></returns>
        public string GetFaceBookUrl()
        {
            var CacheKey = "FaceBook";
            var CacheObj = _cache.Get<string>(CacheKey);
            var result = string.Empty;
            if (string.IsNullOrWhiteSpace(CacheObj))
            {
                var Info = _homeElement.GetHomeElement((int)HomeElementType.FaceBookUrl);
                if (Info != null)
                {
                    result = Info.Href;
                }
                _cache.Set(CacheKey, result);
            }
            else
            {
                result = CacheObj;
            }
            return result;
        }
    }
}
