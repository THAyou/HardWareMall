//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllM_ProductRe.cs
//-- 2020/3/23 18:08:50
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using Model.HardwareMall_Chinese;
using HardwareMall.Tool.DataTableHelp;

namespace Bll.HardwareMall_Chinese
{
    public class BllM_ProductRe:Bll.Base.HardwareMall_Chinese.BllM_ProductRe
    {
        /// <summary>
        /// 获取产品推荐列表
        /// </summary>
        /// <returns></returns>
        public List<ModM_ProductRe> GetProductReList()
        {
            string sql = "select * from M_ProductRe";
            var data = dal.ExecuteDataset(sql).Tables[0];
            var result = new List<ModM_ProductRe>();
            if (data != null && data.Rows.Count > 0)
            {
                result = data.ToList<ModM_ProductRe>();
            }
            return result;
        }
    }
}
