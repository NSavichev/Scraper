using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Contracts.Shop;

namespace Services.Abstractions
{
	/// <summary>
	/// Интерфейс сервиса работы с магазинами.
	/// </summary>
	public interface IShopService
    {
		/// <summary>
		/// Получить магазин.
		/// </summary>
		/// <param name="id"> Идентификатор. </param>
		/// <returns> ДТО магазин. </returns>
		Task<ShopDto> GetByIdAsync(int id);

		/// <summary>
		/// Создать магазин.
		/// </summary>
		/// <param name="creatingShopDto"> ДТО создаваемого магазин. </param>
		Task<int> CreateAsync(CreatingShopDto creatingShopDto);

        /// <summary>
        /// Обновить магазин и состав продуктов.
        /// Для показа unit of work.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="updatingShopWithProductsDto"></param>
        Task UpdatingWithProductsAsync(int id, UpdatingShopWithProductsDto updatingShopWithProductsDto);

		/// <summary>
		/// Изменить магазин.
		/// </summary>
		/// <param name="id"> Иентификатор. </param>
		/// <param name="updatingShopDto"> ДТО редактируемого магазина. </param>
		Task UpdateAsync(int id, UpdatingShopDto updatingShopDto);

		/// <summary>
		/// Удалить магазин.
		/// </summary>
		/// <param name="id"> Идентификатор. </param>
		Task DeleteAsync(int id);

		/// <summary>
		/// Получить постраничный список.
		/// </summary>
		/// <param name="filterDto"> ДТО фильтра. </param>
		/// <returns> Список магазинов. </returns>
		Task<ICollection<ShopDto>> GetPagedAsync(ShopFilterDto filterDto);

        //Task<IEnumerable<ShopInfoDto>> GetCourseInfosAsync(string fieldsToSelect);
    }
}