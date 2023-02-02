﻿using Pronia_Site___Backend.Database.Models.Common;

namespace Pronia_Site___Backend.Database.Models
{
    public class PaymentBenefit : BaseEntity<int>, IAuditable
    {
        public string? Name { get; set; }
        public string? Content { get; set; }
        public string? ImageName { get; set; } //<original_name>.<extension>
        public string? ImageNameInFileSystem { get; set; } //Guid.<extension>

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
