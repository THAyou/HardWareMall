//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModM_HomeElement.cs
//-- 2020/3/18 16:34:17
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModM_HomeElement

    public class ModM_HomeElement
    {
           #region Fields
		private System.Int32 _id;
		private System.Int32 _homeTypeEnum;
		private System.String _img;
		private System.String _title;
		private System.String _littleTitle;
		private System.Int32? _createUser;
		private System.DateTime? _createTime;
		private System.Int32? _updateUser;
		private System.DateTime? _updateTime;
		private System.String _href;
		private System.Int32? _sort;

	   #endregion 

        public ModM_HomeElement() { }

        /// <summary>
        ///  ModM_HomeElement
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="homeTypeEnum">homeTypeEnum</param>
		/// <param name="img">img</param>
		/// <param name="title">title</param>
		/// <param name="littleTitle">littleTitle</param>
		/// <param name="createUser">createUser</param>
		/// <param name="createTime">createTime</param>
		/// <param name="updateUser">updateUser</param>
		/// <param name="updateTime">updateTime</param>
		/// <param name="href">href</param>
		/// <param name="sort">sort</param>
        
        public ModM_HomeElement(System.Int32 id,System.Int32 homeTypeEnum,System.String img,System.String title,System.String littleTitle,System.Int32 createUser,System.DateTime createTime,System.Int32 updateUser,System.DateTime updateTime,System.String href,System.Int32 sort)
        {
		    this._id = id;
		    this._homeTypeEnum = homeTypeEnum;
		    this._img = img;
		    this._title = title;
		    this._littleTitle = littleTitle;
		    this._createUser = createUser;
		    this._createTime = createTime;
		    this._updateUser = updateUser;
		    this._updateTime = updateTime;
		    this._href = href;
		    this._sort = sort;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.Int32 HomeTypeEnum

        {
            get { return _homeTypeEnum; }
            set { _homeTypeEnum = value; }
        }
		
		public System.String Img

        {
            get { return _img; }
            set { _img = value; }
        }
		
		public System.String Title

        {
            get { return _title; }
            set { _title = value; }
        }
		
		public System.String LittleTitle

        {
            get { return _littleTitle; }
            set { _littleTitle = value; }
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
		
		public System.String Href

        {
            get { return _href; }
            set { _href = value; }
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


