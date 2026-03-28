namespace Services.Contracts.Shop
{
    /// <summary>
    /// ДТО редактируемого магазина.
    /// </summary>
    public class UpdatingShopDto
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// ссылка на магазин.
        /// </summary>
        public string ShopUrl { get; set; }
    }
}