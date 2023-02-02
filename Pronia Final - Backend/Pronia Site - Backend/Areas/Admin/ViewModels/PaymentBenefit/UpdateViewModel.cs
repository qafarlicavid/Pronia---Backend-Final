namespace Pronia_Site___Backend.Areas.Admin.ViewModels.PaymentBenefit
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public IFormFile? ImageName { get; set; }

        public string? ImageUrl { get; set; }
    }
}
