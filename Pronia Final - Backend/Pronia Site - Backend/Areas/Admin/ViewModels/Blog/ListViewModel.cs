namespace Pronia_Site___Backend.Areas.Admin.ViewModels.Blog
{
    public class ListViewModel
    {
        public ListViewModel(int id, string title, string content, Guid? adminId, string? adminName, string videoURL, List<Tag.ListViewModel>? tags)
        {
            Id = id;
            Title = title;
            Content = content;
            AdminId = adminId;
            AdminName = adminName;
            VideoURL = videoURL;
            Tags = tags;
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public Guid? AdminId { get; set; }
        public string? AdminName { get; set; }

        public string VideoURL { get; set; }
        public List<ViewModels.Tag.ListViewModel>? Tags { get; set; }
    }
}
