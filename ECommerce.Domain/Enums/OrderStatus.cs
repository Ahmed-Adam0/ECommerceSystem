using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Models;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 1,
        Processing = 2,
        Delivered = 3
    }
}
