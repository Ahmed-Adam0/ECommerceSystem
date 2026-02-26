using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Enums;

namespace ECommerce.ApplicationLayer.DTOs.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

    }
}
