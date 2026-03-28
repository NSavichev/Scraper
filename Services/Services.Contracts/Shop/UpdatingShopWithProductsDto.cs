using System.Collections.Generic;
using Services.Contracts.Product;

namespace Services.Contracts.Shop
{
    /// <summary>
    /// ДТО обновления магазина с изменением состава продуктов.
    /// </summary>
    public class UpdatingShopWithProductsDto
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// ссылкана магазин.
        /// </summary>
        public string ShopUrl { get; set; }
        
        /// <summary>
        /// Продукты
        /// </summary>
        public IEnumerable<AttachingProductDto> Products { get; set; }
    }
}