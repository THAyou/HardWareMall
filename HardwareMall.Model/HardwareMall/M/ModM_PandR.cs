//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModM_PandR.cs
//-- 2020/3/23 18:08:50
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall_Chinese
{ 

    #region ModM_PandR

    public class ModM_PandR
    {
           #region Fields
		private System.Int32 _id;
		private System.Int32 _productId;
		private System.Int32 _reId;

	   #endregion 

        public ModM_PandR() { }

        /// <summary>
        ///  ModM_PandR
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="productId">productId</param>
		/// <param name="reId">reId</param>
        
        public ModM_PandR(System.Int32 id,System.Int32 productId,System.Int32 reId)
        {
		    this._id = id;
		    this._productId = productId;
		    this._reId = reId;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.Int32 ProductId

        {
            get { return _productId; }
            set { _productId = value; }
        }
		
		public System.Int32 ReId

        {
            get { return _reId; }
            set { _reId = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


