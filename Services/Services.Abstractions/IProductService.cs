using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Contracts.Product;

namespace Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с проуктами.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Получить проукт. 
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО продукта. </returns>
        Task<ProductDto> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать проукт.
        /// </summary>
        /// <param name="creatingProductDto"> ДТО продукта. </param>
        /// <returns> Идентификатор. </returns>
        Task<int> CreateAsync(CreatingProductDto creatingProductDto);

        /// <summary>
        /// Изменить проукт.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingProductDto"> ДТО продукта. </param>
        Task UpdateAsync(int id, UpdatingProductDto updatingProductDto);

        /// <summary>
        /// Удалить проукт.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Получить список продуктов.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница продуктов. </returns>
        Task<ICollection<ProductDto>> GetPagedAsync(int page, int pageSize);
    }
}