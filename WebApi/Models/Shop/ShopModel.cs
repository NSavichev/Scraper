using System.Collections.Generic;
using WebApi.Models.Product;

namespace WebApi.Models.Shop
{
    /// <summary>
    /// Модель курса.
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
        
        /// <summary>
        /// Уроки.
        /// </summary>
        public List<Product.ProductModel> Products { get; set; }
    }
}