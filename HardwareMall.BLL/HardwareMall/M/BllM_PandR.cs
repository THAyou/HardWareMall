//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllM_PandR.cs
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
    public class BllM_PandR:Bll.Base.HardwareMall_Chinese.BllM_PandR
    {
        /// <summary>
        /// 获取商品推荐关联产品
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public List<ModM_PandR> GetPandRListByProductId(int ProductId)
        {
            string sql = "select * from M_PandR where ProductId=" + ProductId;
            return dal.ExecuteDataset(sql).Tables[0].ToList<ModM_PandR>();
        }
    }
}
