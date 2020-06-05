//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModW_ProductPackage.cs
//-- 2020/5/6 16:03:11
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModW_ProductPackage

    public class ModW_ProductPackage
    {
           #region Fields
		private System.Int32 _id;
		private System.Int32 _productId;
		private System.String _priceType;
		private System.Decimal? _price;
		private System.String _package;
		private System.Int32? _createUser;
		private System.DateTime? _createTime;
		private System.DateTime? _updateTime;
		private System.Int32? _updateUser;
		private System.Boolean _isdel;
		private System.Int32 _sort;
		private System.Int32 _pNum;
		private System.Int32 _formatId;

	   #endregion 

        public ModW_ProductPackage() { }

        /// <summary>
        ///  ModW_ProductPackage
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="productId">productId</param>
		/// <param name="priceType">priceType</param>
		/// <param name="price">price</param>
		/// <param name="package">package</param>
		/// <param name="createUser">createUser</param>
		/// <param name="createTime">createTime</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="updateUser">updateUser</param>
		/// <param name="isdel">isdel</param>
		/// <param name="sort">sort</param>
		/// <param name="pNum">pNum</param>
		/// <param name="formatId">formatId</param>
        
        public ModW_ProductPackage(System.Int32 id,System.Int32 productId,System.String priceType,System.Decimal price,System.String package,System.Int32 createUser,System.DateTime createTime,System.DateTime updateTime,System.Int32 updateUser,System.Boolean isdel,System.Int32 sort,System.Int32 pNum,System.Int32 formatId)
        {
		    this._id = id;
		    this._productId = productId;
		    this._priceType = priceType;
		    this._price = price;
		    this._package = package;
		    this._createUser = createUser;
		    this._createTime = createTime;
		    this._updateTime = updateTime;
		    this._updateUser = updateUser;
		    this._isdel = isdel;
		    this._sort = sort;
		    this._pNum = pNum;
		    this._formatId = formatId;

            
         
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
		
		public System.String PriceType

        {
            get { return _priceType; }
            set { _priceType = value; }
        }
		
		public System.Decimal? Price

        {
            get { return _price; }
            set { _price = value; }
        }
		
		public System.String Package

        {
            get { return _package; }
            set { _package = value; }
        }
		
		public System.Int32? CreateUser

        {
            get { return _createUser; }
            set { _createUser = value; }
        }
		
		public System.DateTime? CreateTime

        {
            get { return _createTime; }
            set { _createTime = value; }
        }
		
		public System.DateTime? UpdateTime

        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }
		
		public System.Int32? UpdateUser

        {
            get { return _updateUser; }
            set { _updateUser = value; }
        }
		
		public System.Boolean Isdel

        {
            get { return _isdel; }
            set { _isdel = value; }
        }
		
		public System.Int32 Sort

        {
            get { return _sort; }
            set { _sort = value; }
        }
		
		public System.Int32 PNum

        {
            get { return _pNum; }
            set { _pNum = value; }
        }
		
		public System.Int32 FormatId

        {
            get { return _formatId; }
            set { _formatId = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


