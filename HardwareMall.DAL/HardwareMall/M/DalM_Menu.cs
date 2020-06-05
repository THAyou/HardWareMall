//------------------
//-- Create By lookchem 3.0
//-- File: Dal/DalM_Menu.cs
//-- 2020/3/20 15:46:58
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
    public class DalM_Menu:Dal.Base.HardwareMall.DalM_Menu
    {
	public DalM_Menu(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }

        public DalM_Menu()
            : base()
        {

        }
         
    }
}
