using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_Site___Backend.Areas.Client.ViewModels.Home.Contact;
using Pronia_Site___Backend.Areas.Client.ViewModels.Home.Index;
using Pronia_Site___Backend.Areas.Client.ViewModels.Home.Index.Modal;
using Pronia_Site___Backend.Contracts.File;
using Pronia_Site___Backend.Database;
using Pronia_Site___Backend.Database.Models;
using Pronia_Site___Backend.Services.Abstracts;

namespace Pronia_Site___Backend.Areas.Client.Controllers
{
    [Area("client")]
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly DataContext _dbContext;
        private readonly IFileService _fileService;
        public HomeController(DataContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }

        [HttpGet("~/", Name = "client-home-index")]
        [HttpGet("index")]
        public async Task<IActionResult> IndexAsync([FromServices] IFileService fileService)
        {
            var model = new IndexViewModel
            {
                Sliders = await _dbContext.Sliders.OrderBy(s => s.Order).Select(s => new SliderListItemViewModel(s.Id, s.MainTitle!, s.Content!,
                s.Button!,
                s.ButtonRedirectUrl!,
                fileService.GetFileUrl(s.BackgroundİmageInFileSystem, UploadDirectory.Slider),
                s.Order))
                .ToListAsync(),
            };



            return View(model);
        }

        [HttpGet("GetModel/{id}", Name = "Product-GetModel")]
        public async Task<ActionResult> GetModelAsync(int id)
        {
            var product = await _dbContext.Products.Include(p => p.Images)
                .Include(p => p.ProductColors)
                .Include(p => p.ProductSizes).FirstOrDefaultAsync(p => p.Id == id);


            if (product is null)
            {
                return NotFound();
            }

            var model = new ModalViewModel(product.Name, product.Description, product.Price.Value,
                product.Images!.Take(1).FirstOrDefault() != null
                ? _fileService.GetFileUrl(product.Images.Take(1).FirstOrDefault()!.ImageNameInFileSystem, UploadDirectory.Product)
                : String.Empty,
                _dbContext.ProductColors.Include(pc => pc.Color).Where(pc => pc.ProductId == product.Id)
                .Select(pc => new ModalViewModel.ColorViewModel(pc.Color.Name, pc.Color.Id)).ToList(),
                _dbContext.ProductSizes.Include(ps => ps.Size).Where(ps => ps.ProductId == product.Id)
                .Select(ps => new ModalViewModel.SizeViewModel(ps.Size.Name, ps.Size.Id)).ToList()
                );

            return PartialView("~/Areas/Client/Views/Shared/Partials/_ProductModelPartial.cshtml", model);
        }





        #region Contact

        [HttpGet("contact")]
        public async Task<IActionResult> ContactAsync()
        {
            return View();
        }

        [HttpPost("contact")]
        public async Task<IActionResult> ContactAsync([FromForm] CreateViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _dbContext.Contacts.AddAsync(new Contact
            {
                Name = contactViewModel.Name,
                Email = contactViewModel.Email,
                Message = contactViewModel.Message,
                Phone = contactViewModel.Phone,
                CreatedAt = DateTime.Now
            });

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(IndexAsync));
        } 

        #endregion
    }
}
