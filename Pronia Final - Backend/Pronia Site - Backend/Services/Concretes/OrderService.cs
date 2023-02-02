using Microsoft.EntityFrameworkCore;
using Pronia_Site___Backend.Database;
using Pronia_Site___Backend.Services.Abstracts;

namespace Pronia_Site___Backend.Services.Concretes
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private const string ORDER_TRACKING_CODE = "OR";
        private const int ORDER_TRACKINH_MIN_RANGE = 10_000;
        private const int ORDER_TRACKINH_MAX_RANGE = 100_000;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateUniqueTrackingCodeAsync()
        {
            string token = string.Empty;
            do
            {
                token = GenerateRandomCode();

            } while (await _context.Orders.AnyAsync(o => o.Id == token));

            return token;
        }

        private string GenerateRandomCode()
        {
            return $"{ORDER_TRACKING_CODE}{Random.Shared.Next(ORDER_TRACKINH_MIN_RANGE, ORDER_TRACKINH_MAX_RANGE)}";
        }
    }
}
