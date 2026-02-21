using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Entities
{
    public class User:BaseEntity<int>
    {
        public string FullName { get; set; } = string.Empty;
        //public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // بسيط للتسليم
        public UserRole Role { get; set; } = UserRole.Customer;

        public List<Order> Orders { get; set; } = new();
        public List<CartItem> CartItems { get; set; } = new();
        public string Email { get; set; }
    }
}
