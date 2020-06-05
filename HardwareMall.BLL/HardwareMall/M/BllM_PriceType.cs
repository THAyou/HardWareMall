//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllM_PriceType.cs
//-- 2020/3/16 14:29:53
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using Model.HardwareMall;
using HardwareMall.Tool.DataTableHelp;

namespace Bll.HardwareMall
{
    public class BllM_PriceType:Bll.Base.HardwareMall.BllM_PriceType
    {
        public List<ModM_PriceType> GetPriceTypeList() 
        {
            string sql = "select * from M_PriceType";
            return dal.ExecuteDataset(sql).Tables[0].ToList<ModM_PriceType>();
        }
    }
}
