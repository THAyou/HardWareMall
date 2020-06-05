//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllW_ProductFormat.cs
//-- 2020/5/6 15:52:53
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using HardwareMall.Web.Model;
using Model.HardwareMall;
using HardwareMall.Tool.DataTableHelp;
using System.Data.SqlClient;

namespace Bll.HardwareMall
{
    public class BllW_ProductFormat:Bll.Base.HardwareMall.BllW_ProductFormat
    {
        /// <summary>
        /// 获取规格信息列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public PageDTModel GetProductFormat(int page, int limit, int ProductId)
        {
            string where = "ProductId=" + ProductId;
            int totalCount = 0;
            var PageList = dal.GetPageList2("W_ProductFormat", "*", where, "order by Sort asc", limit, page, ref totalCount).Tables[0];
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
        /// 获取产品规格
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public List<ModW_ProductFormat> GetProductFormatList(int ProductId)
        {
            string sql = "select * from W_ProductFormat where ProductId=@ProductId";
            SqlParameter[] parameter = { new SqlParameter("@ProductId", ProductId) };
            return dal.ExecuteDataset(sql, parameter).Tables[0].ToList<ModW_ProductFormat>();
        }


        /// <summary>
        /// 验证是否能够添加规格信息
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public bool IsAddFormat(int ProductId)
        {
            string sql = "select * from W_ProductFormat where ProductId=" + ProductId;
            var data = dal.ExecuteDataset(sql).Tables[0].ToList<ModW_ProductFormat>();
            if (data != null)
            {
                if (data.Count >= 6)
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
