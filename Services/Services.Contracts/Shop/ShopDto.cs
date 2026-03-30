using System.Collections.Generic;
using Services.Contracts.Product;

namespace Services.Contracts.Shop
{
    /// <summary>
    /// ДТО магазина.
    /// </summary>
    public class ShopDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// ссылка.
        /// </summary>
        public string ShopUrl { get; set; }

        /// <summary>
        /// продукты.
        /// </summary>
        public List<ProductDto> Products { get; set; }
        public bool IsAllScrap { get; set; }
        public bool Deleted { get; set; }
        public string ShopId { get; set; }
    }
}