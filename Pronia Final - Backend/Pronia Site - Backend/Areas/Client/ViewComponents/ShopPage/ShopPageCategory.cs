using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_Site___Backend.Areas.Client.ViewModels.ShopPage;
using Pronia_Site___Backend.Contracts.File;
using Pronia_Site___Backend.Database;
using Pronia_Site___Backend.Services.Abstracts;
using static Pronia_Site___Backend.Areas.Client.ViewModels.ShopPage.ListItemViewModel;

namespace Pronia_Site___Backend.Areas.Client.ViewCompanents
{
    [ViewComponent(Name = "ShopPageCategory")]
    public class ShopPageCategory : ViewComponent
    {

        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        public ShopPageCategory(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dataContext.Categories.Select(c => new CategoryListItemViewModel(c.Id, c.Title)).ToListAsync();

            return View(model);
        }
    }

}
