//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalM_ProductRe.cs
//-- 2020/3/23 18:08:50
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using DBUtility;
using Dal.Base;

namespace Dal.HardwareMall_Chinese
{
    public class DalM_ProductRe:Dal.Base.HardwareMall_Chinese.DalM_ProductRe
    {
	public DalM_ProductRe(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalM_ProductRe()
            : base()
        {

        }
         
    }
}
