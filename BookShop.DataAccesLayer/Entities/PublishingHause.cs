using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Entities
{
    public class PublishingHause
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public byte[] Logo { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
