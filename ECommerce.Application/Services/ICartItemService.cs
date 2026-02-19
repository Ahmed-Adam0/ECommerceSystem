using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.DTOs.CartItemDtos;
using ECommerce.Domain.Entities;

namespace ECommerce.ApplicationLayer.Services
{
    public interface ICartItemService
    {
        List<CartItem> GetAllCartItems();
        void CreateCartItem(int userId, CreateCartItemDto dto);
        void UpdateCartItem(UpdateCartItemDto dto);
        void DeleteCartItem(int id);
    }
}
