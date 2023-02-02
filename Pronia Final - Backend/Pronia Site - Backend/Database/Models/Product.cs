﻿using Pronia_Site___Backend.Database.Models.Common;

namespace Pronia_Site___Backend.Database.Models
{
    public class Product : BaseEntity<int>, IAuditable
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }

        public int? Rate { get; set; }
        public string? Description { get; set; }

        public string? ImageName { get; set; } //<original_name>.<extension>
        public string? ImageNameInFileSystem { get; set; } //Guid.<extension>

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Image>? Images { get; set; }
        public List<ProductCategory>? ProductCategories { get; set; }
        public List<ProductColor>? ProductColors { get; set; }
        public List<ProductSize>? ProductSizes { get; set; }
        public List<BasketProduct>? BasketProducts { get; set; }
        public List<ProductTag>? ProductTags { get; set; }

    }
}
