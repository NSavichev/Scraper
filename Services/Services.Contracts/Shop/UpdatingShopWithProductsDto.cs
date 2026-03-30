using System.Collections.Generic;
using Services.Contracts.Product;

namespace Services.Contracts.Shop
{
    /// <summary>
    /// ДТО обновления магазина с изменением состава продуктов.
    /// </summary>
    public class UpdatingShopWithProductsDto
    {
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ссылка на магазин.
        /// </summary>
        public string ShopUrl { get; set; }

        public string ShopId { get; set; }
        public bool IsAllScrap { get; set; }
        public bool Deleted { get; set; }
        public IEnumerable<AttachingProductDto> Products { get; set; }
    }
}