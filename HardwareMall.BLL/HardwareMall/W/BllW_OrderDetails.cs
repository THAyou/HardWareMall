//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllW_OrderDetails.cs
//-- 2020/5/7 13:59:41
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using Model.HardwareMall;
using System.Data.SqlClient;
using HardwareMall.Tool.DataTableHelp;

namespace Bll.HardwareMall
{
    public class BllW_OrderDetails:Bll.Base.HardwareMall.BllW_OrderDetails
    {
        public DataTable GetOrderDetails(int OrderId)
        {
            string sql = @"select t.Id,t1.ProductName,t2.FormatName,t3.Package,t.Quantity,t.Amount,t.AmountType from W_OrderDetails t
left join W_Product t1 on t.ProductId = t1.ID
left join W_ProductFormat t2 on t.FormatId = t2.Id
left join W_ProductPackage t3 on t.PackageId = t3.Id where t.OrderId=@OrderId";
            SqlParameter[] parameter = { new SqlParameter("@OrderId", OrderId) };
            return dal.ExecuteDataset(sql, parameter).Tables[0];
        }
    }
}
