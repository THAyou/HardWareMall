//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllW_Intention.cs
//-- 2020/3/20 15:07:44
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using HardwareMall.Web.Model;

namespace Bll.HardwareMall
{
    public class BllW_Intention:Bll.Base.HardwareMall.BllW_Intention
    {
        /// <summary>
        /// 获取意见表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="status"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public PageDTModel GetIntentionList(int page, int limit,int ProcessStatus)
        {
            string where = "1=1";
            if (ProcessStatus != -1)
            {
                where += " and ProcessStatus=" + ProcessStatus;
            }
            int totalCount = 0;
            var PageList = dal.GetPageList2(@"W_Intention", "*", where, "order by CreateTime desc", limit, page, ref totalCount).Tables[0];
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
        /// 删除所有意见
        /// </summary>
        public void DelIntention()
        {
            string sql = "truncate table W_Intention";
            dal.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 删除意见
        /// </summary>
        public void DelIntentionByID(string Ids)
        {
            string sql = "delete from W_Intention where Id in (" + Ids + ")";
            dal.ExecuteNonQuery(sql);
        }
    }
}
