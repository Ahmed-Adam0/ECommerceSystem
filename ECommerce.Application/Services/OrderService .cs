using ECommerce.ApplicationLayer.DTOs.OrderDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task CreateOrderAsync(Order order)
        {
            // 1️⃣ أضف الأوردر أولًا
            _orderRepo.Add(order);
            await SaveChangesAsync(); // مهم جدًا لتوليد Id

            // 2️⃣ أضف كل الـ OrderItems
            var cartItems = _cartItemRepo.GetAll()
                .Where(ci => ci.UserId == order.UserId && !ci.IsOrdered)
                .ToList();

            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.Price
                };
                _orderItemRepo.Add(orderItem);

                cartItem.IsOrdered = true;
                _cartItemRepo.Update(cartItem);
            }

            await SaveChangesAsync();
        }

        public void DeleteOrder(int orderId)
        {
            var order = _orderRepo.GetAll().FirstOrDefault(o => o.Id == orderId);
            if (order != null)
                _orderRepo.Delete(order);
        }

        public Order? GetOrderById(int orderId)
        {
            return _orderRepo.GetAll().FirstOrDefault(o => o.Id == orderId);
        }

        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            return _orderRepo.GetAll().Where(o => o.UserId == userId).ToList();
        }

        public void AddOrderItem(OrderItem item)
        {
            _orderItemRepo.Add(item);
        }

        public async Task SaveChangesAsync()
        {
            await _orderRepo.SaveChangesAsync();
            await _orderItemRepo.SaveChangesAsync();
            await _cartItemRepo.SaveChangesAsync();
        }
        public List<OrderDto> GetAllOrders()
        {
            return _orderRepo.GetAll()
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    CustomerName = o.User.FullName,
                    TotalPrice = o.TotalPrice,
                    OrderDate = o.OrderDate,
                    Status = o.Status.ToString()
                })
                .ToList();
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

    }
}