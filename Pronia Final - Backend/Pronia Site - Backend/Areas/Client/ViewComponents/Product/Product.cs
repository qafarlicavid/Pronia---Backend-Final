using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_Site___Backend.Areas.Client.ViewModels.Home.Index;
using Pronia_Site___Backend.Contracts.File;
using Pronia_Site___Backend.Database;
using Pronia_Site___Backend.Services.Abstracts;

namespace Pronia_Site___Backend.Areas.Client.ViewCompanents
{
    [ViewComponent(Name = "Product")]
    public class Product : ViewComponent
    {

        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        public Product(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string slide)
        {
            if (slide == "NewProduct")
            {
                var newProduct = new IndexViewModel
                {
                    Products = await _dataContext.Products.OrderByDescending(p => p.CreatedAt).Take(4).Select(p => new ProductListItemViewModel(p.Id, p.Name, p.Description, p.Price.Value, p.CreatedAt,
                    p.Images!.Take(1).FirstOrDefault() != null
                    ? _fileService.GetFileUrl(p.Images.Take(1).FirstOrDefault()!.ImageNameInFileSystem, UploadDirectory.Product)
                    : string.Empty,
                       p.Images!.Skip(1).Take(1).FirstOrDefault() != null
                    ? _fileService.GetFileUrl(p.Images.Skip(1).Take(1).FirstOrDefault()!.ImageNameInFileSystem, UploadDirectory.Product)
                    : string.Empty)).ToListAsync()
                };

                return View(newProduct);
            }
            var model = new IndexViewModel
            {
                Products = await _dataContext.Products.Take(7).Select(p => new ProductListItemViewModel(p.Id, p.Name, p.Description, p.Price.Value, p.CreatedAt,
                    p.Images!.Take(1).FirstOrDefault() != null
                    ? _fileService.GetFileUrl(p.Images.Take(1).FirstOrDefault()!.ImageNameInFileSystem, UploadDirectory.Product)
                    : string.Empty,
                       p.Images!.Skip(1).Take(1).FirstOrDefault() != null
                    ? _fileService.GetFileUrl(p.Images.Skip(1).Take(1).FirstOrDefault()!.ImageNameInFileSystem, UploadDirectory.Product)
                    : string.Empty)).ToListAsync()
            };

            return View(model);
        }
    }
}