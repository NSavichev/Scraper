using Domain.EF;
using Services.Contracts.Shop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Репозиторий работы с магазинами.
    /// </summary>
    public interface IShopRepository: IRepository<Shop, int>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список магазинов. </returns>
        Task<List<Shop>> GetPagedAsync(int page, int pageSize);

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        Task<List<Shop>> GetShopsInfosAsync(string fieldsToSelect);
    }
}
