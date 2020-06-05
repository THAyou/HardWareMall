using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll.HardwareMall;
using Bll.HardwareMall_Chinese;
using HardwareMall.Manage.User;
using HardwareMall.Model;
using HardwareMall.Web.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.HardwareMall;
using Model.HardwareMall_Chinese;

namespace HardwareMall.Manage.ApiControllers
{
    /// <summary>
    /// 产品管理Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BllW_Product _product = Bll.Base.HardwareMall.BllW_Product.Instance();
        private readonly BllW_ProductType _productType = Bll.Base.HardwareMall.BllW_ProductType.Instance();
        private readonly BllW_ProductImg _productImg = Bll.Base.HardwareMall.BllW_ProductImg.Instance();
        private readonly BllM_PriceType _priceType = Bll.Base.HardwareMall.BllM_PriceType.Instance();
        private readonly BllW_ProductPackage _productPackage = Bll.Base.HardwareMall.BllW_ProductPackage.Instance();
        private readonly BllW_ProductAndType _productAndType = Bll.Base.HardwareMall.BllW_ProductAndType.Instance();
        private readonly BllW_ProductOrder _productOrder = Bll.Base.HardwareMall.BllW_ProductOrder.Instance();
        private readonly BllW_Intention _intention = Bll.Base.HardwareMall.BllW_Intention.Instance();
        private readonly BllM_ProductRe _productRe = Bll.Base.HardwareMall_Chinese.BllM_ProductRe.Instance();
        private readonly BllM_PandR _pandR = Bll.Base.HardwareMall_Chinese.BllM_PandR.Instance();
        private readonly BllW_ProductFormat _productFormat = Bll.Base.HardwareMall.BllW_ProductFormat.Instance();
        private readonly BllW_OrderDetails _orderDetails = Bll.Base.HardwareMall.BllW_OrderDetails.Instance();
        private readonly IUser _user;

        public ProductController(IUser user)
        {
            _user = user;
        }

        /// <summary>
        /// 获取产品管理分页列表
        /// </summary>
        [HttpGet("getProductList")]
        public PageModel<ProductPageListDto> GetProductList(int page = 1, int limit = 10, string BillNo = "", string ProductName = "", int ProductType = 0)
        {
            var res = _product.GetProductList(page, limit, BillNo, ProductName, ProductType);
            return res;
        }

        /// <summary>
        /// 获取产品详情
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet("getProductModel")]
        public ApiResult<object> GetProductModel(int ProductId = 0)
        {
            var res = new ApiResult<object>() { Code = 0, Message = "操作失败", Success = false };
            var data = _product.GetModel(ProductId);
            if (data != null)
            {
                res.Data = data;
                res.Success = true;
                res.Code = 1;
                res.Message = "操作成功";
            }
            return res;
        }

        /// <summary>
        /// 获取产品类型下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet("getProductTypeSelectTree")]
        public ApiResult<object> GetProductTypeSelectTree()
        {
            var res = new ApiResult<object>() { Code = 0, Message = "操作失败", Success = false };
            var data = _productType.GetProductTypeList();
            if (data != null && data.Count > 0)
            {
                var treelist = data.Select(n => new { id = n.Id, name = n.TypeName, pId = n.ParentId.ToString(), open = true });
                res.Data = treelist;
                res.Success = true;
                res.Code = 1;
                res.Message = "操作成功";
            }
            return res;
        }

        /// <summary>
        /// 获取价格类型下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet("getPriceType")]
        public ApiResult<object> GetPriceType()
        {
            var res = new ApiResult<object>() { Code = 0, Message = "操作失败", Success = false };
            var data = _priceType.GetPriceTypeList();
            if (data != null && data.Count > 0)
            {
                res.Data = data;
                res.Success = true;
                res.Code = 1;
                res.Message = "操作成功";
            }
            return res;
        }

        /// <summary>
        /// 获取产品图片列表
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet("getProductImg")]
        public PageModel<ModW_ProductImg> GetProductImg(int page, int limit, int ProductId)
        {
            return _productImg.GetProductPageImg(page, limit, ProductId);
        }

        /// <summary>
        /// 保存产品
        /// </summary>
        /// <returns></returns>
        [HttpPut("saveProduct")]
        public ApiResult<int> SaveProduct([FromBody]ModW_Product data)
        {
            var res = new ApiResult<int>() { Code = 0, Message = "操作失败", Success = false };
            if (data != null)
            {
                var Success = false;
                if (data.ID != 0)
                {
                    data.UpdateUser = _user.UserId;
                    data.UpdateTime = DateTime.Now;
                    data.Description = data.Description;
                    Success = _product.UpdateProduct(data);
                }
                else
                {
                    data.CreateUser = _user.UserId;
                    data.CreateTime = DateTime.Now;
                    data.Description = data.Description;
                    res.Data = _product.Add(data);
                    Success = res.Data > 0;
                }
                if (Success)
                {
                    res.Code = 1;
                    res.Message = "保存成功";
                    res.Success = true;
                }
            }
            return res;
        }

        /// <summary>
        /// 将图片设置为列表展示
        /// </summary>
        /// <returns></returns>
        [HttpPost("setImgTitle")]
        public ApiResult SetImgTitle([FromBody] dynamic data)
        {
            string ProductId = data.ProductId;
            string ImgId = data.ImgId;
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            _productImg.SetImgTitle(int.Parse(ProductId), int.Parse(ImgId));
            return res;
        }

        /// <summary>
        /// 删除产品图片(标记删除)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("delProductImg")]
        public ApiResult DelProductImg([FromBody]dynamic data)
        {
            string ImgId = data.ImgId;
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            _productImg.DelProductImg(int.Parse(ImgId));
            return res;
        }

        /// <summary>
        /// 添加产品图片
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("addProductImg")]
        public ApiResult AddProductImg([FromBody]dynamic data)
        {
            string ProductId = data.ProductId;
            string Img = data.Img;
            if (_productImg.IsAddImg(int.Parse(ProductId)))
            {
                _productImg.Add(new ModW_ProductImg
                {
                    ProductId = int.Parse(ProductId),
                    Img = Img,
                    CreateTime = DateTime.Now,
                    CreateUser = 1,
                    Isdel = false,
                    IsTitleImg = 0
                });
            }
            else
            {
                return new ApiResult() { Code = 0, Message = "只能存在3个图片", Success = false };
            }

            return new ApiResult() { Code = 1, Message = "操作成功", Success = true };
        }

        /// <summary>
        /// 标记删除产品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete("delProduct")]
        public ApiResult DelProduct([FromBody]dynamic data)
        {
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            string ProductId = data.id;
            _product.DelProduct(ProductId);
            return res;
        }

        /// <summary>
        /// 产品发布操作
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("releaseProduct")]
        public ApiResult ReleaseProduct([FromQuery]int Type, [FromBody]List<dynamic> data)
        {
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            string ProductIds = string.Empty;
            data.ForEach(m =>
            {
                if (ProductIds != string.Empty)
                {
                    ProductIds += ",";
                }
                ProductIds += m.id;
            });
            _product.ReleaseProduct(Type, ProductIds);
            return res;
        }

        /// <summary>
        /// 获取包装信息
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet("getProductPackage")]
        public PageDTModel GetProductPackage(int page = 1, int limit = 10, int ProductId = 0, int FormatId = 0)
        {
            var res = _productPackage.GetPackagePage(page, limit, ProductId, FormatId);
            return res;
        }

        /// <summary>
        /// 获取产品规格信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet("GetProductFormat")]
        public PageDTModel GetProductFormat(int page = 1, int limit = 10, int ProductId = 0)
        {
            var res = _productFormat.GetProductFormat(page, limit, ProductId);
            return res;
        }

        /// <summary>
        /// 保存规格信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("saveProductFormat")]
        public ApiResult SaveProductFormat([FromBody]dynamic data, [FromQuery]int Type)
        {
            string Id = data.id;
            string productId = data.productId;
            string formatName = data.formatName;
            string sort = data.sort;
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            if (Type == 0)
            {
                Dictionary<string, object> updateData = new Dictionary<string, object>();
                updateData.Add("FormatName", formatName);
                updateData.Add("Sort", int.Parse(sort));
                _productFormat.Update(updateData, int.Parse(Id));//修改规格信息
            }
            else if (Type == 1)
            {
                if (_productFormat.IsAddFormat(int.Parse(productId)))
                {
                    _productFormat.AddNoReturn(new ModW_ProductFormat
                    {
                        FormatName = formatName,
                        ProductId = int.Parse(productId),
                        Sort = int.Parse(sort),
                    });
                }
                else
                {
                    res.Code = 0;
                    res.Message = "只能存在6个规格类信息";
                    res.Success = false;
                }
            }
            return res;
        }

        /// <summary>
        /// 保存包装信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("saveProductPackage")]
        public ApiResult SaveProductPackage([FromBody]dynamic data, [FromQuery]int Type)
        {
            string Id = data.id;
            string productId = data.productId;
            string package = data.package;
            string price = data.price;
            string priceType = data.priceType;
            string sort = data.sort;
            string PNum = data.pNum;
            string formatId = data.formatId;
            if (string.IsNullOrWhiteSpace(PNum))
            {
                PNum = "1";
            }
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            if (Type == 0)
            {
                _productPackage.SaveProdcutPagckage(new ModW_ProductPackage
                {
                    Id = int.Parse(Id),
                    ProductId = int.Parse(productId),
                    Package = package,
                    Price = decimal.Parse(price),
                    PriceType = priceType,
                    PNum = int.Parse(PNum),
                    Sort = int.Parse(sort),
                    FormatId = int.Parse(formatId)
                });
            }
            else if (Type == 1)
            {
                if (_productPackage.IsAddPagckage(int.Parse(formatId)))
                {
                    _productPackage.AddNoReturn(new ModW_ProductPackage
                    {
                        ProductId = int.Parse(productId),
                        Package = package,
                        Price = decimal.Parse(price),
                        PriceType = priceType,
                        Sort = int.Parse(sort),
                        Isdel = false,
                        PNum = int.Parse(PNum),
                        CreateTime = DateTime.Now,
                        CreateUser = _user.UserId,
                        FormatId = int.Parse(formatId)
                    });
                }
                else
                {
                    res.Code = 0;
                    res.Message = "只能存在3个包装类信息";
                    res.Success = false;
                }
            }
            return res;
        }

        /// <summary>
        /// 删除包装信息(标记删除)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete("delProductPackage")]
        public ApiResult DelProductPackage([FromBody]dynamic data)
        {
            string Id = data.id;
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            _productPackage.DelProdcutPagckage(int.Parse(Id));
            return res;
        }

        /// <summary>
        /// 删除规格信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete("delProductFormat")]
        public ApiResult DelProductFormat([FromBody]dynamic data)
        {
            string Id = data.id;
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            //删除这个规格的所有包装
            var FormatPage = _productPackage.GetFormatPackageList(int.Parse(Id));
            FormatPage.ForEach(m =>
            {
                _productPackage.Delete(m.Id);
            });
            _productFormat.Delete(int.Parse(Id));//删除此规格
            return res;
        }

        /// <summary>
        /// 获取产品参数信息
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet("getProductParameter")]
        public ApiResult<object> GetProductParameter(int ProductId = 0)
        {
            var res = new ApiResult<object>() { Code = 0, Message = "操作成功", Success = true };
            var Parameter = _product.GetProductParameter(ProductId);
            if (Parameter != null)
            {
                res.Data = Parameter.Select(m => new { id = m.Id, key = m.Key, value = m.Value, skillproductId = ProductId }).ToList();
            }
            return res;
        }

        /// <summary>
        /// 删除产品技术参数
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete("delParameter")]
        public ApiResult DelParameter([FromBody]dynamic data)
        {
            string Id = data.id;
            string ProductId = data.ProductId;
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            _product.DelProductParameter(Id, int.Parse(ProductId));
            return res;
        }

        /// <summary>
        /// 保存产品技术参数
        /// </summary>
        [HttpPost("saveParameter")]
        public ApiResult SaveParameter([FromBody] dynamic data, [FromQuery]int Type)
        {
            string Id = data.id;
            string ProductId = data.skillproductId;
            string Key = data.key;
            string Value = data.value;
            var res = new ApiResult() { Code = 1, Message = "操作成功", Success = true };
            var Parameter = _product.GetProductParameter(int.Parse(ProductId));
            if (Type == 0)
            {
                Parameter.ForEach(m =>
                {
                    if (m.Id == Id)
                    {
                        m.Key = Key;
                        m.Value = Value;
                    }
                });
                _product.SaveProductParameter(Parameter, int.Parse(ProductId));
            }
            else if (Type == 1)
            {
                if (Parameter == null)
                {
                    Parameter = new List<JsonDto>();
                }
                Parameter.Add(new JsonDto { Id = Guid.NewGuid().ToString(), Key = Key, Value = Value });
                _product.SaveProductParameter(Parameter, int.Parse(ProductId));
            }
            return res;
        }

        /// <summary>
        /// 获取产品所属分类
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet("getProType")]
        public ApiResult<object> GetProType(int ProductId = 0)
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            var ProTypeList = _productType.GetProductTypeList();
            var ProductAndType = _productAndType.GetProductAndType(ProductId);
            var result = new List<object>();
            ProTypeList.ForEach(m =>
            {
                result.Add(new
                {
                    Id = m.Id,
                    name = m.TypeName,
                    pId = m.ParentId,
                    open = true,
                    Checked = ProductAndType.Exists(s => s.ProTypeID.Equals(m.Id))
                });
            });
            res.Data = result;
            return res;
        }

        /// <summary>
        /// 保存产品所属类型
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpPost("setProType")]
        public ApiResult SetProType([FromBody]List<dynamic> data, [FromQuery]int ProductId)
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            _productAndType.DelProductAndType(ProductId);
            data.ForEach(m =>
            {
                long TypeId = m;
                _productAndType.AddNoReturn(new ModW_ProductAndType
                {
                    ProID = ProductId,
                    ProTypeID = Convert.ToInt32(TypeId),
                    Isdel = false
                });
            });
            return res;
        }

        /// <summary>
        /// 获取客户联系列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("getProductOrder")]
        public PageDTModel GetProductOrder(int page, int limit, string status = "")
        {
            return _productOrder.GetProductOrderList(page, limit, status);
        }

        /// <summary>
        /// 获取订单商品
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [HttpGet("GetOrderDetails")]
        public ApiResult<object> GetOrderDetails(int OrderId = 0)
        {
            var res = new ApiResult<object>() { Code = 0, Message = "操作成功", Success = true };
            res.Data = _orderDetails.GetOrderDetails(OrderId);
            return res;
        }

        /// <summary>
        /// 获取客户联系详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("getOrderInfo")]
        public ApiResult<object> GetOrderInfo(int Id)
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            res.Data = _productOrder.GetOrderInfo(Id);
            return res;
        }

        /// <summary>
        /// 处理客户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("setOrder")]
        public ApiResult SetOrder([FromBody]dynamic data)
        {
            string Id = data.Id;
            string ProcessRemark = data.ProcessRemark;
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            _productOrder.SetOrder(Id, ProcessRemark);
            return res;
        }

        /// <summary>
        /// 获取意见表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet("getintention")]
        public PageDTModel Getintention(int page = 1, int limit = 10,int ProcessStatus=-1)
        {
            return _intention.GetIntentionList(page, limit, ProcessStatus);
        }

        /// <summary>
        /// 获取产品推荐
        /// </summary>
        /// <returns></returns>
        [HttpGet("getProductRetree")]
        public ApiResult<object> GetProductRetree(int ProductId)
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            var Relist = _productRe.GetProductReList();
            var PandR = _pandR.GetPandRListByProductId(ProductId);
            var result = new List<object>();
            Relist.ForEach(m =>
            {
                var check = PandR.Exists(s => s.ReId.Equals(m.Id));
                result.Add(new
                {
                    Id = m.Id,
                    name = m.Name,
                    pId = 0,
                    open = true,
                    Checked = check
                });
            });
            res.Data = result;
            return res;
        }

        /// <summary>
        /// 添加商品推荐和产品关联
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpPost("setProductRe")]
        public ApiResult SetProductRe([FromBody]List<dynamic> data, [FromQuery]int ProductId)
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            _pandR.Delete(ProductId);
            data.ForEach(m =>
            {
                long Id = m;
                _pandR.AddNoReturn(new ModM_PandR
                {
                    ProductId = ProductId,
                    ReId = Convert.ToInt32(Id)
                });
            });
            return res;
        }

        /// <summary>
        /// 删除所有意见
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delIntention")]
        public ApiResult DelIntention()
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            _intention.DelIntention();
            return res;
        }

        /// <summary>
        /// 删除所有意见
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delIntentionById")]
        public ApiResult DelIntentionById([FromBody]List<string> Ids)
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            _intention.DelIntentionByID(string.Join(',', Ids.ToArray()));
            return res;
        }

        /// <summary>
        /// 删除所有意见
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delOrder")]
        public ApiResult DelOrder()
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            _productOrder.DelOrder();
            return res;
        }

        /// <summary>
        /// 删除所有意见
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delOrderById")]
        public ApiResult DelOrderById([FromBody]List<string> Ids)
        {
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            _productOrder.DelOrderByID(string.Join(',', Ids.ToArray()));
            return res;
        }
        
        /// <summary>
        /// 处理意见
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("processIntention")]
        public ApiResult ProcessIntention([FromBody]dynamic data)
        {
            string Id = data.id;
            string remark = data.processRemark;
            var res = new ApiResult<object>() { Code = 1, Message = "操作成功", Success = true };
            Dictionary<string, object> Updata = new Dictionary<string, object>();
            Updata.Add("ProcessStatus", 1);
            Updata.Add("ProcessRemark", remark);
            Updata.Add("ProcessTime", DateTime.Now);
            _intention.Update(Updata, int.Parse(Id));
            return res;
        }
    }
}