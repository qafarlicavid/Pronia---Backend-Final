namespace Pronia_Site___Backend.Areas.Admin.ViewModels.Product
{
    public class SizeListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SizeListItemViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
