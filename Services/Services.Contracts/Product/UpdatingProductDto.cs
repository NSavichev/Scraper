using System;

namespace Services.Contracts.Product
{
    /// <summary>
    /// ДТО редактируемого урока.
    /// </summary>
    public class UpdatingProductDto
    {
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