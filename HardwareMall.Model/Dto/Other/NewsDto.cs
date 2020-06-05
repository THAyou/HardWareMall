using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareMall.Model
{
    public class NewsDto
    {
        /// <summary>
        /// 新闻Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string NewsTitle { get; set; }

        /// <summary>
        /// 新闻类型
        /// </summary>
        public int NewsType { get; set; }

        /// <summary>
        /// 新闻时间
        /// </summary>
        public DateTime NewsDataTime { get; set; }

        /// <summary>
        /// 新闻时间转换时间格式
        /// </summary>
        public string NewsDataTimeStr { get { return NewsDataTime.ToString("yyyy-MM-dd"); } }
    }
}
