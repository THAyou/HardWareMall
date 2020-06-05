//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalM_Img.cs
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
    public class DalM_Img:Dal.Base.HardwareMall.DalM_Img
    {
	public DalM_Img(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalM_Img()
            : base()
        {

        }
         
    }
}
