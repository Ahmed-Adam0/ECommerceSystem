using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Enums;

namespace ECommerce.ApplicationLayer.DTOs.UserDtos
{
    public class CreateUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

    }
}
