using Model.HardwareMall;
using System.Collections.Generic;

namespace HardwareMall.Web
{
    /// <summary>
    /// 购物车相关
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// 购物车对象
        /// </summary>
        List<ShoppingCartDto> ShoppingCart { get; }

        /// <summary>
        /// 增加至购物车
        /// </summary>
        /// <param name="dto"></param>
        void AddShoppingCarts(ShoppingCartDto dto);


        /// <summary>
        /// 删除购物车里的物品
        /// </summary>
        /// <param name="Guid"></param>
        void DeleteShoppingCarts(string Guid);

        /// <summary>
        /// 批量删除购物车里的物品
        /// </summary>
        /// <param name="Guid"></param>
        void DeleteShoppingCarts(List<string> Guid);


        /// <summary>
        /// 提交并清空购物车
        /// </summary>
        void SubShoping();
    }
}
