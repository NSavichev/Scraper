namespace Services.Contracts.Product
{
    /// <summary>
    /// ДТО карточки.
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }
    }
}