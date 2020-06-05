//------------------
//-- Create By lookchem 3.0
//-- File: Bll/BllW_ProductImg.cs
//-- 2020/3/9 14:05:43
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using Model.HardwareMall;
using System.Data.SqlClient;
using HardwareMall.Tool.DataTableHelp;
using HardwareMall.Web.Model;

namespace Bll.HardwareMall
{
    public class BllW_ProductImg:Bll.Base.HardwareMall.BllW_ProductImg
    {
        /// <summary>
        /// 获取产品的图片集合
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public List<ModW_ProductImg> GetProductImg(int ProductId)
        {
            string sql = "select * from W_ProductImg where ProductId=@ProductId and Isdel=0 order by IsTitleImg desc";
            SqlParameter[] parameters = { new SqlParameter("@ProductId", ProductId) };
            var DataTable=dal.ExecuteDataset(sql, parameters).Tables[0];
            return DataTable.ToList<ModW_ProductImg>();
        }


        /// <summary>
        /// 获取产品的图片集合(后台)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public PageModel<ModW_ProductImg> GetProductPageImg(int page, int limit,int ProductId)
        {
            string where = "ProductId=" + ProductId + " and Isdel=0";
            int totalCount = 0;
            var PageList = dal.GetPageList2("W_ProductImg", "*", where, "order by IsTitleImg desc", limit, page, ref totalCount).Tables[0];
            var PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalCount) / Convert.ToDecimal(limit)));
            var data = PageList.ToList<ModW_ProductImg>();
            return new PageModel<ModW_ProductImg>()
            {
                PageIndex = page,
                PageCount = PageCount,
                PageSize = limit,
                data = data,
                code = 0,
                msg = "获取成功",
                count = totalCount
            };
        }

        /// <summary>
        /// 设置列表图片
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ImgId"></param>
        /// <returns></returns>
        public void SetImgTitle(int ProductId,int ImgId)
        {
            string sql1 = "update W_ProductImg set IsTitleImg=0 where ProductId=" + ProductId;
            dal.ExecuteNonQuery(sql1);
            string sql2 = "update W_Product set ImgId=0 where Id=" + ProductId;
            dal.ExecuteNonQuery(sql2);

            string sql3 = "update W_ProductImg set IsTitleImg=1 where Id=" + ImgId;
            dal.ExecuteNonQuery(sql3);
            string sql4 = "update W_Product set ImgId=" + ImgId + " where Id=" + ProductId;
            dal.ExecuteNonQuery(sql4);
        }

        /// <summary>
        /// 删除产品图片(标记shanchu)
        /// </summary>
        /// <param name="ImgId"></param>
        public void DelProductImg(int ImgId)
        {
            string sql1 = "update W_ProductImg set Isdel=1 where Id=" + ImgId;
            dal.ExecuteNonQuery(sql1);
        }

        /// <summary>
        /// 验证是否能够添加包装信息
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public bool IsAddImg(int ProductId)
        {
            string sql = "select * from W_ProductImg where Isdel=0 and ProductId=" + ProductId;
            var data = dal.ExecuteDataset(sql).Tables[0].ToList<ModW_ProductImg>();
            if (data != null)
            {
                if (data.Count >= 3)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }
    }
}
