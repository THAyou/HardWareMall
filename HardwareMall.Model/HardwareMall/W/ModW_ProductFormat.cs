//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModW_ProductFormat.cs
//-- 2020/5/6 15:52:53
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModW_ProductFormat

    public class ModW_ProductFormat
    {
           #region Fields
		private System.Int32 _id;
		private System.String _formatName;
		private System.Int32 _sort;
		private System.Int32 _productId;

	   #endregion 

        public ModW_ProductFormat() { }

        /// <summary>
        ///  ModW_ProductFormat
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="formatName">formatName</param>
		/// <param name="sort">sort</param>
		/// <param name="productId">productId</param>
        
        public ModW_ProductFormat(System.Int32 id,System.String formatName,System.Int32 sort,System.Int32 productId)
        {
		    this._id = id;
		    this._formatName = formatName;
		    this._sort = sort;
		    this._productId = productId;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.String FormatName

        {
            get { return _formatName; }
            set { _formatName = value; }
        }
		
		public System.Int32 Sort

        {
            get { return _sort; }
            set { _sort = value; }
        }
		
		public System.Int32 ProductId

        {
            get { return _productId; }
            set { _productId = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


