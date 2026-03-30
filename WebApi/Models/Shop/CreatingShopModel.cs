using Services.Contracts.Product;
using System.Collections.Generic;

namespace WebApi.Models.Shop
{
    /// <summary>
    /// Модель создаваемого магазина.
    /// </summary>
    public class CreatingShopModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        public string ShopId { get; set; }      // строковое поле
        public string ShopUrl { get; set; }
        public bool IsAllScrap { get; set; }
        public bool Deleted { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}