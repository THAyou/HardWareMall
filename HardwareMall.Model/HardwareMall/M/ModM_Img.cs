//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModM_Img.cs
//-- 2020/3/12 13:44:18
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModM_Img

    public class ModM_Img
    {
           #region Fields
		private System.Int32 _id;
		private System.String _imgSrc;
		private System.String _imgRemark;
		private System.DateTime _createTime;

	   #endregion 

        public ModM_Img() { }

        /// <summary>
        ///  ModM_Img
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="imgSrc">imgSrc</param>
		/// <param name="imgRemark">imgRemark</param>
		/// <param name="createTime">createTime</param>
        
        public ModM_Img(System.Int32 id,System.String imgSrc,System.String imgRemark,System.DateTime createTime)
        {
		    this._id = id;
		    this._imgSrc = imgSrc;
		    this._imgRemark = imgRemark;
		    this._createTime = createTime;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.String ImgSrc

        {
            get { return _imgSrc; }
            set { _imgSrc = value; }
        }
		
		public System.String ImgRemark

        {
            get { return _imgRemark; }
            set { _imgRemark = value; }
        }
		
		public System.DateTime CreateTime

        {
            get { return _createTime; }
            set { _createTime = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


