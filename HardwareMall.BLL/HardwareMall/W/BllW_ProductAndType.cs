//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllW_ProductAndType.cs
//-- 2020/3/10 15:12:59
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using Model.HardwareMall;
using HardwareMall.Tool.DataTableHelp;

namespace Bll.HardwareMall
{
    public class BllW_ProductAndType:Bll.Base.HardwareMall.BllW_ProductAndType
    {
        /// <summary>
        /// 获取产品所属分类
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public List<ModW_ProductAndType> GetProductAndType(int ProductId = 0)
        {
            string sql = "select * from W_ProductAndType";
            string where = " where 1=1";
            if (ProductId != 0)
            {
                where += " and ProID=" + ProductId;
            }
            return dal.ExecuteDataset(sql+where).Tables[0].ToList<ModW_ProductAndType>();
        }

        /// <summary>
        /// 删除某产品的所有分类
        /// </summary>
        /// <param name="ProductId"></param>
        public void DelProductAndType(int ProductId)
        {
            string sql = "delete from W_ProductAndType where ProID=" + ProductId;
            dal.ExecuteNonQuery(sql);
        }
    } 
}
