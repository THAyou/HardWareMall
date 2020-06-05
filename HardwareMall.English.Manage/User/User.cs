using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareMall.Manage.User
{
    public class User :IUser
    {
        private readonly IHttpContextAccessor _accessor;
        public User(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId => int.Parse(_accessor.HttpContext.Request.Cookies["User"]);
    }
}
