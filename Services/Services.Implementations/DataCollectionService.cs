using AutoMapper;
using Domain.EF;
using ExternalClients;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts.ExternalClients;
using Services.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class DataCollectionService : IDataCollectionService
    {
        private readonly IProductRepository _productRepository;      // репозиторий карточек
        private readonly IReportProductRepository _reportRepo;       // репозиторий отчётов
        private readonly IDataCollectionService _apiClient;
        private readonly IMapper _mapper;
        private readonly ILogger<DataCollectionService> _logger;

        public DataCollectionService(
            IProductRepository productRepository,
            IReportProductRepository reportRepo,
            IDataCollectionService apiClient,
            IMapper mapper,
            ILogger<DataCollectionService> logger)
        {
            _productRepository = productRepository;
            _reportRepo = reportRepo;
            _apiClient = apiClient;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ExternalCardDataDto> CollectAndSaveReportsAsync(int idProduct, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetAsync(idProduct, cancellationToken);

            try
            {
                var externalData = await _apiClient.GetContentProductAsync(product.ProductUrl, cancellationToken);               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сбора данных для продукта {ProductId}", product.Id);
            }

            return await _apiClient.GetContentProductAsync(product.ProductUrl, cancellationToken);
        }

        public Task<ExternalCardDataDto> GetContentProductAsync(string idCard, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
