using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal.Base.HardwareMall
{
    public class HardwareMallBase:BaseDal
    {
        /// <summary>
        /// 实例化一个Dal对象
        /// </summary>
        /// <param name="dalType">需实例化的类</param>
        /// <returns></returns>
        public HardwareMallBase():base(ESqlConnType.HardwareMall)
        {
            
        }

        public HardwareMallBase(ESqlConnType eSqlConnType)
            : base(eSqlConnType)
        {

        }


    }
}
