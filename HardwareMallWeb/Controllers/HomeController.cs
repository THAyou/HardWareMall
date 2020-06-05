using Bll.HardwareMall;
using HardwareMall.Cache;
using HardwareMall.Tool;
using HardwareMall.Tool.EnumHelper;
using HardwareMall.Web;
using HardwareMall.Web.CacheService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Model.HardwareMall;
using System.Collections.Generic;
using System.Linq;

namespace HardwareMallWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICacheService _cacheService;
        private readonly BllM_OtherConfig _otherConfig = Bll.Base.HardwareMall.BllM_OtherConfig.Instance();

        public HomeController(IUser user, ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //获取新闻列表
            ViewData["News1"] = _cacheService.GetNewsDto(1);
            ViewData["News2"] = _cacheService.GetNewsDto(2);
            //首页元素配置
            ViewData["HomeElement"] = CacheStaticObj.HomeElement;
            //商品推荐
            ViewData["ProductRe"] = _cacheService.GetProductRe();
            return View();
        }

        /// <summary>
        /// 品牌页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Brand()
        {
            var list = _otherConfig.GetOtherConfig((int)WebConfigEnum.Brand);
            var Info= (list != null && list.Count > 0) ? list[0] : null;
            //获取品牌页面内容
            ViewData["Brand"] = Info;
            //获取滚动图片
            ViewData["Img1"] = _otherConfig.GetImg(Info!= null ? Info.ImgIDs:"0");
            ViewData["Img2"] = _otherConfig.GetImg(Info != null ? Info.ImgIDs2 : "0");
            return View();
        }

        /// <summary>
        /// 服务页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Service()
        {
            ViewData["Service"] = _otherConfig.GetOtherConfig((int)WebConfigEnum.Service);
            return View();
        }

        /// <summary>
        /// 公司页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Company() 
        {
            var Info = _otherConfig.GetOtherConfig((int)WebConfigEnum.Company);
            ViewData["Company"] = (Info != null && Info.Count > 0) ? Info[0] : null;
            return View();
        }

        /// <summary>
        /// 招聘页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Job()
        {
            ViewData["Job"] = _otherConfig.GetOtherConfig((int)WebConfigEnum.Job);
            return View();
        }

        /// <summary>
        /// 联系页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Contact()
        {
            var Info = _otherConfig.GetOtherConfig((int)WebConfigEnum.Contact);
            ViewData["Contact"] = (Info != null && Info.Count > 0) ? Info[0] : null;
            return View();
        }

        /// <summary>
        /// 新闻页面
        /// </summary>
        /// <returns></returns>
        public IActionResult News(int NewType=1)
        {
            ViewData["NewType"] = NewType;
            return View();
        }

        /// <summary>
        /// 新闻内容页
        /// </summary>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        public IActionResult NewsContent(int NewsId)
        {
            ViewData["NewsId"] = NewsId;
            return View();
        }
    }
}
