//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using Model.HardwareMall;
using HardwareMall.Tool.DataTableHelp;
using HardwareMall.Tool.EnumHelper;
using System.Data.SqlClient;

namespace Bll.HardwareMall
{
    public class BllM_HomeElement:Bll.Base.HardwareMall.BllM_HomeElement
    {
        /// <summary>
        /// 获取首页元素配置
        /// </summary>
        /// <returns></returns>
        public List<ModM_HomeElement> GetHomeElement() 
        {
            string sql = "Select * from M_HomeElement";
            var result = new List<ModM_HomeElement>();
            var Data = dal.ExecuteDataset(sql).Tables[0];
            if (Data != null && Data.Rows.Count > 0)
            {
                result = Data.ToList<ModM_HomeElement>();
            }
            return result;
        }

        /// <summary>
        /// 获取首页管理列表
        /// </summary>
        /// <param name="HomeTypeEnum"></param>
        /// <returns></returns>
        public List<ModM_HomeElement> GetHomeElementManage(int HomeTypeEnum)
        {
            string sql = "Select * from M_HomeElement";
            string where = " where 1=1";
            if (HomeTypeEnum != 0)
            {
                where += " and HomeTypeEnum=" + HomeTypeEnum;
            }
            sql += where;
            sql += " order by HomeTypeEnum,Sort asc";
            return dal.ExecuteDataset(sql).Tables[0].ToList<ModM_HomeElement>();
        }

        /// <summary>
        /// 获取首页配置
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public ModM_HomeElement GetHomeElement(int Type)
        {
            string sql = "select * from M_HomeElement where HomeTypeEnum=" + Type + " order by Id asc";
            var result = new List<ModM_HomeElement>();
            var Data = dal.ExecuteDataset(sql).Tables[0];
            if (Data != null && Data.Rows.Count > 0)
            {
                result = Data.ToList<ModM_HomeElement>();
            }
            if (result.Count > 0)
            {
                return result[0];
            }
            return null;
        }

        /// <summary>
        /// 修改首页元素
        /// </summary>
        /// <param name="model"></param>
        public void UpdateHomeElement(ModM_HomeElement model)
        {
            string sql = "update M_HomeElement set HomeTypeEnum=@HomeTypeEnum,Img=@Img,Title=@Title,littleTitle=@littleTitle,Href=@Href,UpdateUser=@UpdateUser,UpdateTime=@UpdateTime,Sort=@Sort where Id=@Id";
            SqlParameter[] parameters = {
                new SqlParameter("@HomeTypeEnum",model.HomeTypeEnum),
                new SqlParameter("@Img",model.Img),
                new SqlParameter("@Title",model.Title),
                new SqlParameter("@littleTitle",model.LittleTitle),
                new SqlParameter("@Href",model.Href),
                new SqlParameter("@UpdateUser",model.UpdateUser),
                new SqlParameter("@UpdateTime",model.UpdateTime),
                new SqlParameter("@Sort",model.Sort),
                new SqlParameter("@Id",model.Id),
            };
            dal.ExecuteDataset(sql, parameters);
        }
    }
}
