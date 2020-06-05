//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalM_News.cs
//-- 2020/3/12 14:55:05
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
    public class DalM_News:Dal.Base.HardwareMall.DalM_News
    {
	public DalM_News(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalM_News()
            : base()
        {

        }
         
    }
}
