//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalW_ProductAndType.cs
//-- 2020/3/10 15:12:59
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
    public class DalW_ProductAndType:Dal.Base.HardwareMall.DalW_ProductAndType
    {
	public DalW_ProductAndType(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalW_ProductAndType()
            : base()
        {

        }
         
    }
}
