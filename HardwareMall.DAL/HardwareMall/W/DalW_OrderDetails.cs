//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalW_OrderDetails.cs
//-- 2020/5/7 13:59:41
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using DBUtility;
using Dal.Base;

namespace Dal.HardwareMall
{
    public class DalW_OrderDetails:Dal.Base.HardwareMall.DalW_OrderDetails
    {
	public DalW_OrderDetails(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalW_OrderDetails()
            : base()
        {

        }
         
    }
}
