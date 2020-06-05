using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareMall.Tool
{
    public static class JsonHelper
    {
        /// <summary>
        /// Json转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string json)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return Activator.CreateInstance<T>();
            }
            
        }

        /// <summary>
        /// 对象装换为Json
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToJson(this object val)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(val);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
