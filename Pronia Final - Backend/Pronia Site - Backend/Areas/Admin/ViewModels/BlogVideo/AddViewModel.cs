using Pronia_Site___Backend.Database.Models.Enums;

namespace Pronia_Site___Backend.Areas.Admin.ViewModels.BlogVideo
{
    public class AddViewModel
    {
        public OrderStatus? Order { get; set; }
        public IFormFile? Video { get; set; }
        public string? VideoURLFromBrowser { get; set; }
    }
}
