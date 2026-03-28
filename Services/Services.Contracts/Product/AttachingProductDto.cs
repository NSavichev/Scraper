namespace Services.Contracts.Product
{
    /// <summary>
    /// ДТО прикладываемого продукта.
    /// </summary>
    public class AttachingProductDto
    {
        public int ShopId { get; set; }
        /// <summary>
        /// Тема.
        /// </summary>
        public string Name { get; set; }
    }
}