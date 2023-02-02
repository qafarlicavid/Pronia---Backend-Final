namespace Pronia_Site___Backend.Areas.Admin.ViewModels.Tag
{
    public class ListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ListViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
