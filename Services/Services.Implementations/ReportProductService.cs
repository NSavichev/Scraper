using AutoMapper;
using CommonNamespace;
using Domain.EF;
using MassTransit;
using Services.Abstractions;
using Services.Contracts.ReportProduct;
using Services.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Implementations
{
    /// <summary>
    /// Cервис работы с магазином.
    /// </summary>
    public class ReportProductService : IReportProductService
    {
        private readonly IMapper _mapper;
        private readonly IReportProductRepository _reportProductRepository;
        private readonly IBusControl _busControl;
        private readonly IUnitOfWork _unitOfWork;

        public ReportProductService(
            IMapper mapper,
            IReportProductRepository shopRepository,
            IUnitOfWork unitOfWork,
            IBusControl busControl)
        {
            _mapper = mapper;
            _reportProductRepository = shopRepository;
            _busControl = busControl;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Получить продукт.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО продукта. </returns>
        public async Task<ReportProductDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _reportProductRepository.GetAsync(id, cancellationToken);
            return _mapper.Map<ReportProduct, ReportProductDto>(product);
        }

        /// <summary>
        /// Создать продукт.
        /// </summary>
        /// <param name="creatingProductDto"> ДТО пародукта. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<int> CreateAsync(CreatingReportProductDto creatingProductDto)
        {
            var product = _mapper.Map<CreatingReportProductDto, ReportProduct>(creatingProductDto);
            product.Id = creatingProductDto.Id;
            var createdLesson = await _reportProductRepository.AddAsync(product);
            await _reportProductRepository.SaveChangesAsync();
            await _busControl.Publish(new MessageDto
            {
                Content = $"Lesson {createdLesson.Id} with subject {createdLesson.Id} is added"
            });

            return createdLesson.Id;
        }

        /// <summary>
        /// Изменить продукт.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingProductDto"> ДТО продукта. </param>
        public async Task UpdateAsync(int id, UpdatingReportProductDto updatingProductDto)
        {
            var product = await _reportProductRepository.GetAsync(id, CancellationToken.None);
            if (product == null)
            {
                throw new Exception($"Продукт с id = {id} не найден");
            }

            _mapper.Map(updatingProductDto, product); // обновляет поля существующего объекта

            _reportProductRepository.Update(product);
            await _reportProductRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить продукт.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(int id)
        {
            var product = await _reportProductRepository.GetAsync(id, CancellationToken.None);
            product.Deleted = true;
            await _reportProductRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Получить постраничный список продуктов.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница продуктов. </returns>
        public async Task<ICollection<ReportProductDto>> GetPagedAsync(int page, int pageSize)
        {
            var entities = await _reportProductRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<ReportProduct>, ICollection<ReportProductDto>>(entities);
        }
    }

        ///// <summary>
        ///// Получить продукт.
        ///// </summary>
        ///// <param name="id"> Идентификатор. </param>
        ///// <param name="cancellationToken"> Токен отмены </param>
        ///// <returns> ДТО продукта. </returns>
        //public async Task<ReportProductDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        //{
        //    var product = await _reportProductRepository.GetAsync(id, cancellationToken);
        //    return _mapper.Map<Product, ProductDto>(product);
        //}

        ///// <summary>
        ///// Создать продукт.
        ///// </summary>
        ///// <param name="creatingProductDto"> ДТО пародукта. </param>
        ///// <returns> Идентификатор. </returns>
        //public async Task<int> CreateAsync(CreatingProductDto creatingProductDto)
        //{
        //    var product = _mapper.Map<CreatingProductDto, Product>(creatingProductDto);
        //    product.Id = creatingProductDto.Id;
        //    var createdLesson = await _productRepository.AddAsync(product);
        //    await _productRepository.SaveChangesAsync();
        //    await _busControl.Publish(new MessageDto
        //    {
        //        Content = $"Lesson {createdLesson.Id} with subject {createdLesson.Name} is added"
        //    });

        //    return createdLesson.Id;
        //}

        ///// <summary>
        ///// Изменить продукт.
        ///// </summary>
        ///// <param name="id"> Идентификатор. </param>
        ///// <param name="updatingProductDto"> ДТО продукта. </param>
        //public async Task UpdateAsync(int id, UpdatingProductDto updatingProductDto)
        //{
        //    var product = await _productRepository.GetAsync(id, CancellationToken.None);
        //    if (product == null)
        //    {
        //        throw new Exception($"Продукт с id = {id} не найден");
        //    }

        //    _mapper.Map(updatingProductDto, product); // обновляет поля существующего объекта
        //    product.Name = updatingProductDto.Name;
        //    _productRepository.Update(product);
        //    await _productRepository.SaveChangesAsync();
        //}

        ///// <summary>
        ///// Удалить продукт.
        ///// </summary>
        ///// <param name="id"> Идентификатор. </param>
        //public async Task DeleteAsync(int id)
        //{
        //    var product = await _productRepository.GetAsync(id, CancellationToken.None);
        //    product.Deleted = true;
        //    await _productRepository.SaveChangesAsync();
        //}

        ///// <summary>
        ///// Получить постраничный список продуктов.
        ///// </summary>
        ///// <param name="page"> Номер страницы. </param>
        ///// <param name="pageSize"> Объем страницы. </param>
        ///// <returns> Страница продуктов. </returns>
        //public async Task<ICollection<ProductDto>> GetPagedAsync(int page, int pageSize)
        //{
        //    ICollection<Product> entities = await _productRepository.GetPagedAsync(page, pageSize);
        //    return _mapper.Map<ICollection<Product>, ICollection<ProductDto>>(entities);
        //}
    
}