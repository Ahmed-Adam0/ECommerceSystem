using ECommerce.ApplicationLayer.DTOs.OrderDtos;
using ECommerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.ApplicationLayer.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order); // async مع body في service
        void DeleteOrder(int orderId);
        Task SaveChangesAsync();

        Order? GetOrderById(int orderId);
        IEnumerable<Order> GetOrdersByUserId(int userId);

        void AddOrderItem(OrderItem item);
        public void UpdateOrder(UpdateOrderDto dto);
        public List<OrderDto> GetAllOrders();


    }
}