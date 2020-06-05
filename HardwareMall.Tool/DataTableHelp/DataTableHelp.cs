using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace HardwareMall.Tool.DataTableHelp
{
    /// <summary>
    /// DataTable转换实体类工具
    /// 作者:Tyou 2019/05/11 11:41:00
    /// </summary>
    public static class DataTableHelp
    {
        /// <summary>
        /// 将DataTable转换为List集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = RowToObj<T>(row);
                data.Add(item);
            }
            return data;
        }

        /// <summary>
        /// 将DataRow转换成实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T RowToObj<T>(this DataRow dr)
        {
            try
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();
                //循环DataRow内的字段
                foreach (DataColumn column in dr.Table.Columns)
                {
                    //利用PropertyInfo 将实体类里的属性进行遍历，赋值
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        //变量名和字段名是否一致
                        if (pro.Name.ToLower() == column.ColumnName.ToLower())
                        {
                            //如果字段值不为空，则赋值
                            if (dr[column.ColumnName] == DBNull.Value)
                            {
                                break;
                            }
                            else
                            {
                                //将字段值转化为和实体类属性相同类型
                                var value = dr[column.ColumnName].Obj_ChanageType(pro.GetMethod.ReturnType);
                                //复制操作
                                pro.SetValue(obj, value, null);
                                break;
                            }
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                return Activator.CreateInstance<T>();
            }
        }

        /// <summary>
        /// 将Obj转化为指定类型，并且判断是否为可空类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="convertsionType"></param>
        /// <returns></returns>
        public static object Obj_ChanageType(this object value, Type convertsionType)
        {
            //判断convertsionType类型是否为泛型，因为nullable是泛型类,
            if (convertsionType.IsGenericType &&
                //判断convertsionType是否为nullable泛型类
                convertsionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || value.ToString().Length == 0)
                {
                    return null;
                }

                //如果convertsionType为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                NullableConverter nullableConverter = new NullableConverter(convertsionType);
                //将convertsionType转换为nullable对的基础基元类型
                convertsionType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, convertsionType);
        }
    }
}
