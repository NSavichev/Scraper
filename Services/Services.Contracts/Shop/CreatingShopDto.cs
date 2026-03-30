using Services.Contracts.Product;
using System.Collections.Generic;

namespace Services.Contracts.Shop
{
    /// <summary>
    /// ДТО магазина.
    /// </summary>
    public class CreatingShopDto
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        public string ShopId { get; set; }
        public string ShopUrl { get; set; }
        public bool IsAllScrap { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<ProductDto> Products { get; set; }
    }
}