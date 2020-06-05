//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModM_PriceType.cs
//-- 2020/3/16 14:29:53
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModM_PriceType

    public class ModM_PriceType
    {
           #region Fields
		private System.Int32 _id;
		private System.String _priceType;

	   #endregion 

        public ModM_PriceType() { }

        /// <summary>
        ///  ModM_PriceType
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="priceType">priceType</param>
        
        public ModM_PriceType(System.Int32 id,System.String priceType)
        {
		    this._id = id;
		    this._priceType = priceType;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.String PriceType

        {
            get { return _priceType; }
            set { _priceType = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


