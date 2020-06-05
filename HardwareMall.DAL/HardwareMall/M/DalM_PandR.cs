//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalM_PandR.cs
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
    public class DalM_PandR:Dal.Base.HardwareMall_Chinese.DalM_PandR
    {
	public DalM_PandR(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalM_PandR()
            : base()
        {

        }
         
    }
}
