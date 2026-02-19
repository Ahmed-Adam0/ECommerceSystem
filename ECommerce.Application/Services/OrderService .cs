using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.ApplicationLayer.DTOs.OrderDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;

namespace ECommerce.ApplicationLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order, int> _orderRepo;
        private readonly IGenericRepository<OrderItem, int> _orderItemRepo;
        private readonly IGenericRepository<CartItem, int> _cartItemRepo;

        public OrderService(
            IGenericRepository<Order, int> orderRepo,
            IGenericRepository<OrderItem, int> orderItemRepo,
            IGenericRepository<CartItem, int> cartItemRepo)
        {
            _orderRepo = orderRepo;
            _orderItemRepo = orderItemRepo;
            _cartItemRepo = cartItemRepo;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetAll().ToList();
        }

  
        public void CreateOrder(int customerId)
        {
           
            var cartItems = _cartItemRepo.GetAll()
                .Where(ci => ci.UserId == customerId && !ci.IsOrdered)
                .ToList();

            if (!cartItems.Any())
                return; 

          
            var order = new Order()
            {
                UserId = customerId,
                Status = OrderStatus.Pending,
                OrderDate = DateTime.Now
            };
            _orderRepo.Add(order);

         
            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItem()
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity
                };
                _orderItemRepo.Add(orderItem);

              
                cartItem.IsOrdered = true;
                _cartItemRepo.Update(cartItem);
            }
        }

        public void UpdateOrder(UpdateOrderDto dto)
        {
            var order = _orderRepo.GetAll().FirstOrDefault(x => x.Id == dto.Id);
            if (order != null)
            {
                order.Status = dto.Status;
                _orderRepo.Update(order);
            }
        }

        public void DeleteOrder(int id)
        {
            var order = _orderRepo.GetAll().FirstOrDefault(x => x.Id == id);
            if (order != null)
                _orderRepo.Delete(order);
        }
    }
}
