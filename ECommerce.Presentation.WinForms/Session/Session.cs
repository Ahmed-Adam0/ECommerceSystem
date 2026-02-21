using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Enums;

namespace ECommerce.Presentation.WinForms.Session
{
    public static class Session
    {
        public static int CurrentUserId { get; set; }
        public static UserRole CurrentRole { get; set; }
    }
}
