namespace Pronia_Site___Backend.Database.Models.Common
{
    public interface IAuditable
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
