using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardwareMall.Web.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HardwareMall.Tool;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Bll.HardwareMall;
using HardwareMall.Manage;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Model.HardwareMall;
using HardwareMall.Manage.User;

namespace HardwareMall.Manage.ApiControllers
{
    /// <summary>
    /// 系统控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly BllM_ManageUser _manageUser = Bll.Base.HardwareMall.BllM_ManageUser.Instance();
        private readonly BllM_Menu _menu = Bll.Base.HardwareMall.BllM_Menu.Instance();
        private readonly IJwt _jwt;
        private IConfiguration _configuration;
        private JwtSetting _setting = new JwtSetting();
        private readonly IUser _user;

        public SystemController(IJwt jwt, IConfiguration configration, IUser user)
        {
            _jwt = jwt;
            _configuration = configration;
            _configuration.GetSection("JwtSettings").Bind(_setting);
            _user = user;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public ApiResult Login([FromBody]dynamic data)
        {
            var res = new ApiResult() { Message = "登录失败", Success = false, Code = 0 };
            string UserName = data.UserName;
            string Password = data.Password;
            var Md5Password = Password.MD5Hash();//MD5加密
            var adminInfo = _manageUser.GetUserByUserAndPsw(UserName, Md5Password);//访问数据库
            //看看是否存在此用户
            if (adminInfo != null)
            {
                //生成TOKEN 
                Dictionary<string, string> clims = new Dictionary<string, string>();
                clims.Add(ClaimTypes.Name, adminInfo.UserName);
                clims.Add(ClaimTypes.UserData, adminInfo.RealName);
                clims.Add(JwtRegisteredClaimNames.Jti, adminInfo.Id.ToString());
                var Token = _jwt.CreateToken(clims);
                res.Code = 1;
                res.Message = "登录成功";
                res.Success = true;
                var CookiesBody = HttpContext.Request.Cookies[_setting.HeadField];
                //如果存在则删除原Cookies
                if (!string.IsNullOrWhiteSpace(CookiesBody))
                {
                    HttpContext.Response.Cookies.Delete(_setting.HeadField);
                }
                //增加新Cookies
                HttpContext.Response.Cookies.Append(_setting.HeadField, Token, new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(_setting.Expires)
                });
                HttpContext.Response.Cookies.Append("User", adminInfo.Id.ToString(), new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(_setting.Expires)
                });
            }
            return res;
        }

        /// <summary>
        /// 获取列表管理
        /// </summary>
        /// <returns></returns>
        [HttpGet("getMenuList")]
        public ApiResult<object> GetMenuList()
        {
            var res = new ApiResult<object>() { Message = "获取成功", Success = true, Code = 0 };
            res.Data = _menu.GetMenuList().OrderBy(m => m.Sort).ToList();
            return res;
        }

        /// <summary>
        /// 获取菜单编辑
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("getMenuEdit")]
        public ApiResult<object> GetMenuEdit()
        {
            var res = new ApiResult<object>() { Message = "获取成功", Success = true, Code = 0 };
            var MenuData = _menu.GetMenuList().OrderBy(m => m.Sort).ToList().Select(n => new { id = n.Id, name = n.MenuName, pId = n.ParentId, open = n.ParentId > 0 });
            res.Data = MenuData.Prepend(new { id = 0, name = "默认", pId = 0, open = true });
            return res;
        }

        /// <summary>
        /// 保存菜单
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        [HttpPost("saveMenu")]
        public ApiResult SaveMenu([FromBody]dynamic data,[FromQuery]int Type)
        {
            string Id = data.id;
            string ParentId = data.parentId;
            string MenuName = data.menuName;
            string MenuUrl = data.menuUrl;
            string StyleClass = data.styleClass;
            string Sort = data.sort;
            var res = new ApiResult() { Message = "获取成功", Success = true, Code = 1 };
            if (Type == 1)
            {
                _menu.AddNoReturn(new ModM_Menu
                {
                    ParentId= int.Parse(ParentId),
                    MenuName= MenuName,
                    MenuUrl= MenuUrl,
                    StyleClass= StyleClass,
                    Sort= int.Parse(Sort),
                    Isdel = false
                });
            }
            else if(Type==0)
            {
                _menu.Update(new ModM_Menu
                {
                    Id=int.Parse(Id),
                    ParentId = int.Parse(ParentId),
                    MenuName = MenuName,
                    MenuUrl = MenuUrl,
                    StyleClass = StyleClass,
                    Sort = int.Parse(Sort),
                    Isdel=false
                });
            }
            return res;
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        [HttpDelete("delMenu")]
        public ApiResult DelMenu([FromBody]dynamic data)
        {
            string Id = data.Id;
            var res = new ApiResult() { Message = "获取成功", Success = true, Code = 1 };
            _menu.Delete(int.Parse(Id));
            return res;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet("getUserList")]
        public object GetUserList(int page = 1, int limit = 10)
        {
            return _manageUser.GetUserList(page, limit);
        }

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        [HttpPost("saveUser")]
        public ApiResult SaveUser([FromBody]dynamic data, [FromQuery]int Type)
        {
            string Id = data.id;
            string UserName = data.userName;
            string RealName = data.realName;
            string Password = "123456";
            var res = new ApiResult() { Message = "操作成功", Success = true, Code = 1 };
            if (Type == 1)
            {
                _manageUser.AddNoReturn(new ModM_ManageUser
                {
                    UserName= UserName,
                    RealName= RealName,
                    Password= Password.MD5Hash(),
                    CreateTime=DateTime.Now,
                    Isdel=false,
                    Status=1
                });
            }
            else if (Type == 0)
            {
                _manageUser.UpdataUser(new ModM_ManageUser
                {
                    Id=int.Parse(Id),
                    UserName = UserName,
                    RealName = RealName
                });
            }
            return res;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut("resetPsw")]
        public ApiResult ResetPsw([FromBody]dynamic data)
        {
            string Id = data.Id;
            var res = new ApiResult() { Message = "操作成功", Success = true, Code = 1 };
            string Psw = "123456";
            _manageUser.UpdataPsw(int.Parse(Id), Psw.MD5Hash());
            return res;
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut("updataStatus")]
        public ApiResult UpdataStatus([FromBody]dynamic data)
        {
            string Id = data.Id;
            string Status = data.status;
            var res = new ApiResult() { Message = "操作成功", Success = true, Code = 1 };
            _manageUser.UpdataStatus(int.Parse(Id), int.Parse(Status));
            return res;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("updatePsw")]
        public ApiResult UpdatePsw([FromBody]dynamic data)
        {
            string oldPassword = data.oldPassword;
            string newPassword = data.newPassword;
            int UserId = _user.UserId;
            var res = new ApiResult() { Message = "操作成功", Success = true, Code = 1 };
            var UserInfo=_manageUser.GetModel(UserId);
            if (oldPassword.MD5Hash() != UserInfo.Password)
            {
                res.Code = 0;
                res.Success = false;
                res.Message = "旧密码输入错误";
                return res;
            }
            _manageUser.UpdataPsw(UserId, newPassword.MD5Hash());
            return res;
        }

        /// <summary>
        /// 获取后台日志
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet("getManageLog")]
        public object GetManageLog(int page = 1, int limit = 10, string logLevel = "",string createTime="")
        {
            return _menu.GetManageLog(page, limit, logLevel, createTime);
        }

        /// <summary>
        /// 获取后台日志
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet("getWebLog")]
        public object GetWebLog(int page = 1, int limit = 10, string logLevel = "", string createTime = "")
        {
            return _menu.GetWebLog(page, limit, logLevel, createTime);
        }
    }
}