//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalW_ProductPackage.cs
//-- 2020/3/9 15:16:05
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
    public class DalW_ProductPackage:Dal.Base.HardwareMall.DalW_ProductPackage
    {
	public DalW_ProductPackage(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalW_ProductPackage()
            : base()
        {

        }
         
    }
}
