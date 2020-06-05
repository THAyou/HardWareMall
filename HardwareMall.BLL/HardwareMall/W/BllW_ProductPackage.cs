//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllW_ProductPackage.cs
//-- 2020/3/9 14:05:43
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using Model.HardwareMall;
using System.Data.SqlClient;
using HardwareMall.Tool.DataTableHelp;
using HardwareMall.Web.Model;
using System.Linq;

namespace Bll.HardwareMall
{
    public class BllW_ProductPackage:Bll.Base.HardwareMall.BllW_ProductPackage
    {

        private readonly BllW_ProductFormat _productFormat = Bll.Base.HardwareMall.BllW_ProductFormat.Instance();

        /// <summary>
        /// 获取产品的所有包装信息
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public List<ModW_ProductPackage> GetProductPackageList(int ProductId)
        {
            string sql1 = "select top 1 * from W_ProductPackage where ProductId=@ProductId order by Price desc";
            string sql2 = "select top 1 * from W_ProductPackage where ProductId=@ProductId order by Price asc";
            SqlParameter[] parameters = { new SqlParameter("@ProductId", ProductId) };
            var PackageInfoMax = dal.ExecuteDataset(sql1, parameters).Tables[0].ToList<ModW_ProductPackage>().FirstOrDefault();
            var PackageInfoMin = dal.ExecuteDataset(sql2, parameters).Tables[0].ToList<ModW_ProductPackage>().FirstOrDefault();
            List<ModW_ProductPackage> result = new List<ModW_ProductPackage>();
            if (PackageInfoMin != null)
            {
                result.Add(PackageInfoMin);
            }
            if (PackageInfoMax != null)
            {
                result.Add(PackageInfoMax);
            }
            return result;
        }

        /// <summary>
        /// 获取规格的所有包装信息
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public List<ModW_ProductPackage> GetFormatPackageList(int FormatId)
        {
            string sql = "select * from W_ProductPackage where FormatId=@FormatId order by Sort";
            SqlParameter[] parameters = { new SqlParameter("@FormatId", FormatId) };
            var DataTable = dal.ExecuteDataset(sql, parameters).Tables[0];
            return DataTable.ToList<ModW_ProductPackage>();
        }

        /// <summary>
        /// 获取包装信息列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public PageDTModel GetPackagePage(int page,int limit,int ProductId,int FormatId)
        {
            string where = "ProductId=" + ProductId + " and Isdel=0 and FormatId=" + FormatId;
            int totalCount = 0;
            var PageList = dal.GetPageList2("W_ProductPackage", "*", where, "order by Sort asc", limit, page, ref totalCount).Tables[0];
            var PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalCount) / Convert.ToDecimal(limit)));
            return new PageDTModel()
            {
                PageIndex = page,
                PageCount = PageCount,
                PageSize = limit,
                data = PageList,
                code = 0,
                msg = "获取成功",
                count = totalCount
            };
        }

        /// <summary>
        /// 保存包装信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Type"></param>
        public void SaveProdcutPagckage(ModW_ProductPackage data)
        {
            string sql = "update W_ProductPackage set PriceType=@PriceType,Price=@Price,Package=@Package,Sort=@Sort,PNum=@PNum,ProductId=@ProductId,FormatId=@FormatId where Id=@Id";
            SqlParameter[] parameters = {
                new SqlParameter("@PriceType",data.PriceType),
                new SqlParameter("@Price",data.Price),
                new SqlParameter("@Package",data.Package),
                new SqlParameter("@Sort",data.Sort),
                new SqlParameter("@PNum",data.PNum),
                new SqlParameter("@ProductId",data.ProductId),
                new SqlParameter("@FormatId",data.FormatId),
                new SqlParameter("@Id",data.Id),
                };
            dal.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 删除产品包装信息(标记删除)
        /// </summary>
        /// <param name="Id"></param>
        public void DelProdcutPagckage(int Id)
        {
            string sql = "update W_ProductPackage set Isdel=1 where Id=" + Id;
            dal.ExecuteNonQuery(sql);
        }
        
        /// <summary>
        /// 验证是否能够添加包装信息
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public bool IsAddPagckage(int FormatId)
        {
            string sql = "select * from W_ProductPackage where Isdel=0 and FormatId=" + FormatId;
            var data = dal.ExecuteDataset(sql).Tables[0].ToList<ModW_ProductPackage>();
            if (data != null)
            {
                if (data.Count >= 3)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

    }
}
