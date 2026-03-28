using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.EF;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Репозиторий работы с карточками.
    /// </summary>
    public interface IProductRepository : IRepository<Product, int>
    {
        /// <summary>
        /// Получить список карточек.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="itemsPerPage"> Количество элементов на странице. </param>
        /// <returns> Список карточек. </returns>
        Task<List<Product>> GetPagedAsync(int page, int itemsPerPage);
    }
}
