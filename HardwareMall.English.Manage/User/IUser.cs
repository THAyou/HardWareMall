using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareMall.Manage.User
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        int UserId { get; }
    }
}
