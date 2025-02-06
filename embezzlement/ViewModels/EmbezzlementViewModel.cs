using Entites.Models;
using IdentityApp.Models;

namespace embezzlement.ViewModels
{
    public class EmbezzlementViewModel
    {
        public Item Item { get; set; } = new Item();
        public string ItemName => Item.ItemName ?? string.Empty;

        public AppUser AppUser { get; set; } = new AppUser();
        public string User => AppUser.Id;

        public DateTime? HandoverDate { get; set; }
        public DateTime? ReturnTime { get; set; }
    }
}
