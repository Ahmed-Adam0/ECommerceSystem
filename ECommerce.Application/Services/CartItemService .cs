using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.DTOs.CartItemDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore; 



namespace ECommerce.ApplicationLayer.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IGenericRepository<CartItem, int> _cartItemRepo;
        private readonly IGenericRepository<User, int> _userRepo; // نضيف UserRepo


        public CartItemService(
      IGenericRepository<CartItem, int> cartItemRepo,
      IGenericRepository<User, int> userRepo) // استلامه بالكونستركتور
        {
            _cartItemRepo = cartItemRepo;
            _userRepo = userRepo;
        }

        public List<CartItemDto> GetAllCartItems()
        {
            return _cartItemRepo.GetAll()
                .Select(c => new CartItemDto
                {
                    Id = c.Id,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    UserId = c.UserId,
                    IsOrdered = c.IsOrdered
                })
                .ToList();
        }



        public async Task CreateCartItemAsync(int userId, CreateCartItemDto dto)
        {
            var user = await _userRepo.GetAll().FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                throw new Exception("User not found");

            var entity = new CartItem()
            {
                UserId = userId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                IsOrdered = false
            };

            _cartItemRepo.Add(entity);
            await _cartItemRepo.SaveChangesAsync();
        }

        public void UpdateCartItem(UpdateCartItemDto dto)
        {
            var entity = _cartItemRepo.GetAll()
                                      .FirstOrDefault(x => x.Id == dto.Id && !x.IsOrdered);
            if (entity != null)
            {
                entity.Quantity = dto.Quantity;
                _cartItemRepo.Update(entity);
            }
        }


        public async Task<CartItem?> GetCartItemAsync(int userId, int productId)
        {
            return await _cartItemRepo.GetAll()
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId && !c.IsOrdered);
        }

        public async Task<int> GetUserCartCountAsync(int userId)
        {
            return await _cartItemRepo.GetAll()
                .CountAsync(c => c.UserId == userId && !c.IsOrdered);
        }

        public async Task SaveChangesAsync()
        {
            await _cartItemRepo.SaveChangesAsync();
        }

        public async Task<List<CartItem>> GetUserCartAsync(int userId)
        {
            return await _cartItemRepo.GetAll()
                 .Include(c => c.Product)
                .Where(c => c.UserId == userId && !c.IsOrdered)
                .ToListAsync();
        }

        public async Task ChangeQuantityAsync(int userId, int productId, int delta)
        {
            var item = await _cartItemRepo
                .GetAll()
                .FirstOrDefaultAsync(c =>
                    c.UserId == userId &&
                    c.ProductId == productId &&
                    !c.IsOrdered);

            if (item == null) return;

            item.Quantity += delta;

            if (item.Quantity <= 0)
                _cartItemRepo.Delete(item);
            else
                _cartItemRepo.Update(item);

            await _cartItemRepo.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(int userId, int productId)
        {
            var item = await _cartItemRepo
                .GetAll()
                .FirstOrDefaultAsync(c =>
                    c.UserId == userId &&
                    c.ProductId == productId &&
                    !c.IsOrdered);

            if (item == null) return;

            _cartItemRepo.Delete(item);
            await _cartItemRepo.SaveChangesAsync();
        }
    }
}