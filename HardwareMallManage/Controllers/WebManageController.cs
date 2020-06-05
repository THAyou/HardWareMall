using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HardwareMall.Manage.Controllers
{
    public class WebManageController : Controller
    {
        /// <summary>
        /// 首页管理
        /// </summary>
        /// <returns></returns>
        public IActionResult HomeManage()
        {
            return View();
        }

        /// <summary>
        /// 其他信息管理
        /// </summary>
        /// <returns></returns>
        public IActionResult OtherManage()
        {
            return View();
        }

        /// <summary>
        /// 其他信息管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult OtherManageEdit(string Id = "0")
        {
            ViewData["Id"] = Id;
            return View();
        }

        /// <summary>
        /// 品牌页编辑
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult OtherManageEditBrand(string Id = "0")
        {
            ViewData["Id"] = Id;
            return View();
        }

        /// <summary>
        /// 品牌页编辑没有图片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult OtherManageEditNoImg(string Id = "0")
        {
            ViewData["Id"] = Id;
            return View();
        }

        /// <summary>
        /// 新闻管理页
        /// </summary>
        /// <returns></returns>
        public IActionResult NewsManage()
        {
            return View();
        }

        /// <summary>
        /// 新闻编辑页
        /// </summary>
        /// <returns></returns>
        public IActionResult NewsEdit(string NewsId = "0")
        {
            ViewData["NewsId"] = NewsId;
            return View();
        }

        /// <summary>
        /// 新其他页面配置
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult NewOtherManageEdit(string Id = "0")
        {
            ViewData["Id"] = Id;
            return View();
        }
    }
}