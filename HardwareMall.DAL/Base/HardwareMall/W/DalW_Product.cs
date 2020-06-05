//------------------
//-- Create By lookchem 3.0
//-- File: Dal/Base/DalW_Product.cs
//-- 2020/5/6 15:05:27
//------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using DBUtility;
using Dal.Base.HardwareMall;

namespace Dal.Base.HardwareMall
{
    public abstract class DalW_Product: HardwareMallBase
    {
		
		public DalW_Product():base()
        {

        }
        public DalW_Product(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {
        }
		
        /// <summary>
        /// 实例化一个当前数据操作对象
        /// </summary>
        /// <returns></returns>
        public static Dal.HardwareMall.DalW_Product Instance()
        {
            return  new Dal.HardwareMall.DalW_Product();
        } 

        /// <summary>
        /// 增加记录并且返回当前信息ID
        /// </summary>
        /// <param name="w_Product">Model.HardwareMall.ModW_Product</param>
        /// <returns>成功返回当前插入ID，失败返回0</returns>
        public virtual int Add(Model.HardwareMall.ModW_Product model)
        {
             
            string sql = "insert into dbo.W_Product ([BillNo],[ProductCode],[ProductName],[Description],[ModelNo],[Ship],[CreateUser],[CreateTime],[UpdateUser],[UpdateTime],[Remark],[ImgId],[TitlePrice],[SkillParameter],[PriceType],[Reserve],[Isdel],[Release],[EATime])values(@BillNo,@ProductCode,@ProductName,@Description,@ModelNo,@Ship,@CreateUser,@CreateTime,@UpdateUser,@UpdateTime,@Remark,@ImgId,@TitlePrice,@SkillParameter,@PriceType,@Reserve,@Isdel,@Release,@EATime);select SCOPE_IDENTITY() as InsertId";
            SqlParameter[] parameters = {

				new SqlParameter("@BillNo",SqlDbType.VarChar,255),
				new SqlParameter("@ProductCode",SqlDbType.VarChar,255),
				new SqlParameter("@ProductName",SqlDbType.VarChar,255),
				new SqlParameter("@Description",SqlDbType.VarChar,255),
				new SqlParameter("@ModelNo",SqlDbType.VarChar,255),
				new SqlParameter("@Ship",SqlDbType.VarChar,255),
				new SqlParameter("@CreateUser",SqlDbType.Int,4),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateUser",SqlDbType.Int,4),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime),
				new SqlParameter("@Remark",SqlDbType.VarChar,255),
				new SqlParameter("@ImgId",SqlDbType.Int,4),
				new SqlParameter("@TitlePrice",SqlDbType.Decimal),
				new SqlParameter("@SkillParameter",SqlDbType.VarChar,-1),
				new SqlParameter("@PriceType",SqlDbType.VarChar,255),
				new SqlParameter("@Reserve",SqlDbType.VarChar,255),
				new SqlParameter("@Isdel",SqlDbType.Bit,1),
				new SqlParameter("@Release",SqlDbType.Bit,1),
				new SqlParameter("@EATime",SqlDbType.VarChar,255)		
	
            };
			
				parameters[0].Value = model.BillNo ;
				parameters[1].Value = model.ProductCode ;
				parameters[2].Value = model.ProductName ;
				parameters[3].Value = model.Description ;
				parameters[4].Value = model.ModelNo ;
				parameters[5].Value = model.Ship ;
				parameters[6].Value = model.CreateUser ;
				parameters[7].Value = model.CreateTime ;
				parameters[8].Value = model.UpdateUser ;
				parameters[9].Value = model.UpdateTime ;
				parameters[10].Value = model.Remark ;
				parameters[11].Value = model.ImgId ;
				parameters[12].Value = model.TitlePrice ;
				parameters[13].Value = model.SkillParameter ;
				parameters[14].Value = model.PriceType ;
				parameters[15].Value = model.Reserve ;
				parameters[16].Value = model.Isdel ;
				parameters[17].Value = model.Release ;
				parameters[18].Value = model.EATime ;



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
        /// <param name="w_Product">Model.HardwareMall.ModW_Product</param>
        /// <returns>成功返回True，错误返回False</returns>
        public virtual bool AddNoReturn(Model.HardwareMall.ModW_Product model)
        {
             
            string sql = "insert into dbo.W_Product ([BillNo],[ProductCode],[ProductName],[Description],[ModelNo],[Ship],[CreateUser],[CreateTime],[UpdateUser],[UpdateTime],[Remark],[ImgId],[TitlePrice],[SkillParameter],[PriceType],[Reserve],[Isdel],[Release],[EATime])values(@BillNo,@ProductCode,@ProductName,@Description,@ModelNo,@Ship,@CreateUser,@CreateTime,@UpdateUser,@UpdateTime,@Remark,@ImgId,@TitlePrice,@SkillParameter,@PriceType,@Reserve,@Isdel,@Release,@EATime)";
            SqlParameter[] parameters = {

				new SqlParameter("@BillNo",SqlDbType.VarChar,255),
				new SqlParameter("@ProductCode",SqlDbType.VarChar,255),
				new SqlParameter("@ProductName",SqlDbType.VarChar,255),
				new SqlParameter("@Description",SqlDbType.VarChar,255),
				new SqlParameter("@ModelNo",SqlDbType.VarChar,255),
				new SqlParameter("@Ship",SqlDbType.VarChar,255),
				new SqlParameter("@CreateUser",SqlDbType.Int,4),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateUser",SqlDbType.Int,4),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime),
				new SqlParameter("@Remark",SqlDbType.VarChar,255),
				new SqlParameter("@ImgId",SqlDbType.Int,4),
				new SqlParameter("@TitlePrice",SqlDbType.Decimal),
				new SqlParameter("@SkillParameter",SqlDbType.VarChar,-1),
				new SqlParameter("@PriceType",SqlDbType.VarChar,255),
				new SqlParameter("@Reserve",SqlDbType.VarChar,255),
				new SqlParameter("@Isdel",SqlDbType.Bit,1),
				new SqlParameter("@Release",SqlDbType.Bit,1),
				new SqlParameter("@EATime",SqlDbType.VarChar,255)			
	
            };
			
				parameters[0].Value = model.BillNo ;
				parameters[1].Value = model.ProductCode ;
				parameters[2].Value = model.ProductName ;
				parameters[3].Value = model.Description ;
				parameters[4].Value = model.ModelNo ;
				parameters[5].Value = model.Ship ;
				parameters[6].Value = model.CreateUser ;
				parameters[7].Value = model.CreateTime ;
				parameters[8].Value = model.UpdateUser ;
				parameters[9].Value = model.UpdateTime ;
				parameters[10].Value = model.Remark ;
				parameters[11].Value = model.ImgId ;
				parameters[12].Value = model.TitlePrice ;
				parameters[13].Value = model.SkillParameter ;
				parameters[14].Value = model.PriceType ;
				parameters[15].Value = model.Reserve ;
				parameters[16].Value = model.Isdel ;
				parameters[17].Value = model.Release ;
				parameters[18].Value = model.EATime ;



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
        /// <param name="w_Product">Model.HardwareMall.ModW_Product</param>
        /// <returns>成功True ,失败False</returns>
        public virtual bool Update(Model.HardwareMall.ModW_Product model)
        {
            
            string sql = @"update dbo.W_Product set [BillNo] = @BillNo ,[ProductCode] = @ProductCode ,[ProductName] = @ProductName ,[Description] = @Description ,[ModelNo] = @ModelNo ,[Ship] = @Ship ,[CreateUser] = @CreateUser ,[CreateTime] = @CreateTime ,[UpdateUser] = @UpdateUser ,[UpdateTime] = @UpdateTime ,[Remark] = @Remark ,[ImgId] = @ImgId ,[TitlePrice] = @TitlePrice ,[SkillParameter] = @SkillParameter ,[PriceType] = @PriceType ,[Reserve] = @Reserve ,[Isdel] = @Isdel ,[Release] = @Release ,[EATime] = @EATime  where [Id]=@Id";
            SqlParameter[] parameters = {

				new SqlParameter("@ID",SqlDbType.Int,4),
				new SqlParameter("@BillNo",SqlDbType.VarChar,255),
				new SqlParameter("@ProductCode",SqlDbType.VarChar,255),
				new SqlParameter("@ProductName",SqlDbType.VarChar,255),
				new SqlParameter("@Description",SqlDbType.VarChar,255),
				new SqlParameter("@ModelNo",SqlDbType.VarChar,255),
				new SqlParameter("@Ship",SqlDbType.VarChar,255),
				new SqlParameter("@CreateUser",SqlDbType.Int,4),
				new SqlParameter("@CreateTime",SqlDbType.DateTime),
				new SqlParameter("@UpdateUser",SqlDbType.Int,4),
				new SqlParameter("@UpdateTime",SqlDbType.DateTime),
				new SqlParameter("@Remark",SqlDbType.VarChar,255),
				new SqlParameter("@ImgId",SqlDbType.Int,4),
				new SqlParameter("@TitlePrice",SqlDbType.Decimal),
				new SqlParameter("@SkillParameter",SqlDbType.VarChar,-1),
				new SqlParameter("@PriceType",SqlDbType.VarChar,255),
				new SqlParameter("@Reserve",SqlDbType.VarChar,255),
				new SqlParameter("@Isdel",SqlDbType.Bit,1),
				new SqlParameter("@Release",SqlDbType.Bit,1),
				new SqlParameter("@EATime",SqlDbType.VarChar,255)
	  	
	
            };
				parameters[0].Value = model.ID ;
				parameters[1].Value = model.BillNo ;
				parameters[2].Value = model.ProductCode ;
				parameters[3].Value = model.ProductName ;
				parameters[4].Value = model.Description ;
				parameters[5].Value = model.ModelNo ;
				parameters[6].Value = model.Ship ;
				parameters[7].Value = model.CreateUser ;
				parameters[8].Value = model.CreateTime ;
				parameters[9].Value = model.UpdateUser ;
				parameters[10].Value = model.UpdateTime ;
				parameters[11].Value = model.Remark ;
				parameters[12].Value = model.ImgId ;
				parameters[13].Value = model.TitlePrice ;
				parameters[14].Value = model.SkillParameter ;
				parameters[15].Value = model.PriceType ;
				parameters[16].Value = model.Reserve ;
				parameters[17].Value = model.Isdel ;
				parameters[18].Value = model.Release ;
				parameters[19].Value = model.EATime ;


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
            string sql = "update dbo.W_Product set ";
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
            string sql = string.Format("update dbo.W_Product set {0} = @SetValue where [Id]=@Id", fieldName);
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
            
            string sql = @"delete from dbo.W_Product where [Id]=@Id";
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
        public virtual Model.HardwareMall.ModW_Product GetModel(int id)
        {
            string sql = @"select * from dbo.W_Product where [Id]=@Id";
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModW_Product model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModW_Product();
			
           				       if(reader["ID"]!= System.DBNull.Value) {model.ID = System.Int32.Parse(reader["ID"].ToString());}
           				       model.BillNo = reader["BillNo"].ToString();
           				       model.ProductCode = reader["ProductCode"].ToString();
           				       model.ProductName = reader["ProductName"].ToString();
           				       model.Description = reader["Description"].ToString();
           				       model.ModelNo = reader["ModelNo"].ToString();
           				       model.Ship = reader["Ship"].ToString();
           				       if(reader["CreateUser"]!= System.DBNull.Value) {model.CreateUser = System.Int32.Parse(reader["CreateUser"].ToString());}
           				       if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}
           				       if(reader["UpdateUser"]!= System.DBNull.Value) {model.UpdateUser = System.Int32.Parse(reader["UpdateUser"].ToString());}
           				       if(reader["UpdateTime"]!= System.DBNull.Value) {model.UpdateTime = System.DateTime.Parse(reader["UpdateTime"].ToString());}
           				       model.Remark = reader["Remark"].ToString();
           				       if(reader["ImgId"]!= System.DBNull.Value) {model.ImgId = System.Int32.Parse(reader["ImgId"].ToString());}
           				       if(reader["TitlePrice"]!= System.DBNull.Value) {model.TitlePrice = System.Decimal.Parse(reader["TitlePrice"].ToString());}
           				       model.SkillParameter = reader["SkillParameter"].ToString();
           				       model.PriceType = reader["PriceType"].ToString();
           				       model.Reserve = reader["Reserve"].ToString();
           				       if(reader["Isdel"]!= System.DBNull.Value) {model.Isdel = System.Boolean.Parse(reader["Isdel"].ToString());}
           				       if(reader["Release"]!= System.DBNull.Value) {model.Release = System.Boolean.Parse(reader["Release"].ToString());}
           				       model.EATime = reader["EATime"].ToString();
  		

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
        public virtual Model.HardwareMall.ModW_Product GetModel(int id,string cols)
        {
            cols = cols.ToLower();
            string sql = @"select "+cols+" from dbo.W_Product where [Id]=@Id";
            cols = "," + cols + ","; 
            SqlParameter[] parameters = {
				new SqlParameter("@Id", SqlDbType.Int)
                };
            parameters[0].Value = id;
            using (SqlDataReader reader = this.ExecuteReader(sql, parameters))
            {
                Model.HardwareMall.ModW_Product model = null;
                
                if (reader.Read())
                {
                    model = new Model.HardwareMall.ModW_Product();
			
           				       if(cols.IndexOf(",ID,".ToLower())>=0){if(reader["ID"]!= System.DBNull.Value) {model.ID = System.Int32.Parse(reader["ID"].ToString());}}
           				       if(cols.IndexOf(",BillNo,".ToLower())>=0){model.BillNo = reader["BillNo"].ToString();}
           				       if(cols.IndexOf(",ProductCode,".ToLower())>=0){model.ProductCode = reader["ProductCode"].ToString();}
           				       if(cols.IndexOf(",ProductName,".ToLower())>=0){model.ProductName = reader["ProductName"].ToString();}
           				       if(cols.IndexOf(",Description,".ToLower())>=0){model.Description = reader["Description"].ToString();}
           				       if(cols.IndexOf(",ModelNo,".ToLower())>=0){model.ModelNo = reader["ModelNo"].ToString();}
           				       if(cols.IndexOf(",Ship,".ToLower())>=0){model.Ship = reader["Ship"].ToString();}
           				       if(cols.IndexOf(",CreateUser,".ToLower())>=0){if(reader["CreateUser"]!= System.DBNull.Value) {model.CreateUser = System.Int32.Parse(reader["CreateUser"].ToString());}}
           				       if(cols.IndexOf(",CreateTime,".ToLower())>=0){if(reader["CreateTime"]!= System.DBNull.Value) {model.CreateTime = System.DateTime.Parse(reader["CreateTime"].ToString());}}
           				       if(cols.IndexOf(",UpdateUser,".ToLower())>=0){if(reader["UpdateUser"]!= System.DBNull.Value) {model.UpdateUser = System.Int32.Parse(reader["UpdateUser"].ToString());}}
           				       if(cols.IndexOf(",UpdateTime,".ToLower())>=0){if(reader["UpdateTime"]!= System.DBNull.Value) {model.UpdateTime = System.DateTime.Parse(reader["UpdateTime"].ToString());}}
           				       if(cols.IndexOf(",Remark,".ToLower())>=0){model.Remark = reader["Remark"].ToString();}
           				       if(cols.IndexOf(",ImgId,".ToLower())>=0){if(reader["ImgId"]!= System.DBNull.Value) {model.ImgId = System.Int32.Parse(reader["ImgId"].ToString());}}
           				       if(cols.IndexOf(",TitlePrice,".ToLower())>=0){if(reader["TitlePrice"]!= System.DBNull.Value) {model.TitlePrice = System.Decimal.Parse(reader["TitlePrice"].ToString());}}
           				       if(cols.IndexOf(",SkillParameter,".ToLower())>=0){model.SkillParameter = reader["SkillParameter"].ToString();}
           				       if(cols.IndexOf(",PriceType,".ToLower())>=0){model.PriceType = reader["PriceType"].ToString();}
           				       if(cols.IndexOf(",Reserve,".ToLower())>=0){model.Reserve = reader["Reserve"].ToString();}
           				       if(cols.IndexOf(",Isdel,".ToLower())>=0){if(reader["Isdel"]!= System.DBNull.Value) {model.Isdel = System.Boolean.Parse(reader["Isdel"].ToString());}}
           				       if(cols.IndexOf(",Release,".ToLower())>=0){if(reader["Release"]!= System.DBNull.Value) {model.Release = System.Boolean.Parse(reader["Release"].ToString());}}
           				       if(cols.IndexOf(",EATime,".ToLower())>=0){model.EATime = reader["EATime"].ToString();}
  		

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

            string sql = string.Format("select {3} {0} from dbo.W_Product {1} {2}", col, where, orderby,selectTop);
            DataTable dt = this.ExecuteDataset(sql).Tables[0];
            return dt;

        }
		
		
		
    }
}
