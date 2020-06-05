//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllM_ManageUser.cs
//-- 2020/3/12 18:55:34
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using Model.HardwareMall;
using HardwareMall.Tool.DataTableHelp;
using HardwareMall.Web.Model;
using System.Data.SqlClient;

namespace Bll.HardwareMall
{
    public class BllM_ManageUser:Bll.Base.HardwareMall.BllM_ManageUser
    {
        /// <summary>
        /// 根据账号密码获取用户对象
        /// </summary>
        /// <returns></returns>
        public ModM_ManageUser GetUserByUserAndPsw(string UserName,string Password)
        {
            string sql = "select * from M_ManageUser where UserName='admin' and Password='" + Password + "' and Status=1 and Isdel=0";
            var list = dal.ExecuteDataset(sql).Tables[0].ToList<ModM_ManageUser>();
            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            return null;
        }


        /// <summary>
        /// 获取人员列表(后台)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public PageDTModel GetUserList(int page, int limit)
        {
            string where = "Isdel=0";
            int totalCount = 0;
            var PageList = dal.GetPageList2("M_ManageUser", "*", where, "order by id desc", limit, page, ref totalCount).Tables[0];
            var PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalCount) / Convert.ToDecimal(limit)));
            return new PageDTModel()
            {
                PageIndex = page,
                PageCount = PageCount,
                PageSize = limit,
                data = PageList,
                code = 0,
                msg = "获取成功",
                count = totalCount
            };
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model"></param>
        public void UpdataUser(ModM_ManageUser model)
        {
            string sql = "update M_ManageUser set UserName=@UserName,RealName=@RealName where Id=@Id";
            SqlParameter[] parameters = {
                new SqlParameter("@UserName",model.UserName),
                new SqlParameter("@RealName",model.RealName),
                new SqlParameter("@Id",model.Id),
            };
            dal.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="Id"></param>
        public void UpdataPsw(int Id,string Password)
        {
            string sql = "update M_ManageUser set Password=@Password where Id=@Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Password",Password),
                new SqlParameter("@Id",Id),
            };
            dal.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="Id"></param>
        public void UpdataStatus(int Id, int Status)
        {
            string sql = "update M_ManageUser set Status=@Status where Id=@Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Status",Status),
                new SqlParameter("@Id",Id),
            };
            dal.ExecuteNonQuery(sql, parameters);
        }
    }
}
