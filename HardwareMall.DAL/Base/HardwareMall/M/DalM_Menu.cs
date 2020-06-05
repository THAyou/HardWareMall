//------------------
//-- Create By lookchem 3.0
//-- File: Dal/Base/DalM_Menu.cs
//-- 2020/3/20 15:46:58
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
    public abstract class DalM_Menu:HardwareMallBase
    {
		
		public DalM_Menu():base()
        {

        }
        public DalM_Menu(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }
		
        /// <summary>
        /// 实例化一个当前数据操作对象
        /// </summary>
        /// <returns></returns>
        public static Dal.HardwareMall.DalM_Menu Instance()
        {
            return  new Dal.HardwareMall.DalM_Menu();
        } 

        /// <summary>
        /// 增加记录并且返回当前信息ID
        /// </summary>
        /// <param name="m_Menu">Model.HardwareMall.ModM_Menu</param>
        /// <returns>成功返回当前插入ID，失败返回0</returns>
        public virtual int Add(Model.HardwareMall.ModM_Menu model)
        {
             
            string sql = "insert into dbo.M_Menu ([MenuName],[MenuUrl],[ParentId],[Sort],[Isdel],[StyleClass])values(@MenuName,@MenuUrl,@ParentId,@Sort,@Isdel,@StyleClass);select SCOPE_IDENTITY() as InsertId";
            SqlParameter[] parameters = {

				new SqlParameter("@MenuName",SqlDbType.VarChar,255),
				new SqlParameter("@MenuUrl",SqlDbType.VarChar,255),
				new SqlParameter("@ParentId",SqlDbType.Int,4),
				new SqlParameter("@Sort",SqlDbType.Int,4),
				new SqlParameter("@Isdel",SqlDbType.Bit,1),
				new SqlParameter("@StyleClass",SqlDbType.VarChar,255)		
	
            };
			
				parameters[0].Value = model.MenuName ;
				parameters[1].Value = model.MenuUrl ;
				parameters[2].Value = model.ParentId ;
				parameters[3].Value = model.Sort ;
				parameters[4].Value = model.Isdel ;
				parameters[5].Value = model.StyleClass ;



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
        /// <param name="m_Menu">Model.HardwareMall.ModM_Menu</param>
        /// <returns>成功返回True，错误返回False</returns>
        public virtual bool AddNoReturn(Model.HardwareMall.ModM_Menu model)
        {
             
            string sql = "insert into dbo.M_Menu ([MenuName],[MenuUrl],[ParentId],[Sort],[Isdel],[StyleClass])values(@MenuName,@MenuUrl,@ParentId,@Sort,@Isdel,@StyleClass)";
            SqlParameter[] parameters = {

				new SqlParameter("@MenuName",SqlDbType.VarChar,255),
				new SqlParameter("@MenuUrl",SqlDbType.VarChar,255),
				new SqlParameter("@ParentId",SqlDbType.Int,4),
				new SqlParameter("@Sort",SqlDbType.Int,4),
				new SqlParameter("@Isdel",SqlDbType.Bit,1),
				new SqlParameter("@StyleClass",SqlDbType.VarChar,255)			
	
            };
			
				parameters[0].Value = model.MenuName ;
				parameters[1].Value = model.MenuUrl ;
				parameters[2].Value = model.ParentId ;
				parameters[3].Value = model.Sort ;
				parameters[4].Value = model.Isdel ;
				parameters[5].Value = model.StyleClass ;



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
        /// <param name="m_Menu">Model.HardwareMall.ModM_Menu</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Model.HardwareMall.ModM_Menu model)
        {
            
            string sql = @"update dbo.M_Menu set [MenuName] = @MenuName ,[MenuUrl] = @MenuUrl ,[ParentId] = @ParentId ,[Sort] = @Sort ,[Isdel] = @Isdel ,[StyleClass] = @StyleClass  where [Id]=@Id";
            SqlParameter[] parameters = {

				new SqlParameter("@Id",SqlDbType.Int,4),
				new SqlParameter("@MenuName",SqlDbType.VarChar,255),
				new SqlParameter("@MenuUrl",SqlDbType.VarChar,255),
				new SqlParameter("@ParentId",SqlDbType.Int,4),
				new SqlParameter("@Sort",SqlDbType.Int,4),
				new SqlParameter("@Isdel",SqlDbType.Bit,1),
				new SqlParameter("@StyleClass",SqlDbType.VarChar,255)
	  	
	
            };
				parameters[0].Value = model.Id ;
				parameters[1].Value = model.MenuName ;
				parameters[2].Value = model.MenuUrl ;
				parameters[3].Value = model.ParentId ;
				parameters[4].Value = model.Sort ;
				parameters[5].Value = model.Isdel ;
				parameters[6].Value = model.StyleClass ;


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
            string sql = "update dbo.M_Menu set ";
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
            string sql = string.Format("update dbo.M_Menu set {0} = @SetValue where [Id]=@Id", fieldName);
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
            
            string sql = @"delete from dbo.M_Menu where [Id]=@Id";
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
        public virtual Model.HardwareMall.ModM_Menu GetModel(int id)
        {
            string sql = @"select * from dbo.M_Menu where [Id]=@Id";
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModM_Menu model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModM_Menu();
			
           				       if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}
           				       model.MenuName = reader["MenuName"].ToString();
           				       model.MenuUrl = reader["MenuUrl"].ToString();
           				       if(reader["ParentId"]!= System.DBNull.Value) {model.ParentId = System.Int32.Parse(reader["ParentId"].ToString());}
           				       if(reader["Sort"]!= System.DBNull.Value) {model.Sort = System.Int32.Parse(reader["Sort"].ToString());}
           				       if(reader["Isdel"]!= System.DBNull.Value) {model.Isdel = System.Boolean.Parse(reader["Isdel"].ToString());}
           				       model.StyleClass = reader["StyleClass"].ToString();
  		

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
        public virtual Model.HardwareMall.ModM_Menu GetModel(int id,string cols)
        {
            cols = cols.ToLower();
            string sql = @"select "+cols+" from dbo.M_Menu where [Id]=@Id";
            cols = "," + cols + ","; 
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModM_Menu model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModM_Menu();
			
           				       if(cols.IndexOf(",Id,".ToLower())>=0){if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}}
           				       if(cols.IndexOf(",MenuName,".ToLower())>=0){model.MenuName = reader["MenuName"].ToString();}
           				       if(cols.IndexOf(",MenuUrl,".ToLower())>=0){model.MenuUrl = reader["MenuUrl"].ToString();}
           				       if(cols.IndexOf(",ParentId,".ToLower())>=0){if(reader["ParentId"]!= System.DBNull.Value) {model.ParentId = System.Int32.Parse(reader["ParentId"].ToString());}}
           				       if(cols.IndexOf(",Sort,".ToLower())>=0){if(reader["Sort"]!= System.DBNull.Value) {model.Sort = System.Int32.Parse(reader["Sort"].ToString());}}
           				       if(cols.IndexOf(",Isdel,".ToLower())>=0){if(reader["Isdel"]!= System.DBNull.Value) {model.Isdel = System.Boolean.Parse(reader["Isdel"].ToString());}}
           				       if(cols.IndexOf(",StyleClass,".ToLower())>=0){model.StyleClass = reader["StyleClass"].ToString();}
  		

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

            string sql = string.Format("select {3} {0} from dbo.M_Menu {1} {2}", col, where, orderby,selectTop);
            DataTable dt = this.ExecuteDataset(sql).Tables[0];
            return dt;

        }
		
		
		
    }
}
