//------------------
//-- Create By lookchem 3.0
//-- File: Bll/Base/BllM_PandR.cs
//-- 2020/3/23 18:08:50
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Dal;

namespace Bll.Base.HardwareMall_Chinese
{
    public abstract class BllM_PandR:Bll.Base.BaseBll
    {
        protected readonly Dal.HardwareMall_Chinese.DalM_PandR dal = Dal.HardwareMall_Chinese.DalM_PandR.Instance();

        public BllM_PandR() { }

        /// <summary>
        /// 实例化一个当前逻辑操作对象
        /// </summary>
        /// <returns></returns>
        public static Bll.HardwareMall_Chinese.BllM_PandR Instance()
        {
            return new Bll.HardwareMall_Chinese.BllM_PandR();
        }
        /// <summary>
        /// 增加记录并且返回当前信息ID
        /// </summary>
        /// <param name="m_PandR">Model.HardwareMall_Chinese.ModM_PandR</param>
        /// <returns>>成功返回当前插入ID，失败返回0</returns>
        public virtual int Add(Model.HardwareMall_Chinese.ModM_PandR model)
        {
            return dal.Add(model);
        }
		/// <summary>
        /// 增加记录,返回成功或失败
        /// </summary>
        /// <param name="m_PandR">Model.HardwareMall_Chinese.ModM_PandR</param>
        /// <returns>True or False</returns>
        public virtual bool AddNoReturn(Model.HardwareMall_Chinese.ModM_PandR model)
        {
            return dal.AddNoReturn(model);
        }
		/// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="m_PandR">Model.HardwareMall_Chinese.ModM_PandR</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Model.HardwareMall_Chinese.ModM_PandR model)
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
        public virtual Model.HardwareMall_Chinese.ModM_PandR GetModel(int id)
        {
            return dal.GetModel(id);
        }
        /// <summary>
        /// 根据Id取得一条记录
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="cols">需要获取的字段，例:"id,name,classid"</param>
        /// <returns>无记录或出错返回 null，有记录返回一个Model</returns>
        public virtual Model.HardwareMall_Chinese.ModM_PandR GetModel(int id, string cols)
        {   if(CheckSqlField(cols)){          
               return dal.GetModel(id, cols);
            }
            else{
               return null;
            }
        }

    }
}
