//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModW_OrderDetails.cs
//-- 2020/5/7 15:12:39
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModW_OrderDetails

    public class ModW_OrderDetails
    {
           #region Fields
		private System.Int32 _id;
		private System.Int32 _orderId;
		private System.Int32 _productId;
		private System.Int32 _formatId;
		private System.Int32 _packageId;
		private System.Int32 _quantity;
		private System.Decimal _amount;
		private System.DateTime _createTime;
		private System.String _amountType;

	   #endregion 

        public ModW_OrderDetails() { }

        /// <summary>
        ///  ModW_OrderDetails
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="orderId">orderId</param>
		/// <param name="productId">productId</param>
		/// <param name="formatId">formatId</param>
		/// <param name="packageId">packageId</param>
		/// <param name="quantity">quantity</param>
		/// <param name="amount">amount</param>
		/// <param name="createTime">createTime</param>
		/// <param name="amountType">amountType</param>
        
        public ModW_OrderDetails(System.Int32 id,System.Int32 orderId,System.Int32 productId,System.Int32 formatId,System.Int32 packageId,System.Int32 quantity,System.Decimal amount,System.DateTime createTime,System.String amountType)
        {
		    this._id = id;
		    this._orderId = orderId;
		    this._productId = productId;
		    this._formatId = formatId;
		    this._packageId = packageId;
		    this._quantity = quantity;
		    this._amount = amount;
		    this._createTime = createTime;
		    this._amountType = amountType;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.Int32 OrderId

        {
            get { return _orderId; }
            set { _orderId = value; }
        }
		
		public System.Int32 ProductId

        {
            get { return _productId; }
            set { _productId = value; }
        }
		
		public System.Int32 FormatId

        {
            get { return _formatId; }
            set { _formatId = value; }
        }
		
		public System.Int32 PackageId

        {
            get { return _packageId; }
            set { _packageId = value; }
        }
		
		public System.Int32 Quantity

        {
            get { return _quantity; }
            set { _quantity = value; }
        }
		
		public System.Decimal Amount

        {
            get { return _amount; }
            set { _amount = value; }
        }
		
		public System.DateTime CreateTime

        {
            get { return _createTime; }
            set { _createTime = value; }
        }
		
		public System.String AmountType

        {
            get { return _amountType; }
            set { _amountType = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


