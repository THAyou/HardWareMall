//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModM_ProductRe.cs
//-- 2020/3/23 18:08:50
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall_Chinese
{ 

    #region ModM_ProductRe

    public class ModM_ProductRe
    {
           #region Fields
		private System.Int32 _id;
		private System.String _name;
		private System.DateTime _createTime;
		private System.Int32 _createBy;
		private System.String _url;
		private System.String _title;
		private System.String _littleTitle;
		private System.String _img;

	   #endregion 

        public ModM_ProductRe() { }

        /// <summary>
        ///  ModM_ProductRe
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="name">name</param>
		/// <param name="createTime">createTime</param>
		/// <param name="createBy">createBy</param>
		/// <param name="url">url</param>
		/// <param name="title">title</param>
		/// <param name="littleTitle">littleTitle</param>
		/// <param name="img">img</param>
        
        public ModM_ProductRe(System.Int32 id,System.String name,System.DateTime createTime,System.Int32 createBy,System.String url,System.String title,System.String littleTitle,System.String img)
        {
		    this._id = id;
		    this._name = name;
		    this._createTime = createTime;
		    this._createBy = createBy;
		    this._url = url;
		    this._title = title;
		    this._littleTitle = littleTitle;
		    this._img = img;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.String Name

        {
            get { return _name; }
            set { _name = value; }
        }
		
		public System.DateTime CreateTime

        {
            get { return _createTime; }
            set { _createTime = value; }
        }
		
		public System.Int32 CreateBy

        {
            get { return _createBy; }
            set { _createBy = value; }
        }
		
		public System.String Url

        {
            get { return _url; }
            set { _url = value; }
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
		
		public System.String Img

        {
            get { return _img; }
            set { _img = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


