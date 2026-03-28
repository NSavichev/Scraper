using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EF
{
    public class Shop : IEntity<int>
    {
        public int Id { get; set; }
        public string? ShopId { get; set; }
        public string? Name { get; set; }
        public string? ShopUrl { get; set; }
        public bool IsAllScrap { get; set; }
        /// <summary>
        /// карточки.
        /// </summary>
        public virtual ICollection<Product>? Products { get; set; }
        /// <summary>
        /// Удалено.
        /// </summary>
        public bool Deleted { get; set; }

    }
}
