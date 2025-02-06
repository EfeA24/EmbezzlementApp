using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entites.Models;
using IdentityApp.Models;

namespace embezzlement.Models
{
    public class Embezzlement
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }

        public DateTime? HandoverDate { get; set; }
        public DateTime? ReturnTime { get; set; }
    }
}
