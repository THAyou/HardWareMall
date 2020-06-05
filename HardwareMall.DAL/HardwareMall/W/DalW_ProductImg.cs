//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalW_ProductImg.cs
//-- 2020/3/9 14:05:43
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
    public class DalW_ProductImg:Dal.Base.HardwareMall.DalW_ProductImg
    {
	public DalW_ProductImg(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalW_ProductImg()
            : base()
        {

        }
         
    }
}
