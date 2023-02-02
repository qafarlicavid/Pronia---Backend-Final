using Pronia_Site___Backend.Areas.Client.ViewModels.ShopPage;

namespace Pronia_Site___Backend.Areas.Client.ViewModels.Shop
{
    public class ShopViewModel
    {
        public ShopViewModel(string name, string description, decimal price, List<ColorViewModel> colors, List<SizeViewModel> sizes, List<CategoryViewModel> catagories, List<TagViewModel> tags, List<ImageViewModel> images, List<ListItemViewModel> products)
        {
            Name = name;
            Description = description;
            Price = price;
            Colors = colors;
            Sizes = sizes;
            Categories = catagories;
            Tags = tags;
            Images = images;
            Products = products;
        }
        public ShopViewModel()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<ColorViewModel> Colors { get; set; }
        public List<SizeViewModel> Sizes { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public List<TagViewModel> Tags { get; set; }
        public List<ImageViewModel> Images { get; set; }

        public List<ListItemViewModel> Products { get; set; }



        public class ImageViewModel
        {
            public ImageViewModel(string imageUrl)
            {
                ImageUrl = imageUrl;
            }
            public string ImageUrl { get; set; }
        }



        public class CategoryViewModel
        {
            public CategoryViewModel(string title, int id)
            {
                Title = title;
                Id = id;
            }

            public int Id { get; set; }
            public string Title { get; set; }
        }
        public class TagViewModel
        {
            public TagViewModel(string title, int id)
            {
                Title = title;
                Id = id;
            }

            public int Id { get; set; }
            public string Title { get; set; }
        }

        public class SizeViewModel
        {
            public SizeViewModel(string name, int id)
            {
                Name = name;
                Id = id;
            }

            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class ColorViewModel
        {
            public ColorViewModel(string name, int id)
            {
                Name = name;
                Id = id;
            }
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}
