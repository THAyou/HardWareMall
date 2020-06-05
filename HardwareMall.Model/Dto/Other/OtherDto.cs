using Model.HardwareMall;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareMall.Model
{
    /// <summary>
    /// 品牌页面传输对象
    /// </summary>
    public class OtherDto : ModM_OtherConfig
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgSrc { get; set; }

        public string[] Contents { get; set; }
    }
}
