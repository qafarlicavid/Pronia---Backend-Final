using Pronia_Site___Backend.Database.Models.Common;

namespace Pronia_Site___Backend.Database.Models
{
    public class SubNavbar : BaseEntity<int>
    {
        public string? Name { get; set; }
        public string? ToURL { get; set; }
        public int Order { get; set; }

        public int NavbarId { get; set; }
        public Navbar? Navbar { get; set; }

    }
}
