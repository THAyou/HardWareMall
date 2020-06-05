using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HardwareMall.Tool.EnumHelper
{
    /// <summary>
    /// 首页配置类型
    /// </summary>
    public enum HomeElementType
    {
        /// <summary>
        /// 横幅
        /// </summary>
        [Description("横幅")]
        Banner =10,

        /// <summary>
        /// 优质品牌
        /// </summary>
        [Description("优质品牌")]
        QualityBrand=30,

        /// <summary>
        /// 新闻资讯配图
        /// </summary>
        [Description("新闻资讯配图")]
        NewsInformationImg = 40,

        /// <summary>
        /// 留言栏联系方式
        /// </summary>
        [Description("留言栏联系方式")]
        Tel = 80,

        /// <summary>
        /// 备案号
        /// </summary>
        [Description("备案号")]
        RecordNum = 90,

        /// <summary>
        /// FaceBook跳转地址
        /// </summary>
        [Description("FaceBook跳转地址")]
        FaceBookUrl = 100,

        /// <summary>
        /// 页面可替换小图片
        /// </summary>
        [Description("页面可替换小图片")]
        SmallPicture =110,
    }

    /// <summary>
    /// 网站内容配置
    /// </summary>
    public enum WebConfigEnum
    {
        /// <summary>
        /// 品牌页
        /// </summary>
        [Description("品牌页")]
        Brand =10,

        /// <summary>
        /// 品牌页
        /// </summary>
        [Description("服务页")]
        Service = 20,

        /// <summary>
        /// 公司页
        /// </summary>
        [Description("公司页")]
        Company=30,

        /// <summary>
        /// 招聘页面
        /// </summary>
        [Description("招聘页面")]
        Job=40,

        /// <summary>
        /// 联系页面
        /// </summary>
        [Description("联系页面")]
        Contact=50,

        /// <summary>
        /// Terms & Conditions
        /// </summary>
        [Description("Terms & Conditions")]
        TermsConditions = 60

    }

    /// <summary>
    /// 新闻类型
    /// </summary>
    public enum NewsType 
    {
        /// <summary>
        /// 公司新闻
        /// </summary>
        [Description("公司新闻")]
        CompanyNews =1,

        /// <summary>
        /// 行业资讯
        /// </summary>
        [Description("行业资讯")]
        IndustryNews = 2
    }

    /// <summary>
    /// 枚举工具类
    /// </summary>
    public static class EnumExtend
    {
        private static Dictionary<string, Dictionary<string, string>> _enumCache;

        private static Dictionary<string, Dictionary<string, string>> EnumCache
        {
            get
            {
                if (_enumCache == null)
                {
                    _enumCache = new Dictionary<string, Dictionary<string, string>>();
                }
                return _enumCache;
            }
            set { _enumCache = value; }
        }

        /// <summary>
        /// 获得枚举提示文本
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum e)
        {
            string enumName = string.Empty;
            if (e == null)
            {

                return enumName;
            }
            var type = e.GetType();
            enumName = e.ToString();

            if (!EnumCache.ContainsKey(type.FullName))
            {
                var fields = type.GetFields();
                Dictionary<string, string> temp = new Dictionary<string, string>();
                foreach (var item in fields)
                {
                    var attrs = item.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attrs.Length == 1)
                    {
                        var v = ((DescriptionAttribute)attrs[0]).Description;
                        temp.Add(item.Name, v);
                    }
                }
                EnumCache.Add(type.FullName, temp);
            }
            if (EnumCache[type.FullName].ContainsKey(enumName))
            {
                return EnumCache[type.FullName][enumName];
            }
            return enumName;
        }


        /// <summary>
        /// 根据枚举返回  List<SelectListItem>
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="selectText">默认文本</param>
        /// <param name="selectValue">默认值</param>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectList(Type enumType, string selectText = "", string selectValue = "")
        {
            return enumType.ToSelectList(true, selectText, selectValue);
        }


        /// <summary>
        /// 根据枚举返回 SelectListItem 集合
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="isValue">true:枚举值，false:枚举名</param>
        /// <param name="selectText">默认文本</param>
        /// <param name="selectValue">默认值</param>
        /// <returns></returns>
        public static List<SelectListItem> ToSelectList(this Type enumType, bool isValue = true, string selectText = "", string selectValue = "")
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            if (enumType.IsEnum)
            {
                if (!string.IsNullOrEmpty(selectText))
                {
                    listItem.Add(new SelectListItem() { Value = selectValue, Text = selectText });
                }
                var names = System.Enum.GetNames(enumType);
                names.ToList().ForEach(item =>
                {
                    string description = string.Empty;
                    var field = enumType.GetField(item);
                    object[] arr = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true); //获取属性字段数组    
                    description = arr != null && arr.Length > 0 ? ((System.ComponentModel.DescriptionAttribute)arr[0]).Description : item;   //属性描述    
                    string resDesp = description;

                    var val = isValue ? (int)System.Enum.Parse(enumType, item) : System.Enum.Parse(enumType, item);

                    listItem.Add(new SelectListItem() { Value = val.ToString(), Text = resDesp });
                });
            }
            else
            {
                throw new ArgumentException("枚举类型无效");
            }
            return listItem;
        }

        /// <summary>
        /// 读取枚举类型
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="isValue"></param>
        /// <returns></returns>
        public static List<ItemValueModel> ToDList(this Type enumType, bool isValue = true)
        {
            List<ItemValueModel> listItem = new List<ItemValueModel>();
            if (enumType.IsEnum)
            {
                var names = System.Enum.GetNames(enumType);
                names.ToList().ForEach(item =>
                {
                    string description = string.Empty;
                    var field = enumType.GetField(item);
                    object[] arr = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true); //获取属性字段数组    
                    description = arr != null && arr.Length > 0 ? ((System.ComponentModel.DescriptionAttribute)arr[0]).Description : item;   //属性描述    
                    string resDesp = description;
                    var val = isValue ? (int)System.Enum.Parse(enumType, item) : System.Enum.Parse(enumType, item);
                    listItem.Add(new ItemValueModel() { id = Convert.ToInt32(val), value = resDesp });
                });
            }
            else
            {
                throw new ArgumentException("枚举类型无效");
            }
            return listItem;
        }

        /// <summary>
        /// 根据枚举返回 SelectListItem 集合
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="selected">默认选中</param>
        /// <param name="isValue">true:枚举值，false:枚举名</param>
        /// <returns></returns>
        public static List<SelectListItem> ToSelectList(this Type enumType, string selected, bool isValue = true)
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            if (enumType.IsEnum)
            {
                var names = System.Enum.GetNames(enumType);
                names.ToList().ForEach(item =>
                {
                    string description = string.Empty;
                    var field = enumType.GetField(item);
                    object[] arr = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true); //获取属性字段数组    
                    description = arr != null && arr.Length > 0 ? ((System.ComponentModel.DescriptionAttribute)arr[0]).Description : item;   //属性描述    
                    string resDesp = description;

                    var val = isValue ? (int)System.Enum.Parse(enumType, item) : System.Enum.Parse(enumType, item);
                    if (!string.IsNullOrWhiteSpace(selected))
                    {
                        if (selected.Equals(System.Enum.Parse(enumType, item).ToString()))
                        {
                            listItem.Add(new SelectListItem() { Value = val.ToString(), Text = resDesp, Selected = true });
                            return;
                        }
                    }
                    listItem.Add(new SelectListItem() { Value = val.ToString(), Text = resDesp });
                });
            }
            else
            {
                throw new ArgumentException("枚举类型无效");
            }
            return listItem;
        }

        public class ItemValueModel
        {
            public int id { get; set; }
            public string value { get; set; }
        }
    }
}
