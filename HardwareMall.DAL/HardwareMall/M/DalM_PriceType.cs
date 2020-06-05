//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalM_PriceType.cs
//-- 2020/3/16 14:29:53
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
    public class DalM_PriceType:Dal.Base.HardwareMall.DalM_PriceType
    {
	public DalM_PriceType(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalM_PriceType()
            : base()
        {

        }
         
    }
}
