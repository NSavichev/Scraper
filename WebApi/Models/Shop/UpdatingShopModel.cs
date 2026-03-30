using Services.Contracts.Product;
using System.Collections.Generic;

namespace WebApi.Models.Shop
{
    /// <summary>
    /// Модель редактируемого магазина.
    /// </summary>
    public class UpdatingShopModel
    {
        public string Name { get; set; }
        public string ShopId { get; set; }      // строковое поле
        public string ShopUrl { get; set; }
        public bool IsAllScrap { get; set; }
        public bool Deleted { get; set; }
        public List<ProductDto> Products { get; set; }

    }
}