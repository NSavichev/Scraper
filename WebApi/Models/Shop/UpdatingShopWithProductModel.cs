using Services.Contracts.Product;
using System.Collections.Generic;
using WebApi.Models.Product;

namespace WebApi.Models.Shop
{
    /// <summary>
    /// Модель обновления магазина с изменением состава продуктов.
    /// </summary>
    public class UpdatingShopWithProductModel
    {
        public string Name { get; set; }
        public string ShopId { get; set; }      // строковое поле
        public string ShopUrl { get; set; }
        public bool IsAllScrap { get; set; }
        public bool Deleted { get; set; }
        public IEnumerable<AttachingProductDto> Products { get; set; }
    }
}