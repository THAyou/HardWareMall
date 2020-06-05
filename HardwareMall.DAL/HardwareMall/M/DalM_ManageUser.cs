//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalM_ManageUser.cs
//-- 2020/3/12 18:55:34
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
    public class DalM_ManageUser:Dal.Base.HardwareMall.DalM_ManageUser
    {
	public DalM_ManageUser(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalM_ManageUser()
            : base()
        {

        }
         
    }
}
