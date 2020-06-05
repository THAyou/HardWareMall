//------------------
//-- Create By lookchem 3.0
//-- File: Dal/Base/DalW_OrderDetails.cs
//-- 2020/5/7 15:12:39
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
    public abstract class DalW_OrderDetails:HardwareMallBase
    {
		
		public DalW_OrderDetails():base()
        {

        }
        public DalW_OrderDetails(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }
		
        /// <summary>
        /// 实例化一个当前数据操作对象
        /// </summary>
        /// <returns></returns>
        public static Dal.HardwareMall.DalW_OrderDetails Instance()
        {
            return  new Dal.HardwareMall.DalW_OrderDetails();
        } 

        /// <summary>
        /// 增加记录并且返回当前信息ID
        /// </summary>
        /// <param name="w_OrderDetails">Model.HardwareMall.ModW_OrderDetails</param>
        /// <returns>成功返回当前插入ID，失败返回0</returns>
        public virtual int Add(Model.HardwareMall.ModW_OrderDetails model)
        {
             
            string sql = "insert into dbo.W_OrderDetails ([OrderId],[ProductId],[FormatId],[PackageId],[Quantity],[Amount],[CreateTime],[AmountType])values(@OrderId,@ProductId,@FormatId,@PackageId,@Quantity,@Amount,@CreateTime,@AmountType);select SCOPE_IDENTITY() as InsertId";
            SqlParameter[] parameters = {

				new SqlParameter("@OrderId",SqlDbType.Int,4),
				new SqlParameter("@ProductId",SqlDbType.Int,4),
				new SqlParameter("@FormatId",SqlDbType.Int,4),
				new SqlParameter("@PackageId",SqlDbType.Int,4),
				new SqlParameter("@Quantity",SqlDbType.Int,4),
				new SqlParameter("@Amount",SqlDbType.Decimal),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@AmountType",SqlDbType.VarChar,64)		
	
            };
			
				parameters[0].Value = model.OrderId ;
				parameters[1].Value = model.ProductId ;
				parameters[2].Value = model.FormatId ;
				parameters[3].Value = model.PackageId ;
				parameters[4].Value = model.Quantity ;
				parameters[5].Value = model.Amount ;
				parameters[6].Value = model.CreateTime ;
				parameters[7].Value = model.AmountType ;



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
        /// <param name="w_OrderDetails">Model.HardwareMall.ModW_OrderDetails</param>
        /// <returns>成功返回True，错误返回False</returns>
        public virtual bool AddNoReturn(Model.HardwareMall.ModW_OrderDetails model)
        {
             
            string sql = "insert into dbo.W_OrderDetails ([OrderId],[ProductId],[FormatId],[PackageId],[Quantity],[Amount],[CreateTime],[AmountType])values(@OrderId,@ProductId,@FormatId,@PackageId,@Quantity,@Amount,@CreateTime,@AmountType)";
            SqlParameter[] parameters = {

				new SqlParameter("@OrderId",SqlDbType.Int,4),
				new SqlParameter("@ProductId",SqlDbType.Int,4),
				new SqlParameter("@FormatId",SqlDbType.Int,4),
				new SqlParameter("@PackageId",SqlDbType.Int,4),
				new SqlParameter("@Quantity",SqlDbType.Int,4),
				new SqlParameter("@Amount",SqlDbType.Decimal),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@AmountType",SqlDbType.VarChar,64)			
	
            };
			
				parameters[0].Value = model.OrderId ;
				parameters[1].Value = model.ProductId ;
				parameters[2].Value = model.FormatId ;
				parameters[3].Value = model.PackageId ;
				parameters[4].Value = model.Quantity ;
				parameters[5].Value = model.Amount ;
				parameters[6].Value = model.CreateTime ;
				parameters[7].Value = model.AmountType ;



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
        /// <param name="w_OrderDetails">Model.HardwareMall.ModW_OrderDetails</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Model.HardwareMall.ModW_OrderDetails model)
        {
            
            string sql = @"update dbo.W_OrderDetails set [OrderId] = @OrderId ,[ProductId] = @ProductId ,[FormatId] = @FormatId ,[PackageId] = @PackageId ,[Quantity] = @Quantity ,[Amount] = @Amount ,[CreateTime] = @CreateTime ,[AmountType] = @AmountType  where [Id]=@Id";
            SqlParameter[] parameters = {

				new SqlParameter("@Id",SqlDbType.Int,4),
				new SqlParameter("@OrderId",SqlDbType.Int,4),
				new SqlParameter("@ProductId",SqlDbType.Int,4),
				new SqlParameter("@FormatId",SqlDbType.Int,4),
				new SqlParameter("@PackageId",SqlDbType.Int,4),
				new SqlParameter("@Quantity",SqlDbType.Int,4),
				new SqlParameter("@Amount",SqlDbType.Decimal),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@AmountType",SqlDbType.VarChar,64)
	  	
	
            };
				parameters[0].Value = model.Id ;
				parameters[1].Value = model.OrderId ;
				parameters[2].Value = model.ProductId ;
				parameters[3].Value = model.FormatId ;
				parameters[4].Value = model.PackageId ;
				parameters[5].Value = model.Quantity ;
				parameters[6].Value = model.Amount ;
				parameters[7].Value = model.CreateTime ;
				parameters[8].Value = model.AmountType ;


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
            string sql = "update dbo.W_OrderDetails set ";
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
            string sql = string.Format("update dbo.W_OrderDetails set {0} = @SetValue where [Id]=@Id", fieldName);
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
            
            string sql = @"delete from dbo.W_OrderDetails where [Id]=@Id";
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
        public virtual Model.HardwareMall.ModW_OrderDetails GetModel(int id)
        {
            string sql = @"select * from dbo.W_OrderDetails where [Id]=@Id";
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModW_OrderDetails model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModW_OrderDetails();
			
           				       if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}
           				       if(reader["OrderId"]!= System.DBNull.Value) {model.OrderId = System.Int32.Parse(reader["OrderId"].ToString());}
           				       if(reader["ProductId"]!= System.DBNull.Value) {model.ProductId = System.Int32.Parse(reader["ProductId"].ToString());}
           				       if(reader["FormatId"]!= System.DBNull.Value) {model.FormatId = System.Int32.Parse(reader["FormatId"].ToString());}
           				       if(reader["PackageId"]!= System.DBNull.Value) {model.PackageId = System.Int32.Parse(reader["PackageId"].ToString());}
           				       if(reader["Quantity"]!= System.DBNull.Value) {model.Quantity = System.Int32.Parse(reader["Quantity"].ToString());}
           				       if(reader["Amount"]!= System.DBNull.Value) {model.Amount = System.Decimal.Parse(reader["Amount"].ToString());}
           				       if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}
           				       model.AmountType = reader["AmountType"].ToString();
  		

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
        public virtual Model.HardwareMall.ModW_OrderDetails GetModel(int id,string cols)
        {
            cols = cols.ToLower();
            string sql = @"select "+cols+" from dbo.W_OrderDetails where [Id]=@Id";
            cols = "," + cols + ","; 
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModW_OrderDetails model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModW_OrderDetails();
			
           				       if(cols.IndexOf(",Id,".ToLower())>=0){if(reader["Id"]!= System.DBNull.Value) {model.Id = System.Int32.Parse(reader["Id"].ToString());}}
           				       if(cols.IndexOf(",OrderId,".ToLower())>=0){if(reader["OrderId"]!= System.DBNull.Value) {model.OrderId = System.Int32.Parse(reader["OrderId"].ToString());}}
           				       if(cols.IndexOf(",ProductId,".ToLower())>=0){if(reader["ProductId"]!= System.DBNull.Value) {model.ProductId = System.Int32.Parse(reader["ProductId"].ToString());}}
           				       if(cols.IndexOf(",FormatId,".ToLower())>=0){if(reader["FormatId"]!= System.DBNull.Value) {model.FormatId = System.Int32.Parse(reader["FormatId"].ToString());}}
           				       if(cols.IndexOf(",PackageId,".ToLower())>=0){if(reader["PackageId"]!= System.DBNull.Value) {model.PackageId = System.Int32.Parse(reader["PackageId"].ToString());}}
           				       if(cols.IndexOf(",Quantity,".ToLower())>=0){if(reader["Quantity"]!= System.DBNull.Value) {model.Quantity = System.Int32.Parse(reader["Quantity"].ToString());}}
           				       if(cols.IndexOf(",Amount,".ToLower())>=0){if(reader["Amount"]!= System.DBNull.Value) {model.Amount = System.Decimal.Parse(reader["Amount"].ToString());}}
           				       if(cols.IndexOf(",CreateTime,".ToLower())>=0){if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}}
           				       if(cols.IndexOf(",AmountType,".ToLower())>=0){model.AmountType = reader["AmountType"].ToString();}
  		

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

            string sql = string.Format("select {3} {0} from dbo.W_OrderDetails {1} {2}", col, where, orderby,selectTop);
            DataTable dt = this.ExecuteDataset(sql).Tables[0];
            return dt;

        }
		
		
		
    }
}
