using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareMall.Web.Model
{
    /// <summary>
    /// 搜素条件基础Model
    /// </summary>
    public class PageWhereBaseModel
    {
        public int Page { get; set; } = 1;

        public int Limit { get; set; } = 9;
    }
}
