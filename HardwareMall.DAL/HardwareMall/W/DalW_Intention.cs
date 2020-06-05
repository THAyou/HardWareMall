//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalW_Intention.cs
//-- 2020/5/8 16:32:13
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
    public class DalW_Intention:Dal.Base.HardwareMall.DalW_Intention
    {
	public DalW_Intention(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalW_Intention()
            : base()
        {

        }
         
    }
}
