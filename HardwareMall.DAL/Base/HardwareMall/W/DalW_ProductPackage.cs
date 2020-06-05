//------------------
//-- Create By lookchem 3.0
//-- File: Dal/Base/DalW_ProductPackage.cs
//-- 2020/5/6 16:03:11
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
    public abstract class DalW_ProductPackage: HardwareMallBase
    {
		
		public DalW_ProductPackage():base()
        {

        }
        public DalW_ProductPackage(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }
		
        /// <summary>
        /// 实例化一个当前数据操作对象
        /// </summary>
        /// <returns></returns>
        public static Dal.HardwareMall.DalW_ProductPackage Instance()
        {
            return  new Dal.HardwareMall.DalW_ProductPackage();
        } 

        /// <summary>
        /// 增加记录并且返回当前信息ID
        /// </summary>
        /// <param name="w_ProductPackage">Model.HardwareMall.ModW_ProductPackage</param>
        /// <returns>成功返回当前插入ID，失败返回0</returns>
        public virtual int Add(Model.HardwareMall.ModW_ProductPackage model)
        {
             
            string sql = "insert into dbo.W_ProductPackage ([ProductId],[PriceType],[Price],[Package],[CreateUser],[CreateTime],[UpdateTime],[UpdateUser],[Isdel],[Sort],[PNum],[FormatId])values(@ProductId,@PriceType,@Price,@Package,@CreateUser,@CreateTime,@UpdateTime,@UpdateUser,@Isdel,@Sort,@PNum,@FormatId);select SCOPE_IDENTITY() as InsertId";
            SqlParameter[] parameters = {

				new SqlParameter("@ProductId",SqlDbType.Int,4),
				new SqlParameter("@PriceType",SqlDbType.VarChar,10),
				new SqlParameter("@Price",SqlDbType.Decimal),
				new SqlParameter("@Package",SqlDbType.VarChar,255),
				new SqlParameter("@CreateUser",SqlDbType.Int,4),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateUser",SqlDbType.Int,4),
				new SqlParameter("@Isdel",SqlDbType.Bit,1),
				new SqlParameter("@Sort",SqlDbType.Int,4),
				new SqlParameter("@PNum",SqlDbType.Int,4),
				new SqlParameter("@FormatId",SqlDbType.Int,4)		
	
            };
			
				parameters[0].Value = model.ProductId ;
				parameters[1].Value = model.PriceType ;
				parameters[2].Value = model.Price ;
				parameters[3].Value = model.Package ;
				parameters[4].Value = model.CreateUser ;
				parameters[5].Value = model.CreateTime ;
				parameters[6].Value = model.UpdateTime ;
				parameters[7].Value = model.UpdateUser ;
				parameters[8].Value = model.Isdel ;
				parameters[9].Value = model.Sort ;
				parameters[10].Value = model.PNum ;
				parameters[11].Value = model.FormatId ;



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
        /// <param name="w_ProductPackage">Model.HardwareMall.ModW_ProductPackage</param>
        /// <returns>成功返回True，错误返回False</returns>
        public virtual bool AddNoReturn(Model.HardwareMall.ModW_ProductPackage model)
        {
             
            string sql = "insert into dbo.W_ProductPackage ([ProductId],[PriceType],[Price],[Package],[CreateUser],[CreateTime],[UpdateTime],[UpdateUser],[Isdel],[Sort],[PNum],[FormatId])values(@ProductId,@PriceType,@Price,@Package,@CreateUser,@CreateTime,@UpdateTime,@UpdateUser,@Isdel,@Sort,@PNum,@FormatId)";
            SqlParameter[] parameters = {

				new SqlParameter("@ProductId",SqlDbType.Int,4),
				new SqlParameter("@PriceType",SqlDbType.VarChar,10),
				new SqlParameter("@Price",SqlDbType.Decimal),
				new SqlParameter("@Package",SqlDbType.VarChar,255),
				new SqlParameter("@CreateUser",SqlDbType.Int,4),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateUser",SqlDbType.Int,4),
				new SqlParameter("@Isdel",SqlDbType.Bit,1),
				new SqlParameter("@Sort",SqlDbType.Int,4),
				new SqlParameter("@PNum",SqlDbType.Int,4),
				new SqlParameter("@FormatId",SqlDbType.Int,4)			
	
            };
			
				parameters[0].Value = model.ProductId ;
				parameters[1].Value = model.PriceType ;
				parameters[2].Value = model.Price ;
				parameters[3].Value = model.Package ;
				parameters[4].Value = model.CreateUser ;
				parameters[5].Value = model.CreateTime ;
				parameters[6].Value = model.UpdateTime ;
				parameters[7].Value = model.UpdateUser ;
				parameters[8].Value = model.Isdel ;
				parameters[9].Value = model.Sort ;
				parameters[10].Value = model.PNum ;
				parameters[11].Value = model.FormatId ;



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
        /// <param name="w_ProductPackage">Model.HardwareMall.ModW_ProductPackage</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Model.HardwareMall.ModW_ProductPackage model)
        {
            
            string sql = @"update dbo.W_ProductPackage set [ProductId] = @ProductId ,[PriceType] = @PriceType ,[Price] = @Price ,[Package] = @Package ,[CreateUser] = @CreateUser ,[CreateTime] = @CreateTime ,[UpdateTime] = @UpdateTime ,[UpdateUser] = @UpdateUser ,[Isdel] = @Isdel ,[Sort] = @Sort ,[PNum] = @PNum ,[FormatId] = @FormatId  where [Id]=@Id";
            SqlParameter[] parameters = {

				new SqlParameter("@Id",SqlDbType.Int,4),
				new SqlParameter("@ProductId",SqlDbType.Int,4),
				new SqlParameter("@PriceType",SqlDbType.VarChar,10),
				new SqlParameter("@Price",SqlDbType.Decimal),
				new SqlParameter("@Package",SqlDbType.VarChar,255),
				new SqlParameter("@CreateUser",SqlDbType.Int,4),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateUser",SqlDbType.Int,4),
				new SqlParameter("@Isdel",SqlDbType.Bit,1),
				new SqlParameter("@Sort",SqlDbType.Int,4),
				new SqlParameter("@PNum",SqlDbType.Int,4),
				new SqlParameter("@FormatId",SqlDbType.Int,4)
	  	
	
            };
				parameters[0].Value = model.Id ;
				parameters[1].Value = model.ProductId ;
				parameters[2].Value = model.PriceType ;
				parameters[3].Value = model.Price ;
				parameters[4].Value = model.Package ;
				parameters[5].Value = model.CreateUser ;
				parameters[6].Value = model.CreateTime ;
				parameters[7].Value = model.UpdateTime ;
				parameters[8].Value = model.UpdateUser ;
				parameters[9].Value = model.Isdel ;
				parameters[10].Value = model.Sort ;
				parameters[11].Value = model.PNum ;
				parameters[12].Value = model.FormatId ;


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
            string sql = "update dbo.W_ProductPackage set ";
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
            string sql = string.Format("update dbo.W_ProductPackage set {0} = @SetValue where [Id]=@Id", fieldName);
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
            
            string sql = @"delete from dbo.W_ProductPackage where [Id]=@Id";
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
        public virtual Model.HardwareMall.ModW_ProductPackage GetModel(int id)
        {
            string sql = @"select * from dbo.W_ProductPackage where [Id]=@Id";
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModW_ProductPackage model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModW_ProductPackage();
			
           				       if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}
           				       if(reader["ProductId"]!= System.DBNull.Value) {model.ProductId = System.Int32.Parse(reader["ProductId"].ToString());}
           				       model.PriceType = reader["PriceType"].ToString();
           				       if(reader["Price"]!= System.DBNull.Value) {model.Price = System.Decimal.Parse(reader["Price"].ToString());}
           				       model.Package = reader["Package"].ToString();
           				       if(reader["CreateUser"]!= System.DBNull.Value) {model.CreateUser = System.Int32.Parse(reader["CreateUser"].ToString());}
           				       if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}
           				       if(reader["UpdateTime"]!= System.DBNull.Value) {model.UpdateTime = System.DateTime.Parse(reader["UpdateTime"].ToString());}
           				       if(reader["UpdateUser"]!= System.DBNull.Value) {model.UpdateUser = System.Int32.Parse(reader["UpdateUser"].ToString());}
           				       if(reader["Isdel"]!= System.DBNull.Value) {model.Isdel = System.Boolean.Parse(reader["Isdel"].ToString());}
           				       if(reader["Sort"]!= System.DBNull.Value) {model.Sort = System.Int32.Parse(reader["Sort"].ToString());}
           				       if(reader["PNum"]!= System.DBNull.Value) {model.PNum = System.Int32.Parse(reader["PNum"].ToString());}
           				       if(reader["FormatId"]!= System.DBNull.Value) {model.FormatId = System.Int32.Parse(reader["FormatId"].ToString());}
  		

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
        public virtual Model.HardwareMall.ModW_ProductPackage GetModel(int id,string cols)
        {
            cols = cols.ToLower();
            string sql = @"select "+cols+" from dbo.W_ProductPackage where [Id]=@Id";
            cols = "," + cols + ","; 
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModW_ProductPackage model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModW_ProductPackage();
			
           				       if(cols.IndexOf(",Id,".ToLower())>=0){if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}}
           				       if(cols.IndexOf(",ProductId,".ToLower())>=0){if(reader["ProductId"]!= System.DBNull.Value) {model.ProductId = System.Int32.Parse(reader["ProductId"].ToString());}}
           				       if(cols.IndexOf(",PriceType,".ToLower())>=0){model.PriceType = reader["PriceType"].ToString();}
           				       if(cols.IndexOf(",Price,".ToLower())>=0){if(reader["Price"]!= System.DBNull.Value) {model.Price = System.Decimal.Parse(reader["Price"].ToString());}}
           				       if(cols.IndexOf(",Package,".ToLower())>=0){model.Package = reader["Package"].ToString();}
           				       if(cols.IndexOf(",CreateUser,".ToLower())>=0){if(reader["CreateUser"]!= System.DBNull.Value) {model.CreateUser = System.Int32.Parse(reader["CreateUser"].ToString());}}
           				       if(cols.IndexOf(",CreateTime,".ToLower())>=0){if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}}
           				       if(cols.IndexOf(",UpdateTime,".ToLower())>=0){if(reader["UpdateTime"]!= System.DBNull.Value) {model.UpdateTime = System.DateTime.Parse(reader["UpdateTime"].ToString());}}
           				       if(cols.IndexOf(",UpdateUser,".ToLower())>=0){if(reader["UpdateUser"]!= System.DBNull.Value) {model.UpdateUser = System.Int32.Parse(reader["UpdateUser"].ToString());}}
           				       if(cols.IndexOf(",Isdel,".ToLower())>=0){if(reader["Isdel"]!= System.DBNull.Value) {model.Isdel = System.Boolean.Parse(reader["Isdel"].ToString());}}
           				       if(cols.IndexOf(",Sort,".ToLower())>=0){if(reader["Sort"]!= System.DBNull.Value) {model.Sort = System.Int32.Parse(reader["Sort"].ToString());}}
           				       if(cols.IndexOf(",PNum,".ToLower())>=0){if(reader["PNum"]!= System.DBNull.Value) {model.PNum = System.Int32.Parse(reader["PNum"].ToString());}}
           				       if(cols.IndexOf(",FormatId,".ToLower())>=0){if(reader["FormatId"]!= System.DBNull.Value) {model.FormatId = System.Int32.Parse(reader["FormatId"].ToString());}}
  		

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

            string sql = string.Format("select {3} {0} from dbo.W_ProductPackage {1} {2}", col, where, orderby,selectTop);
            DataTable dt = this.ExecuteDataset(sql).Tables[0];
            return dt;

        }
		
		
		
    }
}
