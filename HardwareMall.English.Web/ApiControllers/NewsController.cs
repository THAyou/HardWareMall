using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll.HardwareMall;
using HardwareMall.Model;
using HardwareMall.Web.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardwareMall.Web.ApiControllers
{
    /// <summary>
    /// 新闻功能Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly BllM_News _news = Bll.Base.HardwareMall.BllM_News.Instance();

        /// <summary>
        /// 获取产品分页列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("getNewsPageList")]
        public ApiResult<PageModel<NewsDto>> GetNewsPageList(int page=1, int limit=10,int NewsType=1)
        {
            var result = new ApiResult<PageModel<NewsDto>>() { Success = false, Message = "操作失败" };
            var Data = _news.GetNewPageList(page, limit, NewsType);
            if (Data != null)
            {
                result.Message = "操作成功";
                result.Success = true;
                result.Data = Data;
            }
            return result;
        }

        /// <summary>
        /// 获取新闻内容
        /// </summary>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        [HttpGet("getNewsContent")]
        public ApiResult<object> GetNewsContent(int NewsId)
        {
            var result = new ApiResult<object>() { Success = false, Message = "操作失败" };
            var Data = _news.GetNewsContent(NewsId);
            if (Data != null)
            {
                result.Message = "操作成功";
                result.Success = true;
                result.Data = Data;
            }
            return result;
        }
    }
}