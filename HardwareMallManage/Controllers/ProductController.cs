using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HardwareMall.Manage.Controllers
{
    /// <summary>
    /// 产品管理
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// 产品列表
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductList()
        {
            return View();
        }

        /// <summary>
        /// 产品详情
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public IActionResult ProductDetails(string ProductId = "0")
        {
            ViewData["ProductId"] = ProductId;
            return View();
        }

        /// <summary>
        /// 上传产品图片
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public IActionResult UploadProductImg(string ProductId = "0")
        {
            ViewData["ProductId"] = ProductId;
            return View();
        }

        /// <summary>
        /// 产品分类管理
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductTypeList()
        {
            return View();
        }

        /// <summary>
        /// 客户联系列表
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductOrder()
        {
            return View();
        }

        /// <summary>
        /// 客户联系详细
        /// </summary>
        /// <returns></returns>
        public IActionResult ProdcutOrderEdit(string Id="0")
        {
            ViewData["Id"] = Id;
            return View(); 
        }

        /// <summary>
        /// 客户意见表
        /// </summary>
        /// <returns></returns>
        public IActionResult Intention()
        {
            return View();
        }

        /// <summary>
        /// 产品推荐
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductRe()
        {
            return View();
        }

        /// <summary>
        /// 产品包装管理
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductPackage(string ProductId = "0", string FormatId = "0")
        {
            ViewData["ProductId"] = ProductId;
            ViewData["FormatId"] = FormatId;
            return View();
        }
    }
}