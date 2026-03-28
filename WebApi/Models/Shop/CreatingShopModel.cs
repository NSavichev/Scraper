namespace WebApi.Models.Shop
{
    /// <summary>
    /// Модель создаваемого магазина.
    /// </summary>
    public class CreatingShopModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        public string ShopId { get; set; }      // строковое поле
        public string ShopUrl { get; set; }
        public bool IsAllScrap { get; set; }
    }
}