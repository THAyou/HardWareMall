//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModM_News.cs
//-- 2020/4/8 12:16:56
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModM_News

    public class ModM_News
    {
           #region Fields
		private System.Int32 _id;
		private System.Int32 _newsType;
		private System.String _newsTitle;
		private System.String _newsContent;
		private System.DateTime _newsDataTime;
		private System.DateTime _createTime;
		private System.String _img;

	   #endregion 

        public ModM_News() { }

        /// <summary>
        ///  ModM_News
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="newsType">newsType</param>
		/// <param name="newsTitle">newsTitle</param>
		/// <param name="newsContent">newsContent</param>
		/// <param name="newsDataTime">newsDataTime</param>
		/// <param name="createTime">createTime</param>
		/// <param name="img">img</param>
        
        public ModM_News(System.Int32 id,System.Int32 newsType,System.String newsTitle,System.String newsContent,System.DateTime newsDataTime,System.DateTime createTime,System.String img)
        {
		    this._id = id;
		    this._newsType = newsType;
		    this._newsTitle = newsTitle;
		    this._newsContent = newsContent;
		    this._newsDataTime = newsDataTime;
		    this._createTime = createTime;
		    this._img = img;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.Int32 NewsType

        {
            get { return _newsType; }
            set { _newsType = value; }
        }
		
		public System.String NewsTitle

        {
            get { return _newsTitle; }
            set { _newsTitle = value; }
        }
		
		public System.String NewsContent

        {
            get { return _newsContent; }
            set { _newsContent = value; }
        }
		
		public System.DateTime NewsDataTime

        {
            get { return _newsDataTime; }
            set { _newsDataTime = value; }
        }
		
		public System.DateTime CreateTime

        {
            get { return _createTime; }
            set { _createTime = value; }
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


