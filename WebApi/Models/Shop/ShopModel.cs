using System.Collections.Generic;
using WebApi.Models.Product;

namespace WebApi.Models.Shop
{
    /// <summary>
    /// Модель магазина.
    /// </summary>
    public class ShopModel
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        public string? ShopId { get; set; }
        public string? ShopUrl { get; set; }
        public bool IsAllScrap { get; set; }
        /// <summary>
        /// карточки.
        /// </summary>
        public virtual ICollection<ReportProductModel>? Products { get; set; }
        /// <summary>
        /// Удалено.
        /// </summary>
        public bool Deleted { get; set; }
    }
}