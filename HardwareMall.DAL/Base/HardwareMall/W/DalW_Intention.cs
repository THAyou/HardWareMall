//------------------
//-- Create By lookchem 3.0
//-- File: Dal/Base/DalW_Intention.cs
//-- 2020/5/8 16:32:13
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
    public abstract class DalW_Intention:HardwareMallBase
    {
		
		public DalW_Intention():base()
        {

        }
        public DalW_Intention(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }
		
        /// <summary>
        /// 实例化一个当前数据操作对象
        /// </summary>
        /// <returns></returns>
        public static Dal.HardwareMall.DalW_Intention Instance()
        {
            return  new Dal.HardwareMall.DalW_Intention();
        } 

        /// <summary>
        /// 增加记录并且返回当前信息ID
        /// </summary>
        /// <param name="w_Intention">Model.HardwareMall.ModW_Intention</param>
        /// <returns>成功返回当前插入ID，失败返回0</returns>
        public virtual int Add(Model.HardwareMall.ModW_Intention model)
        {
             
            string sql = "insert into dbo.W_Intention ([Name],[ContactDetails],[Remark],[CreateTime],[ProcessStatus],[ProcessRemark],[ProcessTime])values(@Name,@ContactDetails,@Remark,@CreateTime,@ProcessStatus,@ProcessRemark,@ProcessTime);select SCOPE_IDENTITY() as InsertId";
            SqlParameter[] parameters = {

				new SqlParameter("@Name",SqlDbType.VarChar,255),
				new SqlParameter("@ContactDetails",SqlDbType.VarChar,-1),
				new SqlParameter("@Remark",SqlDbType.VarChar,-1),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@ProcessStatus",SqlDbType.TinyInt,1),
				new SqlParameter("@ProcessRemark",SqlDbType.VarChar,-1),
				new SqlParameter("@ProcessTime",SqlDbType.DateTime)		
	
            };
			
				parameters[0].Value = model.Name ;
				parameters[1].Value = model.ContactDetails ;
				parameters[2].Value = model.Remark ;
				parameters[3].Value = model.CreateTime ;
				parameters[4].Value = model.ProcessStatus ;
				parameters[5].Value = model.ProcessRemark ;
				parameters[6].Value = model.ProcessTime ;



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
        /// <param name="w_Intention">Model.HardwareMall.ModW_Intention</param>
        /// <returns>成功返回True，错误返回False</returns>
        public virtual bool AddNoReturn(Model.HardwareMall.ModW_Intention model)
        {
             
            string sql = "insert into dbo.W_Intention ([Name],[ContactDetails],[Remark],[CreateTime],[ProcessStatus],[ProcessRemark],[ProcessTime])values(@Name,@ContactDetails,@Remark,@CreateTime,@ProcessStatus,@ProcessRemark,@ProcessTime)";
            SqlParameter[] parameters = {

				new SqlParameter("@Name",SqlDbType.VarChar,255),
				new SqlParameter("@ContactDetails",SqlDbType.VarChar,-1),
				new SqlParameter("@Remark",SqlDbType.VarChar,-1),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@ProcessStatus",SqlDbType.TinyInt,1),
				new SqlParameter("@ProcessRemark",SqlDbType.VarChar,-1),
				new SqlParameter("@ProcessTime",SqlDbType.DateTime)			
	
            };
			
				parameters[0].Value = model.Name ;
				parameters[1].Value = model.ContactDetails ;
				parameters[2].Value = model.Remark ;
				parameters[3].Value = model.CreateTime ;
				parameters[4].Value = model.ProcessStatus ;
				parameters[5].Value = model.ProcessRemark ;
				parameters[6].Value = model.ProcessTime ;



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
        /// <param name="w_Intention">Model.HardwareMall.ModW_Intention</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Model.HardwareMall.ModW_Intention model)
        {
            
            string sql = @"update dbo.W_Intention set [Name] = @Name ,[ContactDetails] = @ContactDetails ,[Remark] = @Remark ,[CreateTime] = @CreateTime ,[ProcessStatus] = @ProcessStatus ,[ProcessRemark] = @ProcessRemark ,[ProcessTime] = @ProcessTime  where [Id]=@Id";
            SqlParameter[] parameters = {

				new SqlParameter("@Id",SqlDbType.Int,4),
				new SqlParameter("@Name",SqlDbType.VarChar,255),
				new SqlParameter("@ContactDetails",SqlDbType.VarChar,-1),
				new SqlParameter("@Remark",SqlDbType.VarChar,-1),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@ProcessStatus",SqlDbType.TinyInt,1),
				new SqlParameter("@ProcessRemark",SqlDbType.VarChar,-1),
				new SqlParameter("@ProcessTime",SqlDbType.DateTime)
	  	
	
            };
				parameters[0].Value = model.Id ;
				parameters[1].Value = model.Name ;
				parameters[2].Value = model.ContactDetails ;
				parameters[3].Value = model.Remark ;
				parameters[4].Value = model.CreateTime ;
				parameters[5].Value = model.ProcessStatus ;
				parameters[6].Value = model.ProcessRemark ;
				parameters[7].Value = model.ProcessTime ;


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
            string sql = "update dbo.W_Intention set ";
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
            string sql = string.Format("update dbo.W_Intention set {0} = @SetValue where [Id]=@Id", fieldName);
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
            
            string sql = @"delete from dbo.W_Intention where [Id]=@Id";
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
        public virtual Model.HardwareMall.ModW_Intention GetModel(int id)
        {
            string sql = @"select * from dbo.W_Intention where [Id]=@Id";
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModW_Intention model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModW_Intention();
			
           				       if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}
           				       model.Name = reader["Name"].ToString();
           				       model.ContactDetails = reader["ContactDetails"].ToString();
           				       model.Remark = reader["Remark"].ToString();
           				       if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}
           				       if(reader["ProcessStatus"]!= System.DBNull.Value) {model.ProcessStatus = System.Byte.Parse(reader["ProcessStatus"].ToString());}
           				       model.ProcessRemark = reader["ProcessRemark"].ToString();
           				       if(reader["ProcessTime"]!= System.DBNull.Value) {model.ProcessTime = System.DateTime.Parse(reader["ProcessTime"].ToString());}
  		

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
        public virtual Model.HardwareMall.ModW_Intention GetModel(int id,string cols)
        {
            cols = cols.ToLower();
            string sql = @"select "+cols+" from dbo.W_Intention where [Id]=@Id";
            cols = "," + cols + ","; 
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModW_Intention model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModW_Intention();
			
           				       if(cols.IndexOf(",Id,".ToLower())>=0){if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}}
           				       if(cols.IndexOf(",Name,".ToLower())>=0){model.Name = reader["Name"].ToString();}
           				       if(cols.IndexOf(",ContactDetails,".ToLower())>=0){model.ContactDetails = reader["ContactDetails"].ToString();}
           				       if(cols.IndexOf(",Remark,".ToLower())>=0){model.Remark = reader["Remark"].ToString();}
           				       if(cols.IndexOf(",CreateTime,".ToLower())>=0){if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}}
           				       if(cols.IndexOf(",ProcessStatus,".ToLower())>=0){if(reader["ProcessStatus"]!= System.DBNull.Value) {model.ProcessStatus = System.Byte.Parse(reader["ProcessStatus"].ToString());}}
           				       if(cols.IndexOf(",ProcessRemark,".ToLower())>=0){model.ProcessRemark = reader["ProcessRemark"].ToString();}
           				       if(cols.IndexOf(",ProcessTime,".ToLower())>=0){if(reader["ProcessTime"]!= System.DBNull.Value) {model.ProcessTime = System.DateTime.Parse(reader["ProcessTime"].ToString());}}
  		

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

            string sql = string.Format("select {3} {0} from dbo.W_Intention {1} {2}", col, where, orderby,selectTop);
            DataTable dt = this.ExecuteDataset(sql).Tables[0];
            return dt;

        }
		
		
		
    }
}
