using Bll.HardwareMall;
using HardwareMall.Tool;
using Microsoft.AspNetCore.Mvc;
using Model.HardwareMall;
using System.Collections.Generic;

namespace HardwareMall.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly BllW_ProductType _productType = Bll.Base.HardwareMall.BllW_ProductType.Instance();
        private readonly BllW_Product _product = Bll.Base.HardwareMall.BllW_Product.Instance();
        private readonly BllW_ProductImg _productImg = Bll.Base.HardwareMall.BllW_ProductImg.Instance();
        private readonly BllW_ProductPackage _productPackage = Bll.Base.HardwareMall.BllW_ProductPackage.Instance();
        private readonly BllW_ProductFormat _productFormat = Bll.Base.HardwareMall.BllW_ProductFormat.Instance();
        private readonly IUser _user;
        public ProductController(IUser user)
        {
            _user = user;
        }

        /// <summary>
        /// 产品列表页
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductList(string page="1",int ProTypeId = 0, int ProBigTypeId = 0, string ProductName = "",string ReId="0")
        {
            ViewData["page"] = page;
            ViewData["ProTypeInfo"] = _productType.GetModel(ProTypeId);
            ViewData["ProBigTypeId"] = ProBigTypeId;
            ViewData["ReId"] = ReId;
            ViewBag.ProductName = ProductName;
            return View();
        }

        /// <summary>
        /// 产品详情页
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductDetails(int ProductId = 0)
        {
            var ProductInfo = _product.GetModel(ProductId);
            ViewData["ProductInfo"] = ProductInfo;
            ViewData["ImgList"] = _productImg.GetProductImg(ProductId);
            ViewData["Packagelist"] = _productPackage.GetProductPackageList(ProductId);
            ViewData["SkillParameter"] = ProductInfo.SkillParameter.ToObject<List<JsonDto>>();
            ViewData["ProductFormat"] = _productFormat.GetProductFormatList(ProductId);
            return View();
        }

        /// <summary>
        /// 购物车页面
        /// </summary>
        /// <returns></returns>
        public IActionResult ShopCart()
        {
            //获取购物车详情
            ViewData["ShopCartProList"] = _product.GetShopCartProList(_user.ShoppingCart);
            return View();
        }
    }
}