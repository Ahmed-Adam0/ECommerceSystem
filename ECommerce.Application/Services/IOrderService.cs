using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.DTOs.OrderDtos;
using ECommerce.Domain.Entities;

namespace ECommerce.ApplicationLayer.Services
{
    public interface IOrderService
    {
        List<OrderDto> GetAllOrders();
        void CreateOrder(int customerId);
        void UpdateOrder(UpdateOrderDto dto);
        void DeleteOrder(int id);
    }
}
