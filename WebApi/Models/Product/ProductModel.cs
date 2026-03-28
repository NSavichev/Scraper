namespace WebApi.Models.Product
{
    public class ProductModel
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }
        public int ShopId { get; set; }
        
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}