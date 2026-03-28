namespace WebApi.Models.Product
{
    public class CreatingProductModel
    {
        /// <summary>
        /// Идентификатор продукта.
        /// </summary>
        public int ProductId { get; set; }

        public string IdProduct2Shop { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        public int ShopId { get; set; }
    }
}