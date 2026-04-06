using Services.Contracts.ExternalClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IDataCollectionService
    {
        /// <summary>
        /// Собрать данные для всех (или выбранных) карточек и сохранить в таблицу отчётов.
        /// </summary>
        Task<ExternalCardDataDto> GetContentProductAsync(string idCard, CancellationToken cancellationToken = default);
    }
}
