using Bll.HardwareMall;
using HardwareMall.Model;
using HardwareMall.Tool;
using HardwareMall.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Model.HardwareMall;
using System;
using System.Collections.Generic;

namespace HardwareMall.Web.ApiControllers
{
    /// <summary>
    /// 产品数据接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BllW_Product _product = Bll.Base.HardwareMall.BllW_Product.Instance();
        private readonly BllW_ProductOrder _productOrder = Bll.Base.HardwareMall.BllW_ProductOrder.Instance();
        private readonly BllW_ProductFormat _productFormat = Bll.Base.HardwareMall.BllW_ProductFormat.Instance();
        private readonly BllW_Intention _intention = Bll.Base.HardwareMall.BllW_Intention.Instance();
        private readonly BllW_OrderDetails _orderDetails = Bll.Base.HardwareMall.BllW_OrderDetails.Instance();
        private readonly BllW_ProductPackage _productPackage = Bll.Base.HardwareMall.BllW_ProductPackage.Instance();
        private readonly IUser _user;

        public ProductController(IUser user)
        {
            _user = user;
        }

        /// <summary>
        /// 获取产品分页列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("getProductPageList")]
        public ApiResult<PageDTModel> GetProductPageList([FromBody]ProductPageRequestDto data)
        {
            var result = new ApiResult<PageDTModel>() { Success = false, Message = "操作失败" };
            var Data = _product.GetProductPageList(data.page, data.limit, data.GetTypeId, data.TypeIDArray,data.ProductName,data.BigTypeId, data.ReId);
            if (Data != null)
            {
                result.Message = "操作成功";
                result.Success = true;
                result.Data = Data;
            }
            return result;
        }

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("addShop")]
        public ApiResult AddShop([FromBody]dynamic data)
        {
            var result = new ApiResult() { Success = false, Message = "操作失败" };
            string ProductId = data.ProductId;
            string Quantity = data.Quantity;
            string PackageId = data.PackageId;
            string FormatId = data.FormatId;
            string Amount = data.Amount;
            var ShopDto = new ShoppingCartDto()
            {
                GUID = Guid.NewGuid().ToString(),
                ProductId = int.Parse(ProductId),
                Quantity = int.Parse(Quantity),
                PackageId = int.Parse(PackageId),
                FormatId = int.Parse(FormatId),
                Amount = decimal.Parse(Amount)
            };
            _user.AddShoppingCarts(ShopDto);
            result.Message = "操作成功";
            result.Success = true;
            return result;
        }

        /// <summary>
        /// 提交订单(联系我们按钮)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("addOrder")]
        public ApiResult AddOrder([FromBody]ProductOrderDto data,[FromQuery]int Shop=0)
        {
            var result = new ApiResult() { Success = false, Message = "操作失败" };
            var NowDate = DateTime.Now;
            var ProductOrder = new ModW_ProductOrder
            {
                OrderCode = $"Pro{NowDate.ToString("yyyyMMddHHmmss")}",
                ClientName = data.ClientName,
                ContactDetails = data.ContactDetails,
                Email = data.Email,
                Remark = data.Remark,
                CreateTime= NowDate,
            };

            if (!string.IsNullOrWhiteSpace(data.ClientName) && !string.IsNullOrWhiteSpace(data.ContactDetails)&&!string.IsNullOrWhiteSpace(data.Email)&&(data.ProductInfo!=null&&data.ProductInfo.Count>0))
            {
                var id = _productOrder.Add(ProductOrder);
                if (id>0)
                {
                    decimal Amount = 0;
                    data.ProductInfo.ForEach(m => {
                        m.OrderId = id;
                        m.CreateTime = NowDate;
                        _orderDetails.AddNoReturn(m);
                        Amount = Amount + m.Amount;
                    });
                    Dictionary<string, object> updataky = new Dictionary<string, object>();
                    updataky.Add("Amount", Amount);
                    _productOrder.Update(updataky, id);
                    result.Message = "操作成功";
                    result.Success = true;
                    if (Shop == 1)
                    {
                        _user.DeleteShoppingCarts(data.ShopId);
                    }
                }
                return result;
            }
            return result;
        }

        /// <summary>
        /// 提交订单(购物车)(联系我们按钮)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("addOrders")]
        public ApiResult AddOrders([FromBody]List<ModW_ProductOrder> data)
        {
            var orderCode = $"Pro{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            var CreateTime= DateTime.Now;
            var result = new ApiResult() { Success = false, Message = "操作失败" };
            var IsAdd = true;
            data.ForEach(m=>
            {
                if (string.IsNullOrWhiteSpace(m.ClientName) || string.IsNullOrWhiteSpace(m.ContactDetails))
                {
                    IsAdd = false;
                    return;
                }
                m.OrderCode = orderCode;
                m.CreateTime = CreateTime;
                _productOrder.AddNoReturn(m);
            });
            if (IsAdd)
            {
                result.Message = "操作成功";
                result.Success = true;
                //提交并清空购物车
                _user.SubShoping();
                return result;
            }
            return result;
        }

        /// <summary>
        /// 删除购物车里的物品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete("deleteShop")]
        public ApiResult DeleteShop([FromBody]dynamic data)
        {
            string Guid = data.Guid;
            var result = new ApiResult() { Success = true, Message = "操作成功" };
            _user.DeleteShoppingCarts(Guid);
            return result;
        }

        /// <summary>
        /// 删除购物车里的物品（批量）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete("deleteShops")]
        public ApiResult DeleteShops([FromBody]List<dynamic> data)
        {
            var result = new ApiResult() { Success = true, Message = "操作成功" };
            List<string> Guids = new List<string>();
            data.ForEach(m =>
            {
                string Guid = m.Guid;
                Guids.Add(Guid);
            });
            _user.DeleteShoppingCarts(Guids);
            return result;
        }

        /// <summary>
        /// 提交客户意见
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("addIntention")]
        public ApiResult AddIntention([FromBody]ModW_Intention data)
        {
            var result = new ApiResult() { Success = true, Message = "操作成功" };
            data.CreateTime = DateTime.Now;
            _intention.AddNoReturn(data);
            return result;
        }


        /// <summary>
        /// 获取某个规格下的包装
        /// </summary>
        /// <returns></returns>
        [HttpGet("getProductPackageSpan")]
        public ApiResult<object> GetProductPackageSpan(int FormatId = 0)
        {
            var result = new ApiResult<object>() { Success = true, Message = "操作成功" };
            var FormatList = _productPackage.GetFormatPackageList(FormatId);
            result.Data = FormatList;
            return result;
        }

    }
}