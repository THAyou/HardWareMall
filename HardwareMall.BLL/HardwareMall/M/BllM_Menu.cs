//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllM_Menu.cs
//-- 2020/3/20 15:46:58
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using Model.HardwareMall;
using HardwareMall.Tool.DataTableHelp;
using HardwareMall.Web.Model;

namespace Bll.HardwareMall
{
    public class BllM_Menu:Bll.Base.HardwareMall.BllM_Menu
    {
        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        public List<ModM_Menu> GetMenuList()
        {
            string sql = "select * from M_Menu";
            return dal.ExecuteDataset(sql).Tables[0].ToList<ModM_Menu>();
        }

        /// <summary>
        /// 获取后台日志
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public PageDTModel GetManageLog(int page, int limit,string LogLevel,string CreateTime)
        {
            string where = "1=1";
            if (!string.IsNullOrWhiteSpace(CreateTime))
            {
                var CreateTimeBegin = CreateTime.Split(" - ")[0];
                var CreateTimeEnd = CreateTime.Split(" - ")[1];
                where += " and (CreateTime>='" + CreateTimeBegin + "' and CreateTime<='" + CreateTimeEnd + "')";
            }
            if (!string.IsNullOrWhiteSpace(LogLevel))
            {
                where += "and LogLevel='" + LogLevel + "'";
            }
            int totalCount = 0;
            var PageList = dal.GetPageList2("M_ManageLog", "*", where, "order by id desc", limit, page, ref totalCount).Tables[0];
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
        /// 获取后台日志
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public PageDTModel GetWebLog(int page, int limit, string LogLevel, string CreateTime)
        {
            string where = "1=1";
            if (!string.IsNullOrWhiteSpace(CreateTime))
            {
                var CreateTimeBegin = CreateTime.Split(" - ")[0];
                var CreateTimeEnd = CreateTime.Split(" - ")[1];
                where += " and (CreateTime>='" + CreateTimeBegin + "' and CreateTime<='" + CreateTimeEnd + "')";
            }
            if (!string.IsNullOrWhiteSpace(LogLevel))
            {
                where += "and LogLevel='" + LogLevel + "'";
            }
            int totalCount = 0;
            var PageList = dal.GetPageList2("M_WebLog", "*", where, "order by id desc", limit, page, ref totalCount).Tables[0];
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
    }
}
