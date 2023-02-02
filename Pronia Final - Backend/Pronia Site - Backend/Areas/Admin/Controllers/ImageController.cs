using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_Site___Backend.Areas.Admin.ViewModels.Image;
using Pronia_Site___Backend.Contracts.File;
using Pronia_Site___Backend.Database;
using Pronia_Site___Backend.Database.Models;
using Pronia_Site___Backend.Services.Abstracts;

namespace Pronia_Site___Backend.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/image")]
    //[Authorize(Roles = "admin")]
    public class ImageController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
            
        public ImageController(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }
        #region List
        [HttpGet("{productId}/list", Name = "admin-image-list")]
        public async Task<IActionResult> List([FromRoute] int productId)
        {
            var product = await _dataContext.Products.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null) return NotFound();

            var model = new ImageViewModel { ProductId = product.Id };

            model.Images = product.Images.Select(p => new ImageViewModel.ListItem
            {
                Id = p.Id,
                ImageUrl = _fileService.GetFileUrl(p.ImageNameInFileSystem, UploadDirectory.Product),
                CreatedAt = p.CreatedAt
            }).ToList();

            return View(model);
        }
        #endregion

        #region Add

        [HttpGet("{productId}/image/add", Name = "admin-image-add")]
        public async Task<IActionResult> Add()
        {
            return View(new AddViewModel());
        }

        [HttpPost("{productId}/image/add", Name = "admin-image-add")]
        public async Task<IActionResult> Add([FromRoute] int productId, AddViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var product = await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (product is null)
            {
                return NotFound();
            }

            var imageNameInSystem = await _fileService.UploadAsync(model.Image!, UploadDirectory.Product);

            var productImage = new Image
            {
                Products = product,
                ImageName = model.Image!.FileName,
                ImageNameInFileSystem = imageNameInSystem,
            };

            await _dataContext.Images.AddAsync(productImage);

            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-image-list", new { productId = productId });

        }
        #endregion


        #region Delete
        [HttpPost("{productId}/image/{productImageId}/delete", Name = "admin-image-delete")]
        public async Task<IActionResult> Delete([FromRoute] int productId, [FromRoute] int productImageId)
        {

            var productImage = await _dataContext.Images.FirstOrDefaultAsync(p => p.ProductId == productId && p.Id == productImageId);

            if (productImage is null)
            {
                return NotFound();
            }

            await _fileService.DeleteAsync(productImage.ImageNameInFileSystem, UploadDirectory.Product);

            _dataContext.Images.Remove(productImage);

            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-image-list", new { productId = productId });

        }
        #endregion
    }
}
