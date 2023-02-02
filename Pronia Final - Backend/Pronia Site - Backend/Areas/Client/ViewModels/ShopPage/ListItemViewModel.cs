namespace Pronia_Site___Backend.Areas.Client.ViewModels.ShopPage
{
    public class ListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string MainImgUrl { get; set; }
        public string HoverImgUrl { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public List<ColorViewModel> Colors { get; set; }
        public List<SizeViewModel> Sizes { get; set; }
        public List<TagViewModel> Tags { get; set; }

        public ListItemViewModel(int id, string name, string description, decimal price,
            string mainImgUrl, string hoverImgUrl, List<CategoryViewModel> categories,
            List<ColorViewModel> colors, List<SizeViewModel> sizes, List<TagViewModel> tags)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            MainImgUrl = mainImgUrl;
            HoverImgUrl = hoverImgUrl;
            Categories = categories;
            Colors = colors;
            Sizes = sizes;
            Tags = tags;
        }


        public ListItemViewModel() { }

        public ListItemViewModel(int id, string name, decimal price, DateTime createdAt, string mainImgUrl, string hoverImgUrl)
        {
            Id = id;
            Name = name;
            Price = price;
            CreatedAt = createdAt;
            MainImgUrl = mainImgUrl;
            HoverImgUrl = hoverImgUrl;
        }

        public class CategoryViewModel
        {
            public CategoryViewModel(string title, string parentTitle)
            {
                Title = title;
                ParentTitle = parentTitle;
            }

            public string Title { get; set; }
            public string ParentTitle { get; set; }


        }
        public class SizeViewModel
        {
            public SizeViewModel(string name)
            {
                Name = name;
            }

            public string Name { get; set; }
        }
        public class ColorViewModel
        {
            public ColorViewModel(string name)
            {
                Name = name;
            }

            public string Name { get; set; }
        }
        public class TagViewModel
        {
            public TagViewModel(string title)
            {
                Title = title;
            }

            public string Title { get; set; }
        }
    }
}
