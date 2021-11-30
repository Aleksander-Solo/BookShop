using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }

        public byte[] Picture { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; } = 3;
        public virtual Role Role { get; set; }

        public ICollection<PurchaseHistory> PurchasesHistorie { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
