//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllW_ProductOrder.cs
//-- 2020/3/9 17:08:21
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using HardwareMall.Web.Model;
using HardwareMall.Model;
using HardwareMall.Tool.DataTableHelp;

namespace Bll.HardwareMall
{
    public class BllW_ProductOrder:Bll.Base.HardwareMall.BllW_ProductOrder
    {
        /// <summary>
        /// 获取联系客户列表(后台)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public PageDTModel GetProductOrderList(int page, int limit,string status)
        {
            string where = "1=1";
            if (!string.IsNullOrWhiteSpace(status))
            {
                where += " and t.Status=" + status;
            }
            int totalCount = 0;
            var PageList = dal.GetPageList2(@"W_ProductOrder", "*", where, "order by CreateTime desc", limit, page, ref totalCount).Tables[0];
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
        /// 获取联系详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public object GetOrderInfo(int Id)
        {
            string sql = @"select 
                                t.Id,
                                t.OrderCode,
                                t.Amount,
                                case when t.Status=0 then '未处理' else '已处理' end as processstatus,
                                t.ProcessTime,
                                t.ContactDetails,
                                t.Email,
                                t.Remark,
                                t.ProcessRemark,
                                t.CreateTime
                                from W_ProductOrder t where t.Id=" + Id;
            return dal.ExecuteDataset(sql).Tables[0].Rows[0].RowToObj<OrderDto>() ;
        }

        /// <summary>
        /// 处理客户联系
        /// </summary>
        /// <param name="Id"></param>
        public void SetOrder(string Id,string ProcessRemark)
        {
            string sql = "update W_ProductOrder set Status=1,ProcessTime=getdate(),ProcessRemark='" + ProcessRemark + "' where Id=" + Id;
            dal.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 删除所有订单
        /// </summary>
        public void DelOrder()
        {
            string sql = "truncate table W_ProductOrder";
            string sql1 = "truncate table W_OrderDetails";
            dal.ExecuteNonQuery(sql);
            dal.ExecuteNonQuery(sql1);
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        public void DelOrderByID(string Ids)
        {
            string sql = "delete from W_ProductOrder where Id in (" + Ids + ")";
            string sql1 = "delete from W_OrderDetails where OrderId in (" + Ids + ")";
            dal.ExecuteNonQuery(sql);
            dal.ExecuteNonQuery(sql1);
        }
    }
}
