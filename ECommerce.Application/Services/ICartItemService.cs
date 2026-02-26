using ECommerce.ApplicationLayer.DTOs.CartItemDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ApplicationLayer.Services
{
    public interface ICartItemService
    {
        List<CartItemDto> GetAllCartItems();
        Task CreateCartItemAsync(int userId, CreateCartItemDto dto); 
        void UpdateCartItem(UpdateCartItemDto dto);
        Task ChangeQuantityAsync(int userId, int productId, int delta);
        Task RemoveFromCartAsync(int userId, int productId);
        Task<CartItem?> GetCartItemAsync(int userId, int productId);
        Task<int> GetUserCartCountAsync(int userId);
        Task SaveChangesAsync();
        Task<List<CartItem>> GetUserCartAsync(int userId);
    }
}
