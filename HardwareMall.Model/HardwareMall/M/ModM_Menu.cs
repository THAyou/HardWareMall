//------------------
//-- Create By lookchem 3.0
//-- File: Model/ModM_Menu.cs
//-- 2020/3/20 15:46:57
//------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.HardwareMall
{ 

    #region ModM_Menu

    public class ModM_Menu
    {
           #region Fields
		private System.Int32 _id;
		private System.String _menuName;
		private System.String _menuUrl;
		private System.Int32 _parentId;
		private System.Int32 _sort;
		private System.Boolean _isdel;
		private System.String _styleClass;

	   #endregion 

        public ModM_Menu() { }

        /// <summary>
        ///  ModM_Menu
        /// </summary>
		/// <param name="id">id</param>
		/// <param name="menuName">menuName</param>
		/// <param name="menuUrl">menuUrl</param>
		/// <param name="parentId">parentId</param>
		/// <param name="sort">sort</param>
		/// <param name="isdel">isdel</param>
		/// <param name="styleClass">styleClass</param>
        
        public ModM_Menu(System.Int32 id,System.String menuName,System.String menuUrl,System.Int32 parentId,System.Int32 sort,System.Boolean isdel,System.String styleClass)
        {
		    this._id = id;
		    this._menuName = menuName;
		    this._menuUrl = menuUrl;
		    this._parentId = parentId;
		    this._sort = sort;
		    this._isdel = isdel;
		    this._styleClass = styleClass;

            
         
        }


        #region  Properties
		public System.Int32 Id

        {
            get { return _id; }
            set { _id = value; }
        }
		
		public System.String MenuName

        {
            get { return _menuName; }
            set { _menuName = value; }
        }
		
		public System.String MenuUrl

        {
            get { return _menuUrl; }
            set { _menuUrl = value; }
        }
		
		public System.Int32 ParentId

        {
            get { return _parentId; }
            set { _parentId = value; }
        }
		
		public System.Int32 Sort

        {
            get { return _sort; }
            set { _sort = value; }
        }
		
		public System.Boolean Isdel

        {
            get { return _isdel; }
            set { _isdel = value; }
        }
		
		public System.String StyleClass

        {
            get { return _styleClass; }
            set { _styleClass = value; }
        }
		

		 
		#endregion

    }
    #endregion


}


