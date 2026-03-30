using System;

namespace Services.Contracts.Product
{
    /// <summary>
    /// ДТО магазина.
    /// </summary>
    public class CreatingProductDto
    {
        // Идентификатор продукта.
        /// </summary>
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string IdProduct2Shop { get; set; }
        public string Name { get; set; }
        public string ProductUrl { get; set; }
        public int View { get; set; }
        public decimal Price { get; set; }
        public int ShopId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ScrapDate { get; set; }
        /// <summary>
        /// Удалено.
        /// </summary>
        public bool Deleted { get; set; }
    }
}