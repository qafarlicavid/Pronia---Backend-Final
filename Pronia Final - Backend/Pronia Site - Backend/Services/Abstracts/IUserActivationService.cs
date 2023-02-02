using Pronia_Site___Backend.Database.Models;

namespace Pronia_Site___Backend.Services.Abstracts
{
    public interface IUserActivationService
    {
        Task SendActivationUrlAsync(User user);
    }
}
