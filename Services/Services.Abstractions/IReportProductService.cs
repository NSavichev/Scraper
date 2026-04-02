using Services.Contracts.Product;
using Services.Contracts.ReportProduct;
using Services.Contracts.Shop;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с проуктами.
    /// </summary>
    public interface IReportProductService
    {
        /// <summary>
        /// Получить проукт. 
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО продукта. </returns>
        Task<ReportProductDto> GetByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать проукт.
        /// </summary>
        /// <param name="creatingProductDto"> ДТО продукта. </param>
        /// <returns> Идентификатор. </returns>
        Task<int> CreateAsync(CreatingReportProductDto creatingProductDto);

        /// <summary>
        /// Изменить проукт.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingProductDto"> ДТО продукта. </param>
        Task UpdateAsync(int id, UpdatingReportProductDto updatingProductDto);

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
        Task<ICollection<ReportProductDto>> GetPagedAsync(int page, int pageSize);
    }
}