//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalW_ProductFormat.cs
//-- 2020/5/6 15:52:53
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
    public class DalW_ProductFormat:Dal.Base.HardwareMall.DalW_ProductFormat
    {
	public DalW_ProductFormat(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalW_ProductFormat()
            : base()
        {

        }
         
    }
}
