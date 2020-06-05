//------------------
//-- Create By lookchem 3.0
//-- File: Dal/Base/DalM_HomeElement.cs
//-- 2020/3/18 16:34:17
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
    public abstract class DalM_HomeElement:HardwareMallBase
    {
		
		public DalM_HomeElement():base()
        {

        }
        public DalM_HomeElement(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }
		
        /// <summary>
        /// 实例化一个当前数据操作对象
        /// </summary>
        /// <returns></returns>
        public static Dal.HardwareMall.DalM_HomeElement Instance()
        {
            return  new Dal.HardwareMall.DalM_HomeElement();
        } 

        /// <summary>
        /// 增加记录并且返回当前信息ID
        /// </summary>
        /// <param name="m_HomeElement">Model.HardwareMall.ModM_HomeElement</param>
        /// <returns>成功返回当前插入ID，失败返回0</returns>
        public virtual int Add(Model.HardwareMall.ModM_HomeElement model)
        {
             
            string sql = "insert into dbo.M_HomeElement ([HomeTypeEnum],[Img],[Title],[LittleTitle],[CreateUser],[CreateTime],[UpdateUser],[UpdateTime],[Href],[Sort])values(@HomeTypeEnum,@Img,@Title,@LittleTitle,@CreateUser,@CreateTime,@UpdateUser,@UpdateTime,@Href,@Sort);select SCOPE_IDENTITY() as InsertId";
            SqlParameter[] parameters = {

				new SqlParameter("@HomeTypeEnum",SqlDbType.Int,4),
				new SqlParameter("@Img",SqlDbType.VarChar,-1),
				new SqlParameter("@Title",SqlDbType.VarChar,255),
				new SqlParameter("@LittleTitle",SqlDbType.VarChar,255),
				new SqlParameter("@CreateUser",SqlDbType.Int,4),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateUser",SqlDbType.Int,4),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime),
				new SqlParameter("@Href",SqlDbType.VarChar,-1),
				new SqlParameter("@Sort",SqlDbType.Int,4)		
	
            };
			
				parameters[0].Value = model.HomeTypeEnum ;
				parameters[1].Value = model.Img ;
				parameters[2].Value = model.Title ;
				parameters[3].Value = model.LittleTitle ;
				parameters[4].Value = model.CreateUser ;
				parameters[5].Value = model.CreateTime ;
				parameters[6].Value = model.UpdateUser ;
				parameters[7].Value = model.UpdateTime ;
				parameters[8].Value = model.Href ;
				parameters[9].Value = model.Sort ;



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
        /// <param name="m_HomeElement">Model.HardwareMall.ModM_HomeElement</param>
        /// <returns>成功返回True，错误返回False</returns>
        public virtual bool AddNoReturn(Model.HardwareMall.ModM_HomeElement model)
        {
             
            string sql = "insert into dbo.M_HomeElement ([HomeTypeEnum],[Img],[Title],[LittleTitle],[CreateUser],[CreateTime],[UpdateUser],[UpdateTime],[Href],[Sort])values(@HomeTypeEnum,@Img,@Title,@LittleTitle,@CreateUser,@CreateTime,@UpdateUser,@UpdateTime,@Href,@Sort)";
            SqlParameter[] parameters = {

				new SqlParameter("@HomeTypeEnum",SqlDbType.Int,4),
				new SqlParameter("@Img",SqlDbType.VarChar,-1),
				new SqlParameter("@Title",SqlDbType.VarChar,255),
				new SqlParameter("@LittleTitle",SqlDbType.VarChar,255),
				new SqlParameter("@CreateUser",SqlDbType.Int,4),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateUser",SqlDbType.Int,4),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime),
				new SqlParameter("@Href",SqlDbType.VarChar,-1),
				new SqlParameter("@Sort",SqlDbType.Int,4)			
	
            };
			
				parameters[0].Value = model.HomeTypeEnum ;
				parameters[1].Value = model.Img ;
				parameters[2].Value = model.Title ;
				parameters[3].Value = model.LittleTitle ;
				parameters[4].Value = model.CreateUser ;
				parameters[5].Value = model.CreateTime ;
				parameters[6].Value = model.UpdateUser ;
				parameters[7].Value = model.UpdateTime ;
				parameters[8].Value = model.Href ;
				parameters[9].Value = model.Sort ;



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
        /// <param name="m_HomeElement">Model.HardwareMall.ModM_HomeElement</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Model.HardwareMall.ModM_HomeElement model)
        {
            
            string sql = @"update dbo.M_HomeElement set [HomeTypeEnum] = @HomeTypeEnum ,[Img] = @Img ,[Title] = @Title ,[LittleTitle] = @LittleTitle ,[CreateUser] = @CreateUser ,[CreateTime] = @CreateTime ,[UpdateUser] = @UpdateUser ,[UpdateTime] = @UpdateTime ,[Href] = @Href ,[Sort] = @Sort  where [Id]=@Id";
            SqlParameter[] parameters = {

				new SqlParameter("@Id",SqlDbType.Int,4),
				new SqlParameter("@HomeTypeEnum",SqlDbType.Int,4),
				new SqlParameter("@Img",SqlDbType.VarChar,-1),
				new SqlParameter("@Title",SqlDbType.VarChar,255),
				new SqlParameter("@LittleTitle",SqlDbType.VarChar,255),
				new SqlParameter("@CreateUser",SqlDbType.Int,4),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateUser",SqlDbType.Int,4),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime),
				new SqlParameter("@Href",SqlDbType.VarChar,-1),
				new SqlParameter("@Sort",SqlDbType.Int,4)
	  	
	
            };
				parameters[0].Value = model.Id ;
				parameters[1].Value = model.HomeTypeEnum ;
				parameters[2].Value = model.Img ;
				parameters[3].Value = model.Title ;
				parameters[4].Value = model.LittleTitle ;
				parameters[5].Value = model.CreateUser ;
				parameters[6].Value = model.CreateTime ;
				parameters[7].Value = model.UpdateUser ;
				parameters[8].Value = model.UpdateTime ;
				parameters[9].Value = model.Href ;
				parameters[10].Value = model.Sort ;


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
            string sql = "update dbo.M_HomeElement set ";
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
            string sql = string.Format("update dbo.M_HomeElement set {0} = @SetValue where [Id]=@Id", fieldName);
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
            
            string sql = @"delete from dbo.M_HomeElement where [Id]=@Id";
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
        public virtual Model.HardwareMall.ModM_HomeElement GetModel(int id)
        {
            string sql = @"select * from dbo.M_HomeElement where [Id]=@Id";
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModM_HomeElement model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModM_HomeElement();
			
           				       if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}
           				       if(reader["HomeTypeEnum"]!= System.DBNull.Value) {model.HomeTypeEnum = System.Int32.Parse(reader["HomeTypeEnum"].ToString());}
           				       model.Img = reader["Img"].ToString();
           				       model.Title = reader["Title"].ToString();
           				       model.LittleTitle = reader["LittleTitle"].ToString();
           				       if(reader["CreateUser"]!= System.DBNull.Value) {model.CreateUser = System.Int32.Parse(reader["CreateUser"].ToString());}
           				       if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}
           				       if(reader["UpdateUser"]!= System.DBNull.Value) {model.UpdateUser = System.Int32.Parse(reader["UpdateUser"].ToString());}
           				       if(reader["UpdateTime"]!= System.DBNull.Value) {model.UpdateTime = System.DateTime.Parse(reader["UpdateTime"].ToString());}
           				       model.Href = reader["Href"].ToString();
           				       if(reader["Sort"]!= System.DBNull.Value) {model.Sort = System.Int32.Parse(reader["Sort"].ToString());}
  		

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
        public virtual Model.HardwareMall.ModM_HomeElement GetModel(int id,string cols)
        {
            cols = cols.ToLower();
            string sql = @"select "+cols+" from dbo.M_HomeElement where [Id]=@Id";
            cols = "," + cols + ","; 
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModM_HomeElement model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModM_HomeElement();
			
           				       if(cols.IndexOf(",Id,".ToLower())>=0){if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}}
           				       if(cols.IndexOf(",HomeTypeEnum,".ToLower())>=0){if(reader["HomeTypeEnum"]!= System.DBNull.Value) {model.HomeTypeEnum = System.Int32.Parse(reader["HomeTypeEnum"].ToString());}}
           				       if(cols.IndexOf(",Img,".ToLower())>=0){model.Img = reader["Img"].ToString();}
           				       if(cols.IndexOf(",Title,".ToLower())>=0){model.Title = reader["Title"].ToString();}
           				       if(cols.IndexOf(",LittleTitle,".ToLower())>=0){model.LittleTitle = reader["LittleTitle"].ToString();}
           				       if(cols.IndexOf(",CreateUser,".ToLower())>=0){if(reader["CreateUser"]!= System.DBNull.Value) {model.CreateUser = System.Int32.Parse(reader["CreateUser"].ToString());}}
           				       if(cols.IndexOf(",CreateTime,".ToLower())>=0){if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}}
           				       if(cols.IndexOf(",UpdateUser,".ToLower())>=0){if(reader["UpdateUser"]!= System.DBNull.Value) {model.UpdateUser = System.Int32.Parse(reader["UpdateUser"].ToString());}}
           				       if(cols.IndexOf(",UpdateTime,".ToLower())>=0){if(reader["UpdateTime"]!= System.DBNull.Value) {model.UpdateTime = System.DateTime.Parse(reader["UpdateTime"].ToString());}}
           				       if(cols.IndexOf(",Href,".ToLower())>=0){model.Href = reader["Href"].ToString();}
           				       if(cols.IndexOf(",Sort,".ToLower())>=0){if(reader["Sort"]!= System.DBNull.Value) {model.Sort = System.Int32.Parse(reader["Sort"].ToString());}}
  		

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

            string sql = string.Format("select {3} {0} from dbo.M_HomeElement {1} {2}", col, where, orderby,selectTop);
            DataTable dt = this.ExecuteDataset(sql).Tables[0];
            return dt;

        }
		
		
		
    }
}
