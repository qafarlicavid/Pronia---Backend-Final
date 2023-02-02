using Pronia_Site___Backend.Database.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pronia_Site___Backend.Areas.Admin.ViewModels.Order
{
    public class UpdateViewModel
    {
        public string Id { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
    }
}
