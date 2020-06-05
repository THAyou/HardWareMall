//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModW_ProductAndType.cs
//-- 2020/3/10 15:12:59
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModW_ProductAndType

    public class ModW_ProductAndType
    {
           #region Fields
		private System.Int32 _id;
		private System.Int32 _proTypeID;
		private System.Int32 _proID;
		private System.Boolean _isdel;

	   #endregion 

        public ModW_ProductAndType() { }

        /// <summary>
        ///  ModW_ProductAndType
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="proTypeID">proTypeID</param>
		/// <param name="proID">proID</param>
		/// <param name="isdel">isdel</param>
        
        public ModW_ProductAndType(System.Int32 id,System.Int32 proTypeID,System.Int32 proID,System.Boolean isdel)
        {
		    this._id = id;
		    this._proTypeID = proTypeID;
		    this._proID = proID;
		    this._isdel = isdel;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.Int32 ProTypeID

        {
            get { return _proTypeID; }
            set { _proTypeID = value; }
        }
		
		public System.Int32 ProID

        {
            get { return _proID; }
            set { _proID = value; }
        }
		
		public System.Boolean Isdel

        {
            get { return _isdel; }
            set { _isdel = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


