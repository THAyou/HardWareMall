//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModW_ProductType.cs
//-- 2020/3/18 16:37:24
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModW_ProductType

    public class ModW_ProductType
    {
           #region Fields
		private System.Int32 _id;
		private System.String _typeName;
		private System.Int32 _parentId;
		private System.Int32? _createBy;
		private System.DateTime? _createTime;
		private System.Int32? _updateBy;
		private System.DateTime? _updateTime;
		private System.Boolean _isDel;
		private System.String _img;
		private System.Int32? _sort;

	   #endregion 

        public ModW_ProductType() { }

        /// <summary>
        ///  ModW_ProductType
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="typeName">typeName</param>
		/// <param name="parentId">parentId</param>
		/// <param name="createBy">createBy</param>
		/// <param name="createTime">createTime</param>
		/// <param name="updateBy">updateBy</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="isDel">isDel</param>
		/// <param name="img">img</param>
		/// <param name="sort">sort</param>
        
        public ModW_ProductType(System.Int32 id,System.String typeName,System.Int32 parentId,System.Int32 createBy,System.DateTime createTime,System.Int32 updateBy,System.DateTime updateTime,System.Boolean isDel,System.String img,System.Int32 sort)
        {
		    this._id = id;
		    this._typeName = typeName;
		    this._parentId = parentId;
		    this._createBy = createBy;
		    this._createTime = createTime;
		    this._updateBy = updateBy;
		    this._updateTime = updateTime;
		    this._isDel = isDel;
		    this._img = img;
		    this._sort = sort;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.String TypeName

        {
            get { return _typeName; }
            set { _typeName = value; }
        }
		
		public System.Int32 ParentId

        {
            get { return _parentId; }
            set { _parentId = value; }
        }
		
		public System.Int32? CreateBy

        {
            get { return _createBy; }
            set { _createBy = value; }
        }
		
		public System.DateTime? CreateTime

        {
            get { return _createTime; }
            set { _createTime = value; }
        }
		
		public System.Int32? UpdateBy

        {
            get { return _updateBy; }
            set { _updateBy = value; }
        }
		
		public System.DateTime? UpdateTime

        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }
		
		public System.Boolean IsDel

        {
            get { return _isDel; }
            set { _isDel = value; }
        }
		
		public System.String Img

        {
            get { return _img; }
            set { _img = value; }
        }
		
		public System.Int32? Sort

        {
            get { return _sort; }
            set { _sort = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


