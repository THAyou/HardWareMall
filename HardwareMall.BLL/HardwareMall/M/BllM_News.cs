
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using HardwareMall.Web.Model;
using HardwareMall.Model;
using HardwareMall.Tool.DataTableHelp;
using Model.HardwareMall;

namespace Bll.HardwareMall
{
    public class BllM_News : Bll.Base.HardwareMall.BllM_News
    {
        /// <summary>
        /// 新闻分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public PageModel<NewsDto> GetNewPageList(int page, int limit,int NewsType)
        {
            string where = "NewsType=" + NewsType;
            int totalCount = 0;
            var PageList = dal.GetPageList2("M_News", "Id,NewsType,NewsTitle,NewsDataTime", where, "order by NewsDataTime desc", limit, page, ref totalCount).Tables[0];
            var PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalCount) / Convert.ToDecimal(limit)));
            return new PageModel<NewsDto>()
            {
                PageIndex = page,
                PageCount = PageCount,
                PageSize = limit,
                data = PageList.ToList<NewsDto>(),
                code = 1,
                msg = "获取成功",
                count = PageList.Rows.Count
            };
        }

        /// <summary>
        /// 新闻分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public PageDTModel GetNewManagePageList(int page, int limit, int NewsType)
        {
            string where = "1=1";
            if (NewsType != 0)
            {
                where+= " and NewsType=" + NewsType;
            }
            int totalCount = 0;
            var PageList = dal.GetPageList2("M_News", "Id,NewsType,NewsTitle,NewsDataTime", where, "order by CreateTime desc", limit, page, ref totalCount).Tables[0];
            var PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalCount) / Convert.ToDecimal(limit)));
            return new PageDTModel
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
        /// 获取新闻内容(内容已经分段)
        /// </summary>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        public object GetNewsContent(int NewsId)
        {
            var Info = dal.GetModel(NewsId);
            var NewsContent = Info.NewsContent;
            return new
            {
                newsTitle = Info.NewsTitle,
                newsContent = NewsContent,
                newsDataTime = Info.NewsDataTime,
                img=Info.Img
            };
        }

        /// <summary>
        /// 获取首页新闻列表
        /// </summary>
        /// <returns></returns>
        public List<NewsDto> GetHomeNews(int NewsType)
        {
            string sql = "select top 7 Id,NewsType,NewsTitle,NewsDataTime from M_News  where NewsType=" + NewsType+ " order by NewsDataTime desc";
            var DataTable = dal.ExecuteDataset(sql).Tables[0];
            var result = new List<NewsDto>();
            if (DataTable != null & DataTable.Rows.Count > 0)
            {
                result = DataTable.ToList<NewsDto>();
            }
            return result;
        }
    }
}
