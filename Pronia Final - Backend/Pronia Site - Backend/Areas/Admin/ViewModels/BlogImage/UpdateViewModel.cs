using Pronia_Site___Backend.Database.Models.Enums;

namespace Pronia_Site___Backend.Areas.Admin.ViewModels.BlogImage
{
    public class UpdateViewModel
    {
        public string? ImageUrL { get; set; }
        public OrderStatus? Order { get; set; }
        public IFormFile? Image { get; set; }
    }
}
