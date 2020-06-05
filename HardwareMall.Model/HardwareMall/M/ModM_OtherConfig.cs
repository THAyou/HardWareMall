//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModM_OtherConfig.cs
//-- 2020/3/19 14:27:40
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModM_OtherConfig

    public class ModM_OtherConfig
    {
           #region Fields
		private System.Int32 _id;
		private System.Int32 _type;
		private System.String _title;
		private System.String _content;
		private System.Int32 _titleImg;
		private System.String _imgIDs;
		private System.String _imgIDs2;
		private System.DateTime _createTime;
		private System.String _name;

	   #endregion 

        public ModM_OtherConfig() { }

        /// <summary>
        ///  ModM_OtherConfig
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="type">type</param>
		/// <param name="title">title</param>
		/// <param name="content">content</param>
		/// <param name="titleImg">titleImg</param>
		/// <param name="imgIDs">imgIDs</param>
		/// <param name="imgIDs2">imgIDs2</param>
		/// <param name="createTime">createTime</param>
		/// <param name="name">name</param>
        
        public ModM_OtherConfig(System.Int32 id,System.Int32 type,System.String title,System.String content,System.Int32 titleImg,System.String imgIDs,System.String imgIDs2,System.DateTime createTime,System.String name)
        {
		    this._id = id;
		    this._type = type;
		    this._title = title;
		    this._content = content;
		    this._titleImg = titleImg;
		    this._imgIDs = imgIDs;
		    this._imgIDs2 = imgIDs2;
		    this._createTime = createTime;
		    this._name = name;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.Int32 Type

        {
            get { return _type; }
            set { _type = value; }
        }
		
		public System.String Title

        {
            get { return _title; }
            set { _title = value; }
        }
		
		public System.String Content

        {
            get { return _content; }
            set { _content = value; }
        }
		
		public System.Int32 TitleImg

        {
            get { return _titleImg; }
            set { _titleImg = value; }
        }
		
		public System.String ImgIDs

        {
            get { return _imgIDs; }
            set { _imgIDs = value; }
        }
		
		public System.String ImgIDs2

        {
            get { return _imgIDs2; }
            set { _imgIDs2 = value; }
        }
		
		public System.DateTime CreateTime

        {
            get { return _createTime; }
            set { _createTime = value; }
        }
		
		public System.String Name

        {
            get { return _name; }
            set { _name = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


