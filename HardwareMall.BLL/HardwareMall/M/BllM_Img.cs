//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllM_Img.cs
//-- 2020/3/12 13:44:19
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
    public class BllM_Img:Bll.Base.HardwareMall.BllM_Img
    {
        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="ImgIds"></param>
        /// <returns></returns>
        public List<ModM_Img> GetImgs(string ImgIds)
        {
            string sql = "select * from M_Img where Id in ("+ImgIds+")";
            return dal.ExecuteDataset(sql).Tables[0].ToList<ModM_Img>();
        }
    }
}
