//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalW_ProductOrder.cs
//-- 2020/3/9 17:08:21
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
    public class DalW_ProductOrder:Dal.Base.HardwareMall.DalW_ProductOrder
    {
	public DalW_ProductOrder(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalW_ProductOrder()
            : base()
        {

        }
         
    }
}
