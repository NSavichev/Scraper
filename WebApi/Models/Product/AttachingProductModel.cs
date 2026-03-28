namespace WebApi.Models.Product
{
    /// <summary>
    /// Модель прикладываемого продукта.
    /// </summary>
    public class AttachingProductModel
    {
        /// <summary>
        /// Тема.
        /// </summary>
        public string Name { get; set; }
        public string ShopId { get; set; }
    }
}