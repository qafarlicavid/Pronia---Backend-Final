using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_Site___Backend.Areas.Client.ViewModels.Shop;
using Pronia_Site___Backend.Areas.Client.ViewModels.ShopPage;
using Pronia_Site___Backend.Contracts.File;
using Pronia_Site___Backend.Database;
using Pronia_Site___Backend.Services.Abstracts;

namespace Pronia_Site___Backend.Areas.Client.Controllers
{
    [Area("client")]
    [Route("shop")]
    public class ShopController : Controller
    {

        private readonly DataContext _dbContext;
        private readonly IFileService _fileService;
        public ShopController(DataContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }


        [HttpGet("index/{id}", Name = "client-shop-index")]
        public async Task<IActionResult> Index(int id)
        {
            var product = await _dbContext.Products.Include(p => p.Images)
                .Include(p => p.ProductColors)
                .Include(p => p.ProductSizes)
                .Include(p => p.ProductCategories)
                .Include(p => p.ProductTags).FirstOrDefaultAsync(p => p.Id == id);


            if (product is null)
            {
                return NotFound();
            }

            var catProducts = await _dbContext
                .ProductCategories.GroupBy(pc => pc.CategoryId).Select(pc => pc.Key).ToListAsync();


            var model = new ShopViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price.Value,

                Colors = _dbContext.ProductColors.Include(pc => pc.Color).Where(pc => pc.ProductId == product.Id)
                          .Select(pc => new ShopViewModel.ColorViewModel(pc.Color.Name, pc.Color.Id)).ToList(),

                Sizes = _dbContext.ProductSizes.Include(ps => ps.Size).Where(ps => ps.ProductId == product.Id)
                       .Select(ps => new ShopViewModel.SizeViewModel(ps.Size.Name, ps.Size.Id)).ToList(),

                Categories = _dbContext.ProductCategories.Include(ps => ps.Category).Where(ps => ps.ProductId == product.Id)
                         .Select(ps => new ShopViewModel.CategoryViewModel(ps.Category.Title, ps.Category.Id)).ToList(),

                Tags = _dbContext.ProductTags.Include(ps => ps.Tag).Where(ps => ps.ProductId == product.Id)
                      .Select(ps => new ShopViewModel.TagViewModel(ps.Tag.Title, ps.Tag.Id)).ToList(),

                Images = _dbContext.Images.Where(p => p.ProductId == product.Id)
                .Select(p => new ShopViewModel.ImageViewModel
                (_fileService.GetFileUrl(p.ImageNameInFileSystem, UploadDirectory.Product))).ToList(),

                Products = await _dbContext.ProductCategories
                .Include(p => p.Product)
                .Where(pc => pc.ProductId != product.Id)
                .Select(pc => new ListItemViewModel(pc.ProductId, pc.Product.Name, pc.Product.Price.Value, pc.Product.CreatedAt,


                pc.Product.Images.Take(1).FirstOrDefault() != null
                ? _fileService.GetFileUrl(pc.Product.Images.Take(1).FirstOrDefault().ImageNameInFileSystem, UploadDirectory.Product)
                : string.Empty,

                pc.Product.Images.Skip(1).Take(1).FirstOrDefault() != null
                ? _fileService.GetFileUrl(pc.Product.Images.Skip(1).Take(1).FirstOrDefault().ImageNameInFileSystem, UploadDirectory.Product)
                : string.Empty))
                
                .ToListAsync()

            };

            return View(model);
        }

    }
}