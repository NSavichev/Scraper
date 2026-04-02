using Domain.EF;
using Services.Contracts.ReportProduct;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{

    public interface IReportProductRepository : IRepository<ReportProduct, int>
    {
        /// <summary>
        /// Получить список карточек.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="itemsPerPage"> Количество элементов на странице. </param>
        /// <returns> Список карточек. </returns>
        Task<List<ReportProduct>> GetPagedAsync(int page, int itemsPerPage);
    }
}
