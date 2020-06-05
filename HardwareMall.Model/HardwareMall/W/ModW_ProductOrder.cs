//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModW_ProductOrder.cs
//-- 2020/5/7 13:59:41
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModW_ProductOrder

    public class ModW_ProductOrder
    {
           #region Fields
		private System.Int32 _id;
		private System.String _orderCode;
		private System.Decimal _amount;
		private System.String _clientName;
		private System.String _contactDetails;
		private System.String _remark;
		private System.DateTime _createTime;
		private System.Int32 _status;
		private System.DateTime? _processTime;
		private System.String _email;

	   #endregion 

        public ModW_ProductOrder() { }

        /// <summary>
        ///  ModW_ProductOrder
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="orderCode">orderCode</param>
		/// <param name="amount">amount</param>
		/// <param name="clientName">clientName</param>
		/// <param name="contactDetails">contactDetails</param>
		/// <param name="remark">remark</param>
		/// <param name="createTime">createTime</param>
		/// <param name="status">status</param>
		/// <param name="processTime">processTime</param>
		/// <param name="email">email</param>
        
        public ModW_ProductOrder(System.Int32 id,System.String orderCode,System.Decimal amount,System.String clientName,System.String contactDetails,System.String remark,System.DateTime createTime,System.Int32 status,System.DateTime processTime,System.String email)
        {
		    this._id = id;
		    this._orderCode = orderCode;
		    this._amount = amount;
		    this._clientName = clientName;
		    this._contactDetails = contactDetails;
		    this._remark = remark;
		    this._createTime = createTime;
		    this._status = status;
		    this._processTime = processTime;
		    this._email = email;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.String OrderCode

        {
            get { return _orderCode; }
            set { _orderCode = value; }
        }
		
		public System.Decimal Amount

        {
            get { return _amount; }
            set { _amount = value; }
        }
		
		public System.String ClientName

        {
            get { return _clientName; }
            set { _clientName = value; }
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
		
		public System.Int32 Status

        {
            get { return _status; }
            set { _status = value; }
        }
		
		public System.DateTime? ProcessTime

        {
            get { return _processTime; }
            set { _processTime = value; }
        }
		
		public System.String Email

        {
            get { return _email; }
            set { _email = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


