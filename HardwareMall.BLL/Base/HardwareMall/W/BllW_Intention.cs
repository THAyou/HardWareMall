//------------------
//-- Create By lookchem 3.0
//-- File: Bll/Base/BllW_Intention.cs
//-- 2020/3/20 15:07:44
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Dal;

namespace Bll.Base.HardwareMall
{
    public abstract class BllW_Intention:Bll.Base.BaseBll
    {
        protected readonly Dal.HardwareMall.DalW_Intention dal = Dal.HardwareMall.DalW_Intention.Instance();

        public BllW_Intention() { }

        /// <summary>
        /// 实例化一个当前逻辑操作对象
        /// </summary>
        /// <returns></returns>
        public static Bll.HardwareMall.BllW_Intention Instance()
        {
            return new Bll.HardwareMall.BllW_Intention();
        }
        /// <summary>
        /// 增加记录并且返回当前信息ID
        /// </summary>
        /// <param name="w_Intention">Model.HardwareMall.ModW_Intention</param>
        /// <returns>>成功返回当前插入ID，失败返回0</returns>
        public virtual int Add(Model.HardwareMall.ModW_Intention model)
        {
            return dal.Add(model);
        }
		/// <summary>
        /// 增加记录,返回成功或失败
        /// </summary>
        /// <param name="w_Intention">Model.HardwareMall.ModW_Intention</param>
        /// <returns>True or False</returns>
        public virtual bool AddNoReturn(Model.HardwareMall.ModW_Intention model)
        {
            return dal.AddNoReturn(model);
        }
		/// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="w_Intention">Model.HardwareMall.ModW_Intention</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Model.HardwareMall.ModW_Intention model)
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
        public virtual Model.HardwareMall.ModW_Intention GetModel(int id)
        {
            return dal.GetModel(id);
        }
        /// <summary>
        /// 根据Id取得一条记录
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="cols">需要获取的字段，例:"id,name,classid"</param>
        /// <returns>无记录或出错返回 null，有记录返回一个Model</returns>
        public virtual Model.HardwareMall.ModW_Intention GetModel(int id, string cols)
        {   if(CheckSqlField(cols)){          
               return dal.GetModel(id, cols);
            }
            else{
               return null;
            }
        }

    }
}
