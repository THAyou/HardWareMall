//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalW_ProductType.cs
//-- 2020/3/6 14:31:08
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
    public class DalW_ProductType:Dal.Base.HardwareMall.DalW_ProductType
    {
	public DalW_ProductType(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalW_ProductType()
            : base()
        {

        }
         
    }
}
