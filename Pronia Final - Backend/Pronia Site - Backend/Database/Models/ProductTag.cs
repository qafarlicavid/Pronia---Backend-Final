﻿using Pronia_Site___Backend.Database.Models.Common;

namespace Pronia_Site___Backend.Database.Models
{
    public class ProductTag : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
