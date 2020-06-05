//------------------
//-- Create By lookchem 3.0
//-- File: Dal/Base/DalM_ManageUser.cs
//-- 2020/3/12 18:55:34
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
    public abstract class DalM_ManageUser:HardwareMallBase
    {
		
		public DalM_ManageUser():base()
        {

        }
        public DalM_ManageUser(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }
		
        /// <summary>
        /// 实例化一个当前数据操作对象
        /// </summary>
        /// <returns></returns>
        public static Dal.HardwareMall.DalM_ManageUser Instance()
        {
            return  new Dal.HardwareMall.DalM_ManageUser();
        } 

        /// <summary>
        /// 增加记录并且返回当前信息ID
        /// </summary>
        /// <param name="m_ManageUser">Model.HardwareMall.ModM_ManageUser</param>
        /// <returns>成功返回当前插入ID，失败返回0</returns>
        public virtual int Add(Model.HardwareMall.ModM_ManageUser model)
        {
             
            string sql = "insert into dbo.M_ManageUser ([UserName],[RealName],[Password],[CreateTime],[Status],[Isdel])values(@UserName,@RealName,@Password,@CreateTime,@Status,@Isdel);select SCOPE_IDENTITY() as InsertId";
            SqlParameter[] parameters = {

				new SqlParameter("@UserName",SqlDbType.VarChar,64),
				new SqlParameter("@RealName",SqlDbType.VarChar,64),
				new SqlParameter("@Password",SqlDbType.VarChar,64),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@Status",SqlDbType.Int,4),
				new SqlParameter("@Isdel",SqlDbType.Bit,1)		
	
            };
			
				parameters[0].Value = model.UserName ;
				parameters[1].Value = model.RealName ;
				parameters[2].Value = model.Password ;
				parameters[3].Value = model.CreateTime ;
				parameters[4].Value = model.Status ;
				parameters[5].Value = model.Isdel ;



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
        /// <param name="m_ManageUser">Model.HardwareMall.ModM_ManageUser</param>
        /// <returns>成功返回True，错误返回False</returns>
        public virtual bool AddNoReturn(Model.HardwareMall.ModM_ManageUser model)
        {
             
            string sql = "insert into dbo.M_ManageUser ([UserName],[RealName],[Password],[CreateTime],[Status],[Isdel])values(@UserName,@RealName,@Password,@CreateTime,@Status,@Isdel)";
            SqlParameter[] parameters = {

				new SqlParameter("@UserName",SqlDbType.VarChar,64),
				new SqlParameter("@RealName",SqlDbType.VarChar,64),
				new SqlParameter("@Password",SqlDbType.VarChar,64),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@Status",SqlDbType.Int,4),
				new SqlParameter("@Isdel",SqlDbType.Bit,1)			
	
            };
			
				parameters[0].Value = model.UserName ;
				parameters[1].Value = model.RealName ;
				parameters[2].Value = model.Password ;
				parameters[3].Value = model.CreateTime ;
				parameters[4].Value = model.Status ;
				parameters[5].Value = model.Isdel ;



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
        /// <param name="m_ManageUser">Model.HardwareMall.ModM_ManageUser</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Model.HardwareMall.ModM_ManageUser model)
        {
            
            string sql = @"update dbo.M_ManageUser set [UserName] = @UserName ,[RealName] = @RealName ,[Password] = @Password ,[CreateTime] = @CreateTime ,[Status] = @Status ,[Isdel] = @Isdel  where [Id]=@Id";
            SqlParameter[] parameters = {

				new SqlParameter("@Id",SqlDbType.Int,4),
				new SqlParameter("@UserName",SqlDbType.VarChar,64),
				new SqlParameter("@RealName",SqlDbType.VarChar,64),
				new SqlParameter("@Password",SqlDbType.VarChar,64),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@Status",SqlDbType.Int,4),
				new SqlParameter("@Isdel",SqlDbType.Bit,1)
	  	
	
            };
				parameters[0].Value = model.Id ;
				parameters[1].Value = model.UserName ;
				parameters[2].Value = model.RealName ;
				parameters[3].Value = model.Password ;
				parameters[4].Value = model.CreateTime ;
				parameters[5].Value = model.Status ;
				parameters[6].Value = model.Isdel ;


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
            string sql = "update dbo.M_ManageUser set ";
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
            string sql = string.Format("update dbo.M_ManageUser set {0} = @SetValue where [Id]=@Id", fieldName);
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
            
            string sql = @"delete from dbo.M_ManageUser where [Id]=@Id";
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
        public virtual Model.HardwareMall.ModM_ManageUser GetModel(int id)
        {
            string sql = @"select * from dbo.M_ManageUser where [Id]=@Id";
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModM_ManageUser model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModM_ManageUser();
			
           				       if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}
           				       model.UserName = reader["UserName"].ToString();
           				       model.RealName = reader["RealName"].ToString();
           				       model.Password = reader["Password"].ToString();
           				       if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}
           				       if(reader["Status"]!= System.DBNull.Value) {model.Status = System.Int32.Parse(reader["Status"].ToString());}
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
        public virtual Model.HardwareMall.ModM_ManageUser GetModel(int id,string cols)
        {
            cols = cols.ToLower();
            string sql = @"select "+cols+" from dbo.M_ManageUser where [Id]=@Id";
            cols = "," + cols + ","; 
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModM_ManageUser model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModM_ManageUser();
			
           				       if(cols.IndexOf(",Id,".ToLower())>=0){if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}}
           				       if(cols.IndexOf(",UserName,".ToLower())>=0){model.UserName = reader["UserName"].ToString();}
           				       if(cols.IndexOf(",RealName,".ToLower())>=0){model.RealName = reader["RealName"].ToString();}
           				       if(cols.IndexOf(",Password,".ToLower())>=0){model.Password = reader["Password"].ToString();}
           				       if(cols.IndexOf(",CreateTime,".ToLower())>=0){if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}}
           				       if(cols.IndexOf(",Status,".ToLower())>=0){if(reader["Status"]!= System.DBNull.Value) {model.Status = System.Int32.Parse(reader["Status"].ToString());}}
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

            string sql = string.Format("select {3} {0} from dbo.M_ManageUser {1} {2}", col, where, orderby,selectTop);
            DataTable dt = this.ExecuteDataset(sql).Tables[0];
            return dt;

        }
		
		
		
    }
}
