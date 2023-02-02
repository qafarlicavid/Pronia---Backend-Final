namespace Pronia_Site___Backend.Areas.Admin.ViewModels.Image
{

    public class ImageViewModel
    {
        public int ProductId { get; set; }
        public List<ListItem>? Images { get; set; }

        public class ListItem
        {
            public int Id { get; set; }
            public string? ImageUrl { get; set; }
            public DateTime CreatedAt { get; set; }
        }
    }
}
