using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using HardwareMall.Web.Model;
using Model.HardwareMall;
using HardwareMall.Tool.DataTableHelp;
using HardwareMall.Model;
using System.Data.SqlClient;
using Dal.Base;
using HardwareMall.Tool;
using System.Linq;

namespace Bll.HardwareMall
{
    public class BllW_Product:Bll.Base.HardwareMall.BllW_Product
    {
        private readonly BllW_ProductPackage _productPackage = Bll.Base.HardwareMall.BllW_ProductPackage.Instance();
        private readonly BllW_ProductFormat _productFormat = Bll.Base.HardwareMall.BllW_ProductFormat.Instance();
        private readonly BllW_ProductImg _productImg = Bll.Base.HardwareMall.BllW_ProductImg.Instance();

        /// <summary>
        /// 获取产品列表(后台)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public PageModel<ProductPageListDto> GetProductList(int page, int limit,string BillNo, string ProductName,int ProductType)
        {
            string where = "Isdel=0";
            if (!string.IsNullOrWhiteSpace(BillNo))
            {
                where += " and BillNo='" + BillNo + "'";
            }
            if (!string.IsNullOrWhiteSpace(ProductName))
            {
                where += " and ProductName like '%" + ProductName + "%'";
            }
            if (ProductType != 0)
            {
                var TypeStr = GetChilType(ProductType);
                if (TypeStr != string.Empty)
                {
                    TypeStr += ",";
                }
                TypeStr += ProductType.ToString();
                where += " and Id in (select ProID as Id from W_ProductAndType where ProTypeID in (" + TypeStr + ") GROUP BY ProID)";
            }
            int totalCount = 0;
            var PageList = dal.GetPageList2("W_Product t", "*", where, "order by CreateTime desc", limit, page, ref totalCount).Tables[0];
            var PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalCount) / Convert.ToDecimal(limit)));
            var data = PageList.ToList<ProductPageListDto>();
            return new PageModel<ProductPageListDto>()
            {
                PageIndex = page,
                PageCount = PageCount,
                PageSize = limit,
                data = data,
                code = 0,
                msg = "获取成功",
                count = totalCount
            };
        }
        /// <summary>
        /// 获取产品分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="Limit"></param>
        /// <returns></returns>
        public PageDTModel GetProductPageList(int page,int Limit,int TypeID,List<string> TypeIds,string ProductName,int BigTypeId,string ReId)
        {
            string where = "t.Isdel=0 and t.Release=1";
            if (TypeIds != null && TypeIds.Count > 0)
            {
                var TypeIDstr = string.Join(",", TypeIds);
                where += " and t.Id in (select ProID as Id from W_ProductAndType where ProTypeID in (" + TypeIDstr + ") GROUP BY ProID)";
            }
            else
            {
                if (TypeID != 0 || BigTypeId != 0)
                {
                    var DataTypeId = 0;
                    if (TypeID != 0)
                    {
                        DataTypeId = TypeID;
                    }
                    else
                    {
                        DataTypeId = BigTypeId; 
                    }
                    var TypeIDStr = GetChilType(DataTypeId);
                    if (!string.IsNullOrWhiteSpace(TypeIDStr))
                    {
                        TypeIDStr += ",";
                    }
                    TypeIDStr += TypeID;
                    where += " and t.Id in (select ProID as Id from W_ProductAndType where ProTypeID in (" + TypeIDStr + ") GROUP BY ProID)";
                }
            }
            if (ProductName != "")
            {
                where += " and ProductName like '%" + ProductName + "%'";
            }
            if (ReId != "0")
            {
                where += " and t.Id in (select ProductId from M_PandR where ReId=" + ReId + ")";
            }
            
            int totalCount = 0;
            var PageList = dal.GetPageList2("W_Product t left join (select * from W_ProductImg where Isdel=0) t1 on t.ImgId=t1.Id", " t.*,t1.Img ", where, "order by t.CreateTime desc", Limit, page, ref totalCount).Tables[0];
            var PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalCount) / Convert.ToDecimal(Limit)));
            return new PageDTModel()
            {
                PageIndex = page,
                PageCount = PageCount,
                PageSize = Limit,
                data = PageList,
                code = 1,
                msg = "获取成功",
                count = PageList.Rows.Count
            };
        }



        /// <summary>
        /// 获取购物车详情
        /// </summary>
        /// <param name="ShopCart"></param>
        /// <returns></returns>
        public List<ShopCartProDto> GetShopCartProList(List<ShoppingCartDto> ShopCart)
        {
            var result = new List<ShopCartProDto>();
            //从购物车里获取信息，并查询详情
            ShopCart.ForEach(m => 
            {
                var ProInfo = dal.GetModel(m.ProductId != null ? m.ProductId.Value : 0);
                var PackageInfo = _productPackage.GetModel(m.PackageId != null ? m.PackageId.Value : 0);
                if (PackageInfo == null)
                {
                    PackageInfo = new ModW_ProductPackage();
                }
                var ProductImgInfo = _productImg.GetModel(ProInfo.ImgId != null ? ProInfo.ImgId.Value : 0);
                var FormatInfo = _productFormat.GetModel(m.FormatId != null ? m.FormatId.Value : 0);
                result.Add(new ShopCartProDto
                {
                    GUID = m.GUID,
                    ProductId = ProInfo.ID,
                    ProductName = ProInfo.ProductName,
                    ProductModel = ProInfo.ModelNo,
                    ProductBill = ProInfo.BillNo,
                    Quantity = m.Quantity,
                    PackageId = PackageInfo.Id,
                    Price = PackageInfo.Price,
                    PriceType = PackageInfo.PriceType,
                    PackgeName = PackageInfo.Package,
                    Amount = m.Amount,
                    ProductImg = ProductImgInfo != null ? ProductImgInfo.Img : "",
                    PNum = PackageInfo.PNum,
                    FormatId = m.FormatId,
                    FormatName = FormatInfo != null ? FormatInfo.FormatName : ""
                }) ;
            });
            return result;
        }

        /// <summary>
        /// 获取产品类型所有的子类型（递归）
        /// </summary>
        /// <param name="PTypeId"></param>
        /// <returns></returns>
        public string GetChilType(int PTypeId)
        {
            string res = string.Empty;
            string sql = @"select * from W_ProductType where ParentId =@PTypeId	";
            SqlParameter[] parameters = { new SqlParameter("@PTypeId", PTypeId) };
            var list = dal.ExecuteDataset(sql, parameters).Tables[0].ToList<ModW_ProductType>();
            list.ForEach(m => 
            {
                if (res != string.Empty)
                {
                    res += ",";
                }
                res += m.Id;
                var ChilIdStr = GetChilType(m.Id);
                if (ChilIdStr != string.Empty)
                {
                    res += "," + ChilIdStr;
                }
            });
            return res;
        }

        /// <summary>
        /// 获取产品类型描述
        /// </summary>
        /// <returns></returns>
        public string GetProductTypeStr(int ProductId)
        {
            string sql = @"select t1.TypeName from W_ProductAndType t
left join W_ProductType t1 on t.ProTypeID = t1.Id where t.ProId=" + ProductId;
            var Table = dal.ExecuteDataset(sql).Tables[0];
            string result = string.Empty;
            foreach (DataRow r in Table.Rows)
            {
                if (result != string.Empty)
                {
                    result += ",";
                }
                result += r["TypeName"].ToString();
            }
            return result;
        }

        /// <summary>
        /// 标记删除产品
        /// </summary>
        /// <param name="ProductId"></param>
        public void DelProduct(string ProductId)
        {
            string sql = "update W_Product set Isdel=1 where Id=" + ProductId;
            dal.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 产品发布操作
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="ProductIds"></param>
        public void ReleaseProduct(int Type, string ProductIds)
        {
            if (ProductIds == "0")
            {
                string sql1 = "update W_Product set Release=" + Type+" where Isdel=0";
                dal.ExecuteNonQuery(sql1);
                return;
            }
            string sql = "update W_Product set Release=" + Type + " where Isdel=0 and Id in (" + ProductIds + ")";
            dal.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="w_Product">Model.HardwareMall.ModW_Product</param>
        /// <returns>成功True ,失败False</returns>
        public bool UpdateProduct(ModW_Product model)
        {

            string sql = @"update dbo.W_Product set [BillNo] = @BillNo  ,[ProductName] = @ProductName ,[Description] = @Description ,[ModelNo] = @ModelNo ,[Ship] = @Ship ,[UpdateUser] = @UpdateUser ,[UpdateTime] = @UpdateTime ,[Remark] = @Remark ,[TitlePrice] = @TitlePrice ,[PriceType] = @PriceType,[Reserve]=@Reserve ,[Release] = @Release,[EATime]=@EATime  where [Id]=@Id";
            SqlParameter[] parameters = {

                new SqlParameter("@ID",model.ID),
                new SqlParameter("@BillNo",model.BillNo),
                new SqlParameter("@ProductName",model.ProductName),
                new SqlParameter("@Description",model.Description),
                new SqlParameter("@ModelNo",model.ModelNo),
                new SqlParameter("@Ship",model.Ship),
                new SqlParameter("@UpdateUser",model.UpdateUser),
                new SqlParameter("@UpdateTime",model.UpdateTime),
                new SqlParameter("@Remark",model.Remark),
                new SqlParameter("@TitlePrice",model.TitlePrice),
                new SqlParameter("@PriceType",model.PriceType),
                new SqlParameter("@Reserve",model.Reserve),
                new SqlParameter("@Release",model.Release),
                new SqlParameter("@EATime",model.EATime)


            };
            dal.ExecuteNonQuery(sql, parameters);
            return true;
        }

        /// <summary>
        /// 获取产品参数信息
        /// </summary>
        public List<JsonDto> GetProductParameter(int ProductId)
        {
            if (ProductId == 0)
            {
                return new List<JsonDto>();
            }
            string sql = "select * from W_Product where Id=" + ProductId;
            var Data = dal.ExecuteDataset(sql).Tables[0];
            var ParameterJson = Data.Rows[0]["SkillParameter"].ToString();
            return ParameterJson.ToObject<List<JsonDto>>();
        }

        /// <summary>
        /// 删除技术参数
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ProductId"></param>
        public void DelProductParameter(string Id, int ProductId)
        {
            string sql1 = "select * from W_Product where Id=" + ProductId;
            var Data = dal.ExecuteDataset(sql1).Tables[0];
            var ParameterJson = Data.Rows[0]["SkillParameter"].ToString();
            var Parameter=ParameterJson.ToObject<List<JsonDto>>();
            Parameter.Remove(Parameter.Where(m => m.Id == Id).FirstOrDefault());
            string sql2 = "update W_Product set SkillParameter='" + Parameter.ToJson() + "' where Id=" + ProductId;
            dal.ExecuteNonQuery(sql2);
        }

        /// <summary>
        /// 保存产品技术参数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ProductId"></param>
        public void SaveProductParameter(List<JsonDto> data, int ProductId)
        {
            string sql1 = "update W_Product set SkillParameter='" + data.ToJson() + "' where Id=" + ProductId;
            dal.ExecuteNonQuery(sql1);
        }
    }
}
