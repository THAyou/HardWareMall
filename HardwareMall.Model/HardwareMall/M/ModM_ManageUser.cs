//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModM_ManageUser.cs
//-- 2020/3/12 18:55:34
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModM_ManageUser

    public class ModM_ManageUser
    {
           #region Fields
		private System.Int32 _id;
		private System.String _userName;
		private System.String _realName;
		private System.String _password;
		private System.DateTime _createTime;
		private System.Int32 _status;
		private System.Boolean _isdel;

	   #endregion 

        public ModM_ManageUser() { }

        /// <summary>
        ///  ModM_ManageUser
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="userName">userName</param>
		/// <param name="realName">realName</param>
		/// <param name="password">password</param>
		/// <param name="createTime">createTime</param>
		/// <param name="status">status</param>
		/// <param name="isdel">isdel</param>
        
        public ModM_ManageUser(System.Int32 id,System.String userName,System.String realName,System.String password,System.DateTime createTime,System.Int32 status,System.Boolean isdel)
        {
		    this._id = id;
		    this._userName = userName;
		    this._realName = realName;
		    this._password = password;
		    this._createTime = createTime;
		    this._status = status;
		    this._isdel = isdel;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.String UserName

        {
            get { return _userName; }
            set { _userName = value; }
        }
		
		public System.String RealName

        {
            get { return _realName; }
            set { _realName = value; }
        }
		
		public System.String Password

        {
            get { return _password; }
            set { _password = value; }
        }
		
		public System.DateTime CreateTime

        {
            get { return _createTime; }
            set { _createTime = value; }
        }
		
		public System.Int32 Status

        {
            get { return _status; }
            set { _status = value; }
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


