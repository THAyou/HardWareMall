//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllW_ProductType.cs
//-- 2020/3/6 14:31:08
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using Model.HardwareMall;
using HardwareMall.Tool.DataTableHelp;
using System.Data.SqlClient;
using System.Linq;

namespace Bll.HardwareMall
{
    public class BllW_ProductType:Bll.Base.HardwareMall.BllW_ProductType
    {
        /// <summary>
        /// 获取所有产品集合
        /// </summary>
        /// <returns></returns>
        public List<ModW_ProductType> GetProductTypeList()
        {
            string sql = "select * from W_ProductType where IsDel=0 order by Sort asc";
            var list = new List<ModW_ProductType>();
            var data = dal.ExecuteDataset(sql).Tables[0];
            if (data != null && data.Rows.Count > 0)
            {
                list = data.ToList<ModW_ProductType>();
            }
            return list;
        }

        /// <summary>
        /// 获取所有产品集合
        /// </summary>
        /// <returns></returns>
        public List<ModW_ProductType> GetProductTypeList2(int Id = 0)
        {
            string where = "where IsDel=0";
            string Ids = GetChilType(Id);
            if (Ids != string.Empty)
            {
                Ids += ",";
            }
            Ids += Id;
            if (Id != 0)
            {
                where += " and Id not in (" + Ids + ")";
            }
            string sql = "select * from W_ProductType " + where + " order by Sort asc";
            var list = dal.ExecuteDataset(sql).Tables[0].ToList<ModW_ProductType>();
            return list;
        }

        /// <summary>
        /// 修改产品分类
        /// </summary>
        /// <param name="model"></param>
        public void UpdateProductType(ModW_ProductType model)
        {
            string sql = "update W_ProductType set TypeName=@TypeName,ParentId=@ParentId,UpdateBy=@UpdateBy,UpdateTime=@UpdateTime,Sort=@Sort,Img=@Img where Id=@Id";
            SqlParameter[] parameters ={
                new SqlParameter("@TypeName",model.TypeName),
                new SqlParameter("@ParentId",model.ParentId),
                new SqlParameter("@UpdateBy",model.UpdateBy),
                new SqlParameter("@UpdateTime",model.UpdateTime),
                new SqlParameter("@Sort",model.Sort),
                new SqlParameter("@Img",model.Img),
                new SqlParameter("@Id",model.Id),
            };
            dal.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 标记删除产品分类
        /// </summary>
        /// <param name="Id"></param>
        public void DelProductType(string Id)
        {
            string Ids = GetChilType(int.Parse(Id));
            if (Ids != string.Empty)
            {
                Ids += ",";
            }
            Ids += Id;
            string sql = "update W_ProductType set Isdel=1 where Id in (" + Ids + ")";
            dal.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 获取产品类型所有的子类型（递归）
        /// </summary>
        /// <param name="PTypeId"></param>
        /// <returns></returns>
        public string GetChilType(int PTypeId)
        {
            string res = string.Empty;
            string sql = @"select * from W_ProductType where ParentId =@PTypeId	";
            SqlParameter[] parameters = { new SqlParameter("@PTypeId", PTypeId) };
            var list = dal.ExecuteDataset(sql, parameters).Tables[0].ToList<ModW_ProductType>();
            list.ForEach(m =>
            {
                if (res != string.Empty)
                {
                    res += ",";
                }
                res += m.Id;
                var ChilIdStr = GetChilType(m.Id);
                if (ChilIdStr != string.Empty)
                {
                    res += "," + ChilIdStr;
                }
            });
            return res;
        }
    }
}
