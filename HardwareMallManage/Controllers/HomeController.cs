using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HardwareMallManage.Models;
using Bll.HardwareMall;

namespace HardwareMallManage.Controllers
{
    public class HomeController : Controller
    {
        private readonly BllM_Menu _menu = Bll.Base.HardwareMall.BllM_Menu.Instance();
        public IActionResult Index()
        {
            ViewData["Menu"] = _menu.GetMenuList();
            return View();
        }
    }
}
