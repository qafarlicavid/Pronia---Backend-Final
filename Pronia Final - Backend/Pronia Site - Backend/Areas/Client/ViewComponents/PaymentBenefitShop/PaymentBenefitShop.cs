using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_Site___Backend.Areas.Client.ViewModels.Home.Index;
using Pronia_Site___Backend.Contracts.File;
using Pronia_Site___Backend.Database;
using Pronia_Site___Backend.Services.Abstracts;

namespace Pronia_Site___Backend.Areas.Client.ViewCompanents
{
    [ViewComponent(Name = "PaymentBenefitShop")]
    public class PaymentBenefitShop : ViewComponent
    {

        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;

        public PaymentBenefitShop(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new IndexViewModel
            {
                PaymentBenefits = await _dataContext.PaymentBenefits.Select(p => new PaymentBenefitViewModel
                (p.Id, p.Name!, p.Content!, _fileService.GetFileUrl
                (p.ImageNameInFileSystem, UploadDirectory.PaymentBenefit))).ToListAsync()
            };



            return View(model);
        }
    }
}
