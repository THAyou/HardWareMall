using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HardwareMall.Web.Model
{
    public class PageModel<T>
    {
        /// <summary>
        /// 当前页标
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; } = 1;

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { set; get; } = 9;
        /// <summary>
        /// 返回数据
        /// </summary>
        public List<T> data { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public int code { get; set; } = 0;
        /// <summary>
        /// 信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int count { get; set; }
    }

    public class PageDTModel
    {
        /// <summary>
        /// 当前页标
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; } = 6;

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { set; get; } = 20;
        /// <summary>
        /// 返回数据
        /// </summary>
        public DataTable data { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public int code { get; set; } = 0;
        /// <summary>
        /// 信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int count { get; set; }
    }
}
