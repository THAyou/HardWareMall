using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HardwareMall.Manage.Controllers
{
    public class SystemController : Controller
    {
        /// <summary>
        /// 菜单管理
        /// </summary>
        /// <returns></returns>
        public IActionResult Menu()
        {
            return View();
        }

        /// <summary>
        /// 人员管理
        /// </summary>
        /// <returns></returns>
        public IActionResult UserManage()
        {
            return View();
        }

        /// <summary>
        /// 后台管理错误日志
        /// </summary>
        /// <returns></returns>
        public IActionResult ManageLog()
        {
            return View();
        }

        /// <summary>
        /// 前台网站错误日志
        /// </summary>
        /// <returns></returns>
        public IActionResult WebLog()
        {
            return View();
        }
    }
}