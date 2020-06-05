//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModW_Product.cs
//-- 2020/5/6 15:05:27
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModW_Product

    public class ModW_Product
    {
           #region Fields
		private System.Int32 _iD;
		private System.String _billNo;
		private System.String _productCode;
		private System.String _productName;
		private System.String _description;
		private System.String _modelNo;
		private System.String _ship;
		private System.Int32? _createUser;
		private System.DateTime? _createTime;
		private System.Int32? _updateUser;
		private System.DateTime? _updateTime;
		private System.String _remark;
		private System.Int32? _imgId;
		private System.Decimal? _titlePrice;
		private System.String _skillParameter;
		private System.String _priceType;
		private System.String _reserve;
		private System.Boolean _isdel;
		private System.Boolean? _release;
		private System.String _eATime;

	   #endregion 

        public ModW_Product() { }

        /// <summary>
        ///  ModW_Product
        /// </summary>
		/// <param name="iD">iD</param>
		/// <param name="billNo">billNo</param>
		/// <param name="productCode">productCode</param>
		/// <param name="productName">productName</param>
		/// <param name="description">description</param>
		/// <param name="modelNo">modelNo</param>
		/// <param name="ship">ship</param>
		/// <param name="createUser">createUser</param>
		/// <param name="createTime">createTime</param>
		/// <param name="updateUser">updateUser</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="remark">remark</param>
		/// <param name="imgId">imgId</param>
		/// <param name="titlePrice">titlePrice</param>
		/// <param name="skillParameter">skillParameter</param>
		/// <param name="priceType">priceType</param>
		/// <param name="reserve">reserve</param>
		/// <param name="isdel">isdel</param>
		/// <param name="release">release</param>
		/// <param name="eATime">eATime</param>
        
        public ModW_Product(System.Int32 iD,System.String billNo,System.String productCode,System.String productName,System.String description,System.String modelNo,System.String ship,System.Int32 createUser,System.DateTime createTime,System.Int32 updateUser,System.DateTime updateTime,System.String remark,System.Int32 imgId,System.Decimal titlePrice,System.String skillParameter,System.String priceType,System.String reserve,System.Boolean isdel,System.Boolean release,System.String eATime)
        {
		    this._iD = iD;
		    this._billNo = billNo;
		    this._productCode = productCode;
		    this._productName = productName;
		    this._description = description;
		    this._modelNo = modelNo;
		    this._ship = ship;
		    this._createUser = createUser;
		    this._createTime = createTime;
		    this._updateUser = updateUser;
		    this._updateTime = updateTime;
		    this._remark = remark;
		    this._imgId = imgId;
		    this._titlePrice = titlePrice;
		    this._skillParameter = skillParameter;
		    this._priceType = priceType;
		    this._reserve = reserve;
		    this._isdel = isdel;
		    this._release = release;
		    this._eATime = eATime;

            
         
        }


        #region  Properties
		public System.Int32 ID

        {
            get { return _iD; }
            set { _iD = value; }
        }
		
		public System.String BillNo

        {
            get { return _billNo; }
            set { _billNo = value; }
        }
		
		public System.String ProductCode

        {
            get { return _productCode; }
            set { _productCode = value; }
        }
		
		public System.String ProductName

        {
            get { return _productName; }
            set { _productName = value; }
        }
		
		public System.String Description

        {
            get { return _description; }
            set { _description = value; }
        }
		
		public System.String ModelNo

        {
            get { return _modelNo; }
            set { _modelNo = value; }
        }
		
		public System.String Ship

        {
            get { return _ship; }
            set { _ship = value; }
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
		
		public System.Int32? UpdateUser

        {
            get { return _updateUser; }
            set { _updateUser = value; }
        }
		
		public System.DateTime? UpdateTime

        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }
		
		public System.String Remark

        {
            get { return _remark; }
            set { _remark = value; }
        }
		
		public System.Int32? ImgId

        {
            get { return _imgId; }
            set { _imgId = value; }
        }
		
		public System.Decimal? TitlePrice

        {
            get { return _titlePrice; }
            set { _titlePrice = value; }
        }
		
		public System.String SkillParameter

        {
            get { return _skillParameter; }
            set { _skillParameter = value; }
        }
		
		public System.String PriceType

        {
            get { return _priceType; }
            set { _priceType = value; }
        }
		
		public System.String Reserve

        {
            get { return _reserve; }
            set { _reserve = value; }
        }
		
		public System.Boolean Isdel

        {
            get { return _isdel; }
            set { _isdel = value; }
        }
		
		public System.Boolean? Release

        {
            get { return _release; }
            set { _release = value; }
        }
		
		public System.String EATime

        {
            get { return _eATime; }
            set { _eATime = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


