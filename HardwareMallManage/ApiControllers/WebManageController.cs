using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll.HardwareMall;
using Bll.HardwareMall_Chinese;
using HardwareMall.Manage.User;
using HardwareMall.Tool;
using HardwareMall.Web.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.HardwareMall;
using Model.HardwareMall_Chinese;

namespace HardwareMall.Manage.ApiControllers
{
    /// <summary>
    /// 网站管理Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WebManageController : ControllerBase
    {
        private readonly BllM_HomeElement _homeElement= Bll.Base.HardwareMall.BllM_HomeElement.Instance();
        private readonly BllM_OtherConfig _otherConfig = Bll.Base.HardwareMall.BllM_OtherConfig.Instance();
        private readonly BllM_Img _img = Bll.Base.HardwareMall.BllM_Img.Instance();
        private readonly BllM_News _news = Bll.Base.HardwareMall.BllM_News.Instance();
        private readonly BllM_ProductRe _productRe = Bll.Base.HardwareMall_Chinese.BllM_ProductRe.Instance();
        private readonly BllM_PandR _pandR = Bll.Base.HardwareMall_Chinese.BllM_PandR.Instance();
        private readonly IUser _user;

        public WebManageController(IUser user)
        {
            _user = user;
        }

        /// <summary>
        /// 获取主页管理
        /// </summary>
        /// <returns></returns>
        [HttpGet("getHomeElementList")]
        public ApiResult<List<ModM_HomeElement>> GetHomeElementList(int ElementType = 0)
        {
            var res = new ApiResult<List<ModM_HomeElement>>() { Code = 0, Message = "操作失败", Success = true };
            var Data = _homeElement.GetHomeElementManage(ElementType);
            res.Data = Data;
            return res;
        }

        /// <summary>
        /// 保存首页元素
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        [HttpPost("saveHomeElement")]
        public ApiResult SaveHomeElement([FromBody]dynamic data,[FromQuery]int Type)
        {
            string Id = data.id;
            string homeTypeEnum = data.homeTypeEnum;
            string Img = data.img;
            string Title = data.title;
            string littleTitle = data.littleTitle;
            string Sort = data.sort;
            string href = data.href;
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            if (Type == 0)
            {
                _homeElement.UpdateHomeElement(new ModM_HomeElement
                {
                    Id = int.Parse(Id),
                    HomeTypeEnum = int.Parse(homeTypeEnum),
                    Img = Img.Replace('\\', '/'),
                    Title = Title,
                    LittleTitle = littleTitle,
                    Href = href,
                    UpdateUser = _user.UserId,
                    UpdateTime = DateTime.Now,
                    Sort = string.IsNullOrWhiteSpace(Sort) ? 0:int.Parse(Sort)
                }) ;
            }
            else if (Type == 1)
            {
                _homeElement.AddNoReturn(new ModM_HomeElement
                {
                    HomeTypeEnum = int.Parse(homeTypeEnum),
                    Img = Img,
                    Title = Title,
                    LittleTitle = littleTitle,
                    Href = href,
                    CreateUser = _user.UserId,
                    CreateTime = DateTime.Now,
                    Sort = string.IsNullOrWhiteSpace(Sort) ? 0 : int.Parse(Sort)
                });
            }
            return res;
        }

        /// <summary>
        /// 删除桌面元素
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete("delHomeElement")]
        public ApiResult DelHomeElement([FromBody]dynamic data)
        {
            string Id = data.Id;
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            _homeElement.Delete(int.Parse(Id));
            return res;
        }

        /// <summary>
        /// 清理前台缓存
        /// </summary>
        /// <returns></returns>
        [HttpDelete("clearCache")]
        public ApiResult ClearCache([FromBody]dynamic data)
        {
            string Key = data.key;
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            string ClearCache = ConfigHelper.Configuration["ClearCacheUrl"].ToString();
            HttpHelp.SendDeleteHttp(ClearCache, new { key = Key });
            return res;
        }

        /// <summary>
        /// 获取其他配置列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("getOtherConfig")]
        public ApiResult<object> GetOtherConfig(int WebConfigEnum=0)
        {
            var res = new ApiResult<object>() { Code = 0, Message = "操作成功", Success = true };
            var data = _otherConfig.GetOtherConfigList(WebConfigEnum);
            res.Data = data;
            return res;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("getOtherConfigInfo")]
        public ApiResult<object> GetOtherConfigInfo(int Id)
        {
            var res = new ApiResult<object>() { Code = 0, Message = "操作成功", Success = true };
            res.Data = _otherConfig.GetOtherConfigInfo(Id);
            return res;
        }

        /// <summary>
        /// 获取滚动图片
        /// </summary>
        /// <param name="ImgIds"></param>
        /// <returns></returns>
        [HttpPost("getOtherImgs")]
        public ApiResult<object> GetOtherImgs([FromBody]dynamic data)
        {
            string ImgIds = data.ImgIds;
            var res = new ApiResult<object>() { Code = 0, Message = "操作成功", Success = true };
            res.Data = _img.GetImgs(ImgIds);
            return res;
        }

        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut("saveOtherConfig")]
        public ApiResult SaveOtherConfig([FromBody]dynamic data)
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            string imgSrc = data.imgSrc;
            string title = data.title;
            string Id = data.Id;
            string content = data.content;
            var imgID=_img.Add(new ModM_Img
            {
                ImgSrc= imgSrc,
                CreateTime=DateTime.Now
            });
            _otherConfig.UpdateOtherConfigInfo(new ModM_OtherConfig 
            {
                Id=int.Parse(Id),
                TitleImg= imgID,
                Title= title,
                Content = content
            });
            return res;
        }

        /// <summary>
        /// 增加品牌页滚动图片
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut("addBrandImg")]
        public ApiResult AddBrandImg([FromBody] dynamic data)
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            string Id = data.Id;
            string ImgSrc = data.ImgSrc;
            string Type = data.Type;
            _otherConfig.AddBrandImg(int.Parse(Id), ImgSrc, Type);
            return res;
        }

        /// <summary>
        /// 增加品牌页滚动图片
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut("delBrandImg")]
        public ApiResult DelBrandImg([FromBody]dynamic data)
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            string Id = data.Id;
            string ImgId = data.ImgId;
            string Type = data.Type;
            _otherConfig.DelBrandImg(int.Parse(Id), ImgId, Type);
            return res;
        }

        /// <summary>
        /// 获取新闻管理列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("getNewsList")]
        public PageDTModel GetNewsList(int page=1, int limit=10,int NewsType=0)
        {
            return _news.GetNewManagePageList(page, limit, NewsType);
        }

        /// <summary>
        /// 获取新闻内容
        /// </summary>
        /// <returns></returns>
        [HttpGet("getNewsInfo")]
        public ApiResult<object> GetNewsInfo(int Id)
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            var Info = _news.GetModel(Id);
            Info.NewsContent = Info.NewsContent;
            res.Data = Info;
            return res;
        }

        /// <summary>
        /// 保存新闻
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut("saveNews")]
        public ApiResult<int> SaveNews([FromBody]dynamic data,[FromQuery]string Type)
        {
            string Id = data.Id;
            string newsContent = data.newsContent;
            string newsDataTime = data.newsDataTime;
            string newsTitle = data.newsTitle;
            string newsType = data.newsType;
            string imgSrc = data.imgSrc;
            var res = new ApiResult<int> { Code = 1, Message = "操作成功", Success = true };
            if (Type == "1")
            {
                var i=_news.Add(new ModM_News
                {
                    CreateTime = DateTime.Now,
                    NewsContent = newsContent,
                    NewsDataTime = Convert.ToDateTime(newsDataTime),
                    NewsTitle = newsTitle,
                    NewsType = int.Parse(newsType),
                    Img= imgSrc,
                });
                res.Data = i;
            }
            else if (Type == "0")
            {
                _news.Update(new ModM_News
                {
                    Id=int.Parse(Id),
                    CreateTime = DateTime.Now,
                    NewsContent = newsContent,
                    NewsDataTime = Convert.ToDateTime(newsDataTime),
                    NewsTitle = newsTitle,
                    NewsType = int.Parse(newsType),
                    Img = imgSrc,
                });
            }
            return res;
        }

        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete("delNews")]
        public ApiResult DelNews([FromBody]dynamic data)
        {
            string Id = data.Id;
            var res = new ApiResult { Code = 1, Message = "操作成功", Success = true };
            _news.Delete(int.Parse(Id));
            return res;
        }

        /// <summary>
        /// 获取产品推荐列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("getProductRe")]
        public ApiResult<object> GetProductRe()
        {
            var res = new ApiResult<object> { Code = 0, Message = "操作成功", Success = true };
            res.Data = _productRe.GetProductReList();
            return res;
        }

        /// <summary>
        /// 保存推荐
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("saveProductRe")]
        public ApiResult SaveProductRe([FromBody]dynamic data,[FromQuery]int Type)
        {
            string Id = data.id;
            string Name = data.name;
            string Url = data.url;
            string Title = data.title;
            string LittleTitle = data.littleTitle;
            string Img = data.img;
            var res = new ApiResult { Code = 1, Message = "操作成功", Success = true };
            if (Type == 1)
            {
                var list = _productRe.GetProductReList();
                if (list.Count >= 4)
                {
                    res.Code = 0;
                    res.Success = false;
                    res.Message = "最多可以设置4个推荐";
                    return res;
                }
                _productRe.AddNoReturn(new ModM_ProductRe
                {
                    Name = Name,
                    Url = Url,
                    Title = Title,
                    LittleTitle = LittleTitle,
                    Img = Img,
                    CreateTime = DateTime.Now,
                    CreateBy = _user.UserId
                });
            }
            else if(Type==0)
            {
                _productRe.Update(new ModM_ProductRe
                {
                    Id=int.Parse(Id),
                    Name = Name,
                    Url = Url,
                    Title = Title,
                    LittleTitle = LittleTitle,
                    Img = Img,
                    CreateTime = DateTime.Now,
                    CreateBy = _user.UserId
                });
            }
            return res;
        }

        /// <summary>
        /// 删除推荐
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete("delProductRe")]
        public ApiResult DelProductRe([FromBody]dynamic data)
        {
            string Id = data.id;
            var res = new ApiResult { Code = 1, Message = "操作成功", Success = true };
            _productRe.Delete(int.Parse(Id));
            return res;
        }
    }
}