﻿using Pronia_Site___Backend.Database.Models.Common;

namespace Pronia_Site___Backend.Database.Models
{
    public class BlogImage : BaseEntity<int>, IAuditable
    {
        public string? ImageName { get; set; }
        public string? ImageNameInFileSystem { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int? BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
