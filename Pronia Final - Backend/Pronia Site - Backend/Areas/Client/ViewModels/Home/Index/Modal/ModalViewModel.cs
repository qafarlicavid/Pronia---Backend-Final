namespace Pronia_Site___Backend.Areas.Client.ViewModels.Home.Index.Modal
{
    public class ModalViewModel
    {
        public ModalViewModel(string title, string description, decimal price, string imgUrl, List<ColorViewModel> colors, List<SizeViewModel> sizes)
        {
            Title = title;
            Description = description;
            Price = price;
            ImgUrl = imgUrl;
            Colors = colors;
            Sizes = sizes;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public List<ColorViewModel> Colors { get; set; }
        public List<SizeViewModel> Sizes { get; set; }


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
