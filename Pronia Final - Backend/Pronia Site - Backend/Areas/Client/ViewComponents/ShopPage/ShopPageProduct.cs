using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_Site___Backend.Contracts.File;
using Pronia_Site___Backend.Database;
using Pronia_Site___Backend.Services.Abstracts;
using Pronia_Site___Backend.Areas.Client.ViewModels.ShopPage;
using static Pronia_Site___Backend.Areas.Client.ViewModels.ShopPage.ListItemViewModel;

namespace Pronia_Site___Backend.Areas.Client.ViewCompanents
{
    [ViewComponent(Name = "ShopPageProduct")]
    public class ShopPageProduct : ViewComponent
    {

        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        public ShopPageProduct(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? searchBy = null, string? search = null, int? minPrice = null, int? maxPrice = null, [FromQuery] int? categoryId = null, [FromQuery] int? colorId = null, [FromQuery] int? tagId = null)
        {
            var productsQuery = _dataContext.Products.AsQueryable();

            if (searchBy == "Name")
            {
                productsQuery = productsQuery.Where(p => p.Name.StartsWith(search) || Convert.ToString(p.Price).StartsWith(search) || search == null);
            }
            else if (minPrice is not null && maxPrice is not null)
            {
                productsQuery = productsQuery.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
            }
            else if (categoryId is not null || colorId is not null || tagId is not null)
            {
                productsQuery = productsQuery.Include(p => p.ProductCategories)
                    .Include(p => p.ProductColors)
                    .Include(p => p.ProductTags)
                    .Where(p => categoryId == null || p.ProductCategories!.Any(pc => pc.CategoryId == categoryId))
                    .Where(p => colorId == null || p.ProductColors!.Any(pc => pc.ColorId == colorId))
                    .Where(p => tagId == null || p.ProductTags!.Any(pt => pt.TagId == tagId));

            }
            else
            {
                productsQuery = productsQuery.OrderBy(p => p.Price);
            }

            var newProduct = await productsQuery.Select(p => new ListItemViewModel(p.Id, p.Name, p.Description, p.Price.Value,
                               p.Images.Take(1).FirstOrDefault() != null
                               ? _fileService.GetFileUrl(p.Images.Take(1).FirstOrDefault()!.ImageNameInFileSystem, UploadDirectory.Product)
                               : string.Empty,
                                p.Images.Skip(1).Take(1).FirstOrDefault() != null
                               ? _fileService.GetFileUrl(p.Images.Skip(1).Take(1).FirstOrDefault()!.ImageNameInFileSystem, UploadDirectory.Product)
                               : string.Empty,
                                p.ProductCategories.Select(p => p.Category).Select(p => new CategoryViewModel(p.Title, p.Parent.Title)).ToList(),
                                p.ProductColors.Select(p => p.Color).Select(p => new ColorViewModel(p.Name)).ToList(),
                                p.ProductSizes.Select(p => p.Size).Select(p => new SizeViewModel(p.Name)).ToList(),
                                p.ProductTags.Select(p => p.Tag).Select(p => new TagViewModel(p.Title)).ToList()
                                )).ToListAsync();

            return View(newProduct);

        }
    }

}