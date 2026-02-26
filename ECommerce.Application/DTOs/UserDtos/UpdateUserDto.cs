using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ApplicationLayer.DTOs.UserDtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
