using Services.Contracts.Product;
using System.Collections.Generic;

namespace Services.Contracts.Shop
{
    /// <summary>
    /// ДТО редактируемого магазина.
    /// </summary>
    public class UpdatingShopDto
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// ссылка на магазин.
        /// </summary>
        public string ShopUrl { get; set; }
        
        public string ShopId { get; set; }
        public bool IsAllScrap { get; set; }
        public bool Deleted { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}