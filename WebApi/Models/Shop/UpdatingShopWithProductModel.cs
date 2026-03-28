using System.Collections.Generic;
using WebApi.Models.Product;

namespace WebApi.Models.Shop
{
    /// <summary>
    /// Модель обновления магазина с изменением состава продуктов.
    /// </summary>
    public class UpdatingShopWithProductModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Стоимость.
        /// </summary>
        public string ShopUrl { get; set; }
        
        /// <summary>
        /// Уроки.
        /// </summary>
        public IEnumerable<AttachingProductModel> Products { get; set; }
    }
}