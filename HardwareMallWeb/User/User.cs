using HardwareMall.Tool;
using Microsoft.AspNetCore.Http;
using Model.HardwareMall;
using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace HardwareMall.Web
{
    public class User : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        public User(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        /// 购物车对象
        /// </summary>
        public List<ShoppingCartDto> ShoppingCart => GetShoppingCarts();


        /// <summary>
        /// 获取购物车
        /// </summary>
        /// <returns></returns>
        private List<ShoppingCartDto> GetShoppingCarts()
        {
            var res = new List<ShoppingCartDto>();
            try
            {
                var DtoStr = _accessor.HttpContext.Request.Cookies[StaticString.ShopKey];
                if (!string.IsNullOrWhiteSpace(DtoStr))
                {
                    res = DtoStr.ToObject<List<ShoppingCartDto>>();
                }
            }
            catch
            {
                res = new List<ShoppingCartDto>();
            }
            return res;
        }

        /// <summary>
        /// 增加至购物车
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public void AddShoppingCarts(ShoppingCartDto dto)
        {
            //读取Cookies里的购物车信息
            var Shopping = ShoppingCart;
            Shopping.Add(dto);
            //删除原购物车信息
            if (ShoppingCart != null && ShoppingCart.Count > 0)
            {
                _accessor.HttpContext.Response.Cookies.Delete(StaticString.ShopKey);
            }
            //写入新购物车信息
            _accessor.HttpContext.Response.Cookies.Append(StaticString.ShopKey, Shopping.ToJson(), new CookieOptions
            {
                Expires = DateTime.Now.AddDays(int.Parse(StaticString.ShopDayTime))
            });
        }

        /// <summary>
        /// 删除购物车里的物品
        /// </summary>
        /// <param name="Guid"></param>
        /// <returns></returns>
        public void DeleteShoppingCarts(string Guid)
        {
            //读取Cookies里的购物车信息
            var Shopping = ShoppingCart;

            Shopping.Remove(Shopping.Where(m => m.GUID == Guid).ToList()[0]);
            //删除原购物车信息
            if (ShoppingCart != null && ShoppingCart.Count > 0)
            {
                _accessor.HttpContext.Response.Cookies.Delete(StaticString.ShopKey);
            }
            //写入新购物车信息
            _accessor.HttpContext.Response.Cookies.Append(StaticString.ShopKey, Shopping.ToJson(), new CookieOptions
            {
                Expires = DateTime.Now.AddDays(int.Parse(StaticString.ShopDayTime))
            });
        }

        /// <summary>
        /// 批量删除购物车里的物品
        /// </summary>
        /// <param name="Guid"></param>
        public void DeleteShoppingCarts(List<string> Guid)
        {
            if (Guid != null)
            {
                //读取Cookies里的购物车信息
                var Shopping = ShoppingCart;
                Guid.ForEach(m =>
                {
                    Shopping.Remove(Shopping.Where(n => n.GUID == m).ToList()[0]);
                });

                //删除原购物车信息
                if (ShoppingCart != null && ShoppingCart.Count > 0)
                {
                    _accessor.HttpContext.Response.Cookies.Delete(StaticString.ShopKey);
                }
                //写入新购物车信息
                _accessor.HttpContext.Response.Cookies.Append(StaticString.ShopKey, Shopping.ToJson(), new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(int.Parse(StaticString.ShopDayTime))
                });
            }
        }

        /// <summary>
        /// 提交并清空购物车
        /// </summary>
        public void SubShoping()
        {
            //读取Cookies里的购物车信息
            var Shopping = ShoppingCart;
            //删除原购物车信息
            if (ShoppingCart != null && ShoppingCart.Count > 0)
            {
                _accessor.HttpContext.Response.Cookies.Delete(StaticString.ShopKey);
            }
        }
    }
}
