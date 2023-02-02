namespace Pronia_Site___Backend.Services.Abstracts
{
    public interface IOrderService
    {
        Task<string> GenerateUniqueTrackingCodeAsync();
    }
}
