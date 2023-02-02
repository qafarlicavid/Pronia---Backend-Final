using Pronia_Site___Backend.Areas.Client.ViewModels.Basket;
using Pronia_Site___Backend.Database.Models;

namespace Pronia_Site___Backend.Services.Abstracts
{
    public interface IBasketService
    {
        Task<List<BasketCookieViewModel>> AddBasketProductAsync(Product product);
    }
}
