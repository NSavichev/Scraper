using System;

namespace Services.Contracts.Product
{
    /// <summary>
    /// ДТО прикладываемого продукта.
    /// </summary>
    public class AttachingProductDto
    {
        public int ShopId { get; set; }
        /// <summary>
        /// наименование.
        /// </summary>
        public string Name { get; set; }
        public string IdProduct2Shop { get; set; }       
        public string ProductUrl { get; set; }
        public int View { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ScrapDate { get; set; }
        /// <summary>
        /// Удалено.
        /// </summary>
        public bool Deleted { get; set; }
    }
}