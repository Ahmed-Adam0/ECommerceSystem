using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Models
{
    public abstract class BaseEntity<Tkey>
    {
        public Tkey Id { get; set; }

        public string? createdby { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;

        public string? updatedby { get; set; }
        public DateTime? updatedAt { get; set; }  // nullable

        public bool isdeleted { get; set; } = false;
    }
}
