using Pronia_Site___Backend.Database.Models.Enums;

namespace Pronia_Site___Backend.Areas.Admin.ViewModels.BlogImage
{
    public class AddViewModel
    {
        public OrderStatus? Order { get; set; }
        public IFormFile? Image { get; set; }
    }
}
