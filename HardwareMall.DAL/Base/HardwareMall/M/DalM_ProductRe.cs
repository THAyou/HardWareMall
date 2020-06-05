//------------------
//-- Create By lookchem 3.0
//-- File: Dal/Base/DalM_ProductRe.cs
//-- 2020/3/23 18:08:50
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using DBUtility;
using Dal.Base.HardwareMall;

namespace Dal.Base.HardwareMall_Chinese
{
    public abstract class DalM_ProductRe: HardwareMallBase
    {
		
		public DalM_ProductRe():base()
        {

        }
        public DalM_ProductRe(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }
		
        /// <summary>
        /// 实例化一个当前数据操作对象
        /// </summary>
        /// <returns></returns>
        public static Dal.HardwareMall_Chinese.DalM_ProductRe Instance()
        {
            return  new Dal.HardwareMall_Chinese.DalM_ProductRe();
        } 

        /// <summary>
        /// 增加记录并且返回当前信息ID
        /// </summary>
        /// <param name="m_ProductRe">Model.HardwareMall_Chinese.ModM_ProductRe</param>
        /// <returns>成功返回当前插入ID，失败返回0</returns>
        public virtual int Add(Model.HardwareMall_Chinese.ModM_ProductRe model)
        {
             
            string sql = "insert into dbo.M_ProductRe ([Name],[CreateTime],[CreateBy],[Url],[Title],[LittleTitle],[Img])values(@Name,@CreateTime,@CreateBy,@Url,@Title,@LittleTitle,@Img);select SCOPE_IDENTITY() as InsertId";
            SqlParameter[] parameters = {

				new SqlParameter("@Name",SqlDbType.VarChar,255),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@CreateBy",SqlDbType.Int,4),
				new SqlParameter("@Url",SqlDbType.VarChar,255),
				new SqlParameter("@Title",SqlDbType.VarChar,255),
				new SqlParameter("@LittleTitle",SqlDbType.VarChar,255),
				new SqlParameter("@Img",SqlDbType.VarChar,255)		
	
            };
			
				parameters[0].Value = model.Name ;
				parameters[1].Value = model.CreateTime ;
				parameters[2].Value = model.CreateBy ;
				parameters[3].Value = model.Url ;
				parameters[4].Value = model.Title ;
				parameters[5].Value = model.LittleTitle ;
				parameters[6].Value = model.Img ;



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
        /// <param name="m_ProductRe">Model.HardwareMall_Chinese.ModM_ProductRe</param>
        /// <returns>成功返回True，错误返回False</returns>
        public virtual bool AddNoReturn(Model.HardwareMall_Chinese.ModM_ProductRe model)
        {
             
            string sql = "insert into dbo.M_ProductRe ([Name],[CreateTime],[CreateBy],[Url],[Title],[LittleTitle],[Img])values(@Name,@CreateTime,@CreateBy,@Url,@Title,@LittleTitle,@Img)";
            SqlParameter[] parameters = {

				new SqlParameter("@Name",SqlDbType.VarChar,255),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@CreateBy",SqlDbType.Int,4),
				new SqlParameter("@Url",SqlDbType.VarChar,255),
				new SqlParameter("@Title",SqlDbType.VarChar,255),
				new SqlParameter("@LittleTitle",SqlDbType.VarChar,255),
				new SqlParameter("@Img",SqlDbType.VarChar,255)			
	
            };
			
				parameters[0].Value = model.Name ;
				parameters[1].Value = model.CreateTime ;
				parameters[2].Value = model.CreateBy ;
				parameters[3].Value = model.Url ;
				parameters[4].Value = model.Title ;
				parameters[5].Value = model.LittleTitle ;
				parameters[6].Value = model.Img ;



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
        /// <param name="m_ProductRe">Model.HardwareMall_Chinese.ModM_ProductRe</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Model.HardwareMall_Chinese.ModM_ProductRe model)
        {
            
            string sql = @"update dbo.M_ProductRe set [Name] = @Name ,[CreateTime] = @CreateTime ,[CreateBy] = @CreateBy ,[Url] = @Url ,[Title] = @Title ,[LittleTitle] = @LittleTitle ,[Img] = @Img  where [Id]=@Id";
            SqlParameter[] parameters = {

				new SqlParameter("@Id",SqlDbType.Int,4),
				new SqlParameter("@Name",SqlDbType.VarChar,255),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@CreateBy",SqlDbType.Int,4),
				new SqlParameter("@Url",SqlDbType.VarChar,255),
				new SqlParameter("@Title",SqlDbType.VarChar,255),
				new SqlParameter("@LittleTitle",SqlDbType.VarChar,255),
				new SqlParameter("@Img",SqlDbType.VarChar,255)
	  	
	
            };
				parameters[0].Value = model.Id ;
				parameters[1].Value = model.Name ;
				parameters[2].Value = model.CreateTime ;
				parameters[3].Value = model.CreateBy ;
				parameters[4].Value = model.Url ;
				parameters[5].Value = model.Title ;
				parameters[6].Value = model.LittleTitle ;
				parameters[7].Value = model.Img ;


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
            string sql = "update dbo.M_ProductRe set ";
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
            string sql = string.Format("update dbo.M_ProductRe set {0} = @SetValue where [Id]=@Id", fieldName);
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
            
            string sql = @"delete from dbo.M_ProductRe where [Id]=@Id";
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
        public virtual Model.HardwareMall_Chinese.ModM_ProductRe GetModel(int id)
        {
            string sql = @"select * from dbo.M_ProductRe where [Id]=@Id";
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall_Chinese.ModM_ProductRe model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall_Chinese.ModM_ProductRe();
			
           				       if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}
           				       model.Name = reader["Name"].ToString();
           				       if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}
           				       if(reader["CreateBy"]!= System.DBNull.Value) {model.CreateBy = System.Int32.Parse(reader["CreateBy"].ToString());}
           				       model.Url = reader["Url"].ToString();
           				       model.Title = reader["Title"].ToString();
           				       model.LittleTitle = reader["LittleTitle"].ToString();
           				       model.Img = reader["Img"].ToString();
  		

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
        public virtual Model.HardwareMall_Chinese.ModM_ProductRe GetModel(int id,string cols)
        {
            cols = cols.ToLower();
            string sql = @"select "+cols+" from dbo.M_ProductRe where [Id]=@Id";
            cols = "," + cols + ","; 
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall_Chinese.ModM_ProductRe model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall_Chinese.ModM_ProductRe();
			
           				       if(cols.IndexOf(",Id,".ToLower())>=0){if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}}
           				       if(cols.IndexOf(",Name,".ToLower())>=0){model.Name = reader["Name"].ToString();}
           				       if(cols.IndexOf(",CreateTime,".ToLower())>=0){if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}}
           				       if(cols.IndexOf(",CreateBy,".ToLower())>=0){if(reader["CreateBy"]!= System.DBNull.Value) {model.CreateBy = System.Int32.Parse(reader["CreateBy"].ToString());}}
           				       if(cols.IndexOf(",Url,".ToLower())>=0){model.Url = reader["Url"].ToString();}
           				       if(cols.IndexOf(",Title,".ToLower())>=0){model.Title = reader["Title"].ToString();}
           				       if(cols.IndexOf(",LittleTitle,".ToLower())>=0){model.LittleTitle = reader["LittleTitle"].ToString();}
           				       if(cols.IndexOf(",Img,".ToLower())>=0){model.Img = reader["Img"].ToString();}
  		

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

            string sql = string.Format("select {3} {0} from dbo.M_ProductRe {1} {2}", col, where, orderby,selectTop);
            DataTable dt = this.ExecuteDataset(sql).Tables[0];
            return dt;

        }
		
		
		
    }
}
