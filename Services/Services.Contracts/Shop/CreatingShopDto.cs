namespace Services.Contracts.Shop
{
    /// <summary>
    /// ДТО магазина.
    /// </summary>
    public class CreatingShopDto
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        
        
        public string ShopId { get; set; }
        public string ShopUrl { get; set; }
        public bool IsAllScrap { get; set; }
    }
}