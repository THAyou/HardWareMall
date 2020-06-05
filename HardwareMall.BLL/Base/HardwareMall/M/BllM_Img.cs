﻿//------------------
//-- Create By lookchem 3.0
//-- File: Bll/Base/BllM_Img.cs
//-- 2020/3/12 13:44:19
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Dal;

namespace Bll.Base.HardwareMall
{
    public abstract class BllM_Img:Bll.Base.BaseBll
    {
        protected readonly Dal.HardwareMall.DalM_Img dal = Dal.HardwareMall.DalM_Img.Instance();

        public BllM_Img() { }

        /// <summary>
        /// 实例化一个当前逻辑操作对象
        /// </summary>
        /// <returns></returns>
        public static Bll.HardwareMall.BllM_Img Instance()
        {
            return new Bll.HardwareMall.BllM_Img();
        }
        /// <summary>
        /// 增加记录并且返回当前信息ID
        /// </summary>
        /// <param name="m_Img">Model.HardwareMall.ModM_Img</param>
        /// <returns>>成功返回当前插入ID，失败返回0</returns>
        public virtual int Add(Model.HardwareMall.ModM_Img model)
        {
            return dal.Add(model);
        }
		/// <summary>
        /// 增加记录,返回成功或失败
        /// </summary>
        /// <param name="m_Img">Model.HardwareMall.ModM_Img</param>
        /// <returns>True or False</returns>
        public virtual bool AddNoReturn(Model.HardwareMall.ModM_Img model)
        {
            return dal.AddNoReturn(model);
        }
		/// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="m_Img">Model.HardwareMall.ModM_Img</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Model.HardwareMall.ModM_Img model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="keyValue">Dictionary<string, object> keyValue</param>
        /// <param name="id">更新记录ID</param>
        /// <returns>成功True ,失败False</returns>
        public bool Update(Dictionary<string, object> keyValue, int id)
        {
            return dal.Update(keyValue, id);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>True or False</returns>
        public virtual bool Delete(int id)
        {
            return dal.Delete(id);
        }
        /// <summary>
        /// 根据Id取得一条记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>无记录或出错返回 null，有记录返回一个Model</returns>
        public virtual Model.HardwareMall.ModM_Img GetModel(int id)
        {
            return dal.GetModel(id);
        }
        /// <summary>
        /// 根据Id取得一条记录
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="cols">需要获取的字段，例:"id,name,classid"</param>
        /// <returns>无记录或出错返回 null，有记录返回一个Model</returns>
        public virtual Model.HardwareMall.ModM_Img GetModel(int id, string cols)
        {   if(CheckSqlField(cols)){          
               return dal.GetModel(id, cols);
            }
            else{
               return null;
            }
        }

    }
}
