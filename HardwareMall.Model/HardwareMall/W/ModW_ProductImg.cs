//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModW_ProductImg.cs
//-- 2020/3/9 14:41:32
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModW_ProductImg

    public class ModW_ProductImg
    {
           #region Fields
		private System.Int32 _id;
		private System.Int32 _productId;
		private System.String _img;
		private System.Int32? _createUser;
		private System.DateTime _createTime;
		private System.Boolean _isdel;
		private System.Int32 _isTitleImg;

	   #endregion 

        public ModW_ProductImg() { }

        /// <summary>
        ///  ModW_ProductImg
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="productId">productId</param>
		/// <param name="img">img</param>
		/// <param name="createUser">createUser</param>
		/// <param name="createTime">createTime</param>
		/// <param name="isdel">isdel</param>
		/// <param name="isTitleImg">isTitleImg</param>
        
        public ModW_ProductImg(System.Int32 id,System.Int32 productId,System.String img,System.Int32 createUser,System.DateTime createTime,System.Boolean isdel,System.Int32 isTitleImg)
        {
		    this._id = id;
		    this._productId = productId;
		    this._img = img;
		    this._createUser = createUser;
		    this._createTime = createTime;
		    this._isdel = isdel;
		    this._isTitleImg = isTitleImg;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.Int32 ProductId

        {
            get { return _productId; }
            set { _productId = value; }
        }
		
		public System.String Img

        {
            get { return _img; }
            set { _img = value; }
        }
		
		public System.Int32? CreateUser

        {
            get { return _createUser; }
            set { _createUser = value; }
        }
		
		public System.DateTime CreateTime

        {
            get { return _createTime; }
            set { _createTime = value; }
        }
		
		public System.Boolean Isdel

        {
            get { return _isdel; }
            set { _isdel = value; }
        }
		
		public System.Int32 IsTitleImg

        {
            get { return _isTitleImg; }
            set { _isTitleImg = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


