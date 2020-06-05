﻿//------------------
//-- Create By lookchem 3.0
//-- File: Dal/Base/DalW_ProductAndType.cs
//-- 2020/3/10 15:12:59
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using DBUtility;
 
namespace Dal.Base.HardwareMall
{
    public abstract class DalW_ProductAndType:HardwareMallBase
    {
		
		public DalW_ProductAndType():base()
        {

        }
        public DalW_ProductAndType(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }
		
        /// <summary>
        /// 实例化一个当前数据操作对象
        /// </summary>
        /// <returns></returns>
        public static Dal.HardwareMall.DalW_ProductAndType Instance()
        {
            return  new Dal.HardwareMall.DalW_ProductAndType();
        } 

        /// <summary>
        /// 增加记录并且返回当前信息ID
        /// </summary>
        /// <param name="w_ProductAndType">Model.HardwareMall.ModW_ProductAndType</param>
        /// <returns>成功返回当前插入ID，失败返回0</returns>
        public virtual int Add(Model.HardwareMall.ModW_ProductAndType model)
        {
             
            string sql = "insert into dbo.W_ProductAndType ([ProTypeID],[ProID],[Isdel])values(@ProTypeID,@ProID,@Isdel);select SCOPE_IDENTITY() as InsertId";
            SqlParameter[] parameters = {

				new SqlParameter("@ProTypeID",SqlDbType.Int,4),
				new SqlParameter("@ProID",SqlDbType.Int,4),
				new SqlParameter("@Isdel",SqlDbType.Bit,1)		
	
            };
			
				parameters[0].Value = model.ProTypeID ;
				parameters[1].Value = model.ProID ;
				parameters[2].Value = model.Isdel ;



            object insertId = this.ExecuteScalar(sql, DB.ReadAndWrite, parameters);
            if(insertId==null){
			   return 0;
			}
			else{
			   return int.Parse(insertId.ToString());
			}

          
        }
		
		/// <summary>
        /// 增加记录,返回成功或失败
        /// </summary>
        /// <param name="w_ProductAndType">Model.HardwareMall.ModW_ProductAndType</param>
        /// <returns>成功返回True，错误返回False</returns>
        public virtual bool AddNoReturn(Model.HardwareMall.ModW_ProductAndType model)
        {
             
            string sql = "insert into dbo.W_ProductAndType ([ProTypeID],[ProID],[Isdel])values(@ProTypeID,@ProID,@Isdel)";
            SqlParameter[] parameters = {

				new SqlParameter("@ProTypeID",SqlDbType.Int,4),
				new SqlParameter("@ProID",SqlDbType.Int,4),
				new SqlParameter("@Isdel",SqlDbType.Bit,1)			
	
            };
			
				parameters[0].Value = model.ProTypeID ;
				parameters[1].Value = model.ProID ;
				parameters[2].Value = model.Isdel ;



            if(this.ExecuteNonQuery(sql, DB.ReadAndWrite, parameters)>0){
			   return true;
			}
			else{
			   return false;
			}

          
        }
		
		
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="w_ProductAndType">Model.HardwareMall.ModW_ProductAndType</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Model.HardwareMall.ModW_ProductAndType model)
        {
            
            string sql = @"update dbo.W_ProductAndType set [ProTypeID] = @ProTypeID ,[ProID] = @ProID ,[Isdel] = @Isdel  where [Id]=@Id";
            SqlParameter[] parameters = {

				new SqlParameter("@Id",SqlDbType.Int,4),
				new SqlParameter("@ProTypeID",SqlDbType.Int,4),
				new SqlParameter("@ProID",SqlDbType.Int,4),
				new SqlParameter("@Isdel",SqlDbType.Bit,1)
	  	
	
            };
				parameters[0].Value = model.Id ;
				parameters[1].Value = model.ProTypeID ;
				parameters[2].Value = model.ProID ;
				parameters[3].Value = model.Isdel ;


            if(this.ExecuteNonQuery(sql, DB.ReadAndWrite, parameters)>0){
			   return true;
			}
			else{
			   return false;
			}
          
        }


        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="keyValue">Dictionary<string, object> keyValue</param>
        /// <param name="id">更新记录ID</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Dictionary<string, object> keyValue, int id)
        {
            string sql = "update dbo.W_ProductAndType set ";
            SqlParameter[] param = new SqlParameter[keyValue.Count];
            int i = 0;
            foreach (KeyValuePair<string, object> item in keyValue)
            {
                sql += string.Format("{0}=@{0},", item.Key);
                param[i] = new SqlParameter("@" + item.Key, item.Value);
                i++;
            }
            sql = sql.TrimEnd(',') + " where Id=" + id.ToString();
            if (this.ExecuteNonQuery(sql, DB.ReadAndWrite, param) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		
		
	/// <summary>
        /// 设置Bit类型字段的值
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="setValue">要设的值</param>
        /// <param name="id">信息ID</param>
        /// <returns>true or false</returns>
        public bool UpdateBitField(string fieldName, bool setValue, int id)
        {
            string sql = string.Format("update dbo.W_ProductAndType set {0} = @SetValue where [Id]=@Id", fieldName);
            SqlParameter[] parameters = {
                new SqlParameter("@SetValue", SqlDbType.Bit,1),
				new SqlParameter("@Id", SqlDbType.Int,4)
                };
            parameters[0].Value = setValue;
            parameters[1].Value = id;

            if (this.ExecuteNonQuery(sql, DB.ReadAndWrite, parameters) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
		
		
		
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>True or False</returns>
        public virtual bool Delete(int id)
        {
            
            string sql = @"delete from dbo.W_ProductAndType where [Id]=@Id";
            SqlParameter[] parameters = {
			new SqlParameter("@Id", SqlDbType.Int)
            };
            parameters[0].Value = id;
            
			if(this.ExecuteNonQuery(sql, DB.ReadAndWrite, parameters)>0){
			   return true;
			}
			else{
			   return false;
			}

        
        }
        /// <summary>
        /// 根据Id取得一条记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>无记录或出错返回 null，有记录返回一个Model</returns>
        public virtual Model.HardwareMall.ModW_ProductAndType GetModel(int id)
        {
            string sql = @"select * from dbo.W_ProductAndType where [Id]=@Id";
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModW_ProductAndType model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModW_ProductAndType();
			
           				       if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}
           				       if(reader["ProTypeID"]!= System.DBNull.Value) {model.ProTypeID = System.Int32.Parse(reader["ProTypeID"].ToString());}
           				       if(reader["ProID"]!= System.DBNull.Value) {model.ProID = System.Int32.Parse(reader["ProID"].ToString());}
           				       if(reader["Isdel"]!= System.DBNull.Value) {model.Isdel = System.Boolean.Parse(reader["Isdel"].ToString());}
  		

                 }
           
                reader.Close();
                
                return model;
            }
        }
		
		

        /// <summary>
        /// 根据Id和字段名取得一条记录
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="cols">需要获取的字段，例:"id,name,classid"</param>
        /// <returns>无记录或出错返回 null，有记录返回一个Model</returns>
        public virtual Model.HardwareMall.ModW_ProductAndType GetModel(int id,string cols)
        {
            cols = cols.ToLower();
            string sql = @"select "+cols+" from dbo.W_ProductAndType where [Id]=@Id";
            cols = "," + cols + ","; 
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModW_ProductAndType model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModW_ProductAndType();
			
           				       if(cols.IndexOf(",Id,".ToLower())>=0){if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}}
           				       if(cols.IndexOf(",ProTypeID,".ToLower())>=0){if(reader["ProTypeID"]!= System.DBNull.Value) {model.ProTypeID = System.Int32.Parse(reader["ProTypeID"].ToString());}}
           				       if(cols.IndexOf(",ProID,".ToLower())>=0){if(reader["ProID"]!= System.DBNull.Value) {model.ProID = System.Int32.Parse(reader["ProID"].ToString());}}
           				       if(cols.IndexOf(",Isdel,".ToLower())>=0){if(reader["Isdel"]!= System.DBNull.Value) {model.Isdel = System.Boolean.Parse(reader["Isdel"].ToString());}}
  		

                 }
           
                reader.Close();
                
                return model;
            }
        }



		/// <summary>
        /// 获取列表记录
        /// </summary>
		/// <param name="top">获取记录条数(不限则为0)</param>
        /// <param name="col">需要获取的字段</param>
        /// <param name="where">where条件,不带where关键字.例: classid = 1</param>
        /// <param name="orderby">order by 条件,不带order by</param>
        /// <returns></returns>
        public DataTable GetSelectList(int top,string col, string where, string orderby)
        {
			string selectTop = "";
			if(top<0) {top=0;}
			if (top > 0) {selectTop = " top " + top.ToString();}
			
            if (string.IsNullOrEmpty(col))
            {
                col = "*";
            }


            if (!string.IsNullOrEmpty(where))
            {
                where = " where " + where;
            }
            if (!string.IsNullOrEmpty(orderby))
            {
                orderby = " order by " + orderby;
            }

            string sql = string.Format("select {3} {0} from dbo.W_ProductAndType {1} {2}", col, where, orderby,selectTop);
            DataTable dt = this.ExecuteDataset(sql).Tables[0];
            return dt;

        }
		
		
		
    }
}