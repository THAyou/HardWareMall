//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalM_OtherConfig.cs
//-- 2020/3/12 13:44:19
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
    public class DalM_OtherConfig:Dal.Base.HardwareMall.DalM_OtherConfig
    {
	public DalM_OtherConfig(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalM_OtherConfig()
            : base()
        {

        }
         
    }
}
