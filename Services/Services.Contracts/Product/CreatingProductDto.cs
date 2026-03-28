namespace Services.Contracts.Product
{
    /// <summary>
    /// ДТО магазина.
    /// </summary>
    public class CreatingProductDto
    {
        /// <summary>
        /// Идентификатор продукта.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор магазина.
        /// </summary>
        public int ShopId { get; set; }
        public string IdProduct2Shop { get; set; }
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int View { get; set; }
        public string ProductUrl { get; set; }
    }
}