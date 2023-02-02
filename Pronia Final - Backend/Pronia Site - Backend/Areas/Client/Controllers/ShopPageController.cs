using Microsoft.AspNetCore.Mvc;
using Pronia_Site___Backend.Areas.Client.ViewCompanents;
using Pronia_Site___Backend.Database;
using Pronia_Site___Backend.Services.Abstracts;

namespace Pronia_Site___Backend.Areas.Client.Controllers
{
    [Area("client")]
    [Route("shoppage")]
    public class ShopPageController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;


        public ShopPageController(DataContext dataContext, IBasketService basketService, IUserService userService, IFileService fileService)
        {
            _dataContext = dataContext;
            _basketService = basketService;
            _userService = userService;
            _fileService = fileService;
        }


        [HttpGet("index", Name = "client-shoppage-index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet("filter", Name = "client-shoppage-filter")]
        public async Task<IActionResult> Filter(string? searchBy = null,
            string? search = null, int? minPrice = null,
            int? maxPrice = null, [FromQuery] int? categoryId = null, [FromQuery] int? colorId = null, [FromQuery] int? tagId = null)
        {
            return ViewComponent(nameof(ShopPageProduct), new
            {
                searchBy = searchBy,
                search = search,
                minPrice = minPrice,
                maxPrice = maxPrice,
                categoryId = categoryId,
                colorId = colorId,
                tagId = tagId
            });
        }
    }
}
