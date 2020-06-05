using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bll.HardwareMall;
using HardwareMall.Manage.User;
using HardwareMall.Web.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.HardwareMall;

namespace HardwareMall.Manage.ApiControllers
{
    /// <summary>
    /// 产品分类管理Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly BllW_Product _product = Bll.Base.HardwareMall.BllW_Product.Instance();
        private readonly BllW_ProductType _productType = Bll.Base.HardwareMall.BllW_ProductType.Instance();
        private readonly IUser _user;

        public ProductTypeController(IUser user)
        {
            _user = user;
        }

        /// <summary>
        /// 获取产品分类管理列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("getProductTypeList")]
        public ApiResult<object> GetProductTypeList()
        {
            var res = new ApiResult<object>() { Code = 0, Message = "操作成功", Success = true };
            var list = _productType.GetProductTypeList();
            res.Data = list;
            return res;
        }

        /// <summary>
        /// 获取产品分类管理列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("getProductTypeListedit")]
        public ApiResult<object> GetProductTypeListedit(int Id=0)
        {
            var res = new ApiResult<object>() { Code = 0, Message = "操作成功", Success = true };
            var list = _productType.GetProductTypeList2(Id);
            var data = list.Select(s => new { id = s.Id, name = s.TypeName, pId = s.ParentId, open = s.ParentId > 0 });
            data=data.Prepend(new { id = 0, name = "默认", pId = 0, open = true });
            res.Data = data;
            return res;
        }

        /// <summary>
        /// 设置节点
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        [HttpPost("setProductType")]
        public ApiResult SetProductType([FromBody]dynamic data, [FromQuery]int Type)
        {
            string Id = data.id;
            string TypeName = data.typeName;
            string parentId = data.parentId;
            string Img = data.img;
            string Sort = data.sort;
            var res = new ApiResult { Code = 1, Message = "操作成功", Success = true };
            if (Type == 1)
            {
                _productType.AddNoReturn(new ModW_ProductType
                {
                    ParentId = int.Parse(parentId),
                    TypeName = TypeName,
                    CreateBy = _user.UserId,
                    CreateTime = DateTime.Now,
                    Img = Img.Replace('\\', '/'),
                    Sort = string.IsNullOrWhiteSpace(Sort) ? 0 : int.Parse(Sort),
                    IsDel = false
                }) ;
            }
            else if (Type == 0)
            {
                _productType.UpdateProductType(new ModW_ProductType 
                {
                    Id=int.Parse(Id),
                    ParentId = int.Parse(parentId),
                    TypeName = TypeName,
                    UpdateBy = _user.UserId,
                    UpdateTime = DateTime.Now,
                    Img = Img.Replace('\\', '/'),
                    Sort = string.IsNullOrWhiteSpace(Sort) ? 0 : int.Parse(Sort)
                });
            }
            return res;
        }

        /// <summary>
        /// 标记删除产品分类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete("delProductType")]
        public ApiResult DelProductType([FromBody]dynamic data)
        {
            string Id = data.Id;
            var res = new ApiResult { Code = 1, Message = "操作成功", Success = true };
            _productType.DelProductType(Id);
            return res;
        }
    }
}