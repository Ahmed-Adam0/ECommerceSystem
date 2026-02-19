using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.DTOs.CartItemDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.Domain.Entities;

namespace ECommerce.ApplicationLayer.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IGenericRepository<CartItem, int> _cartItemRepo;

        public CartItemService(IGenericRepository<CartItem, int> cartItemRepo)
        {
            _cartItemRepo = cartItemRepo;
        }

        public List<CartItem> GetAllCartItems()
        {
            return _cartItemRepo.GetAll()
                                .Where(ci => !ci.IsOrdered)
                                .ToList();
        }


        public void CreateCartItem(int userId, CreateCartItemDto dto)
        {
            var entity = new CartItem()
            {
                UserId = userId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                IsOrdered = false 
            };
            _cartItemRepo.Add(entity);
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


        public void DeleteCartItem(int id)
        {
            var entity = _cartItemRepo.GetAll()
                                      .FirstOrDefault(x => x.Id == id && !x.IsOrdered);
            if (entity != null)
                _cartItemRepo.Delete(entity);
        }

    }
}