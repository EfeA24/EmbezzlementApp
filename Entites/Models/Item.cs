using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string? ItemStockCode { get; set; }
        public string? ItemName{ get; set; }
        public string? ItemDescription{ get; set; }
        public string? ItemType{ get; set; }
        public int ItemCount{ get; set; }

    }
}
