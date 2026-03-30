using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Services.Abstractions;
using AutoMapper;
using CommonNamespace;
using Domain.EF;
using MassTransit;
using Services.Contracts.Product;

namespace Services.Implementations
{
    /// <summary>
    /// Сервис работы с продуктами.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IBusControl _busControl;

        public ProductService(
            IMapper mapper,
            IProductRepository lessonRepository,
            IBusControl busControl)
        {
            _mapper = mapper;
            _productRepository = lessonRepository;
            _busControl = busControl;
        }

        /// <summary>
        /// Получить продукт.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> Токен отмены </param>
        /// <returns> ДТО продукта. </returns>
        public async Task<ProductDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(id, cancellationToken);
            return _mapper.Map<Product, ProductDto>(product);
        }

        /// <summary>
        /// Создать продукт.
        /// </summary>
        /// <param name="creatingProductDto"> ДТО пародукта. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<int> CreateAsync(CreatingProductDto creatingProductDto)
        {
            var product = _mapper.Map<CreatingProductDto, Product>(creatingProductDto);
            product.Id = creatingProductDto.Id;
            var createdLesson = await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();
            await _busControl.Publish(new MessageDto
            {
                Content = $"Lesson {createdLesson.Id} with subject {createdLesson.Name} is added"
            });

            return createdLesson.Id;
        }

        /// <summary>
        /// Изменить продукт.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingProductDto"> ДТО продукта. </param>
        public async Task UpdateAsync(int id, UpdatingProductDto updatingProductDto)
        {
            var product = await _productRepository.GetAsync(id, CancellationToken.None);
            if (product == null)
            {
                throw new Exception($"Продукт с id = {id} не найден");
            }

            _mapper.Map(updatingProductDto, product); // обновляет поля существующего объекта
            product.Name = updatingProductDto.Name;
            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить продукт.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(int id)
        {
            var product = await _productRepository.GetAsync(id, CancellationToken.None);
            product.Deleted = true; 
            await _productRepository.SaveChangesAsync();
        }
        
        /// <summary>
        /// Получить постраничный список продуктов.
        /// </summary>
        /// <param name="page"> Номер страницы. </param>
        /// <param name="pageSize"> Объем страницы. </param>
        /// <returns> Страница продуктов. </returns>
        public async Task<ICollection<ProductDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<Product> entities = await _productRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<Product>, ICollection<ProductDto>>(entities);
        }
    }
}