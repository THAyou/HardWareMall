//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModW_Intention.cs
//-- 2020/5/8 16:32:13
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModW_Intention

    public class ModW_Intention
    {
           #region Fields
		private System.Int32 _id;
		private System.String _name;
		private System.String _contactDetails;
		private System.String _remark;
		private System.DateTime _createTime;
		private System.Byte _processStatus;
		private System.String _processRemark;
		private System.DateTime? _processTime;

	   #endregion 

        public ModW_Intention() { }

        /// <summary>
        ///  ModW_Intention
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="name">name</param>
		/// <param name="contactDetails">contactDetails</param>
		/// <param name="remark">remark</param>
		/// <param name="createTime">createTime</param>
		/// <param name="processStatus">processStatus</param>
		/// <param name="processRemark">processRemark</param>
		/// <param name="processTime">processTime</param>
        
        public ModW_Intention(System.Int32 id,System.String name,System.String contactDetails,System.String remark,System.DateTime createTime,System.Byte processStatus,System.String processRemark,System.DateTime processTime)
        {
		    this._id = id;
		    this._name = name;
		    this._contactDetails = contactDetails;
		    this._remark = remark;
		    this._createTime = createTime;
		    this._processStatus = processStatus;
		    this._processRemark = processRemark;
		    this._processTime = processTime;

            
         
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
		
		public System.String ContactDetails

        {
            get { return _contactDetails; }
            set { _contactDetails = value; }
        }
		
		public System.String Remark

        {
            get { return _remark; }
            set { _remark = value; }
        }
		
		public System.DateTime CreateTime

        {
            get { return _createTime; }
            set { _createTime = value; }
        }
		
		public System.Byte ProcessStatus

        {
            get { return _processStatus; }
            set { _processStatus = value; }
        }
		
		public System.String ProcessRemark

        {
            get { return _processRemark; }
            set { _processRemark = value; }
        }
		
		public System.DateTime? ProcessTime

        {
            get { return _processTime; }
            set { _processTime = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


