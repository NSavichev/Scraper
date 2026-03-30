using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Services.Abstractions;
using AutoMapper;
using Domain.EF;
using MassTransit;
using Services.Contracts.Shop;
using Services.Contracts.Product;

namespace Services.Implementations
{
    /// <summary>
    /// Cервис работы с магазином.
    /// </summary>
    public class ShopService : IShopService
    {
        private readonly IMapper _mapper;
        private readonly IShopRepository _shopRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBusControl _busControl;
        private readonly IUnitOfWork _unitOfWork;

        public ShopService(
            IMapper mapper,
            IShopRepository shopRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IBusControl busControl)
        {
            _mapper = mapper;
            _shopRepository = shopRepository;
            _productRepository = productRepository;
            _busControl = busControl;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Получить магазин.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО магазина. </returns>
        public async Task<ShopDto> GetByIdAsync(int id)
        {
            var shop = await _shopRepository.GetAsync(id, CancellationToken.None);
            return _mapper.Map<Shop, ShopDto>(shop);
        }

        /// <summary>
        /// Создать магазин.
        /// </summary>
        /// <param name="creatingShopDto"> ДТО создаваемого магазина. </param>
        /// <returns> Идентификатор. </returns>
        public async Task<int> CreateAsync(CreatingShopDto creatingShopDto)
        {
            var shop = _mapper.Map<CreatingShopDto, Shop>(creatingShopDto);
            var createdCourse = await _shopRepository.AddAsync(shop);
            await _shopRepository.SaveChangesAsync();
            return createdCourse.Id;
        }

        /// <summary>
        /// Обновить магазин и состав продуктов.
        /// Для показа unit of work.
        /// </summary>
        /// <param name="updatingShopWithProductsDto"> ДТО редактируемого магазина. </param>
        /// <param name="id"> Id </param>
        public async Task UpdatingWithProductsAsync(int id, UpdatingShopWithProductsDto updatingShopWithProductsDto)
        {
            //var course = await _unitOfWork.CourseRepository.GetAsync(id, CancellationToken.None);
            var shop = await _shopRepository.GetAsync(id, CancellationToken.None);
            if (shop == null)
            {
                throw new Exception($"Магазин с идентфикатором {id} не найден");
            }

            shop.Name = updatingShopWithProductsDto.Name;
            shop.ShopUrl = updatingShopWithProductsDto.ShopUrl;
            _shopRepository.Update(shop);
            await _shopRepository.SaveChangesAsync();
            //_unitOfWork.CourseRepository.Update(course);
            var products = _mapper.Map<IEnumerable<AttachingProductDto>, IEnumerable<Product>>(updatingShopWithProductsDto.Products);
            foreach (var xProd in products)
            {
                xProd.Id = 100; //Не существует
                await _productRepository.AddAsync(xProd);
                //await _unitOfWork.LessonRepository.AddAsync(lesson);
            }
            
            await _productRepository.SaveChangesAsync();
            //await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Изменить магазин.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="updatingShopDto"> ДТО редактируемого магазина. </param>
        public async Task UpdateAsync(int id, UpdatingShopDto updatingShopDto)
        {
            var shop = await _shopRepository.GetAsync(id, CancellationToken.None);
            if (shop == null)
            {
                throw new Exception($"Курс с идентфикатором {id} не найден");
            }

            shop.Name = updatingShopDto.Name;
            shop.ShopUrl = updatingShopDto.ShopUrl;
            _shopRepository.Update(shop);
            await _shopRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить магазин.
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        public async Task DeleteAsync(int id)
        {
            var shop = await _shopRepository.GetAsync(id, CancellationToken.None);
            shop.Deleted = true; 
            await _shopRepository.SaveChangesAsync();
        }
        
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список магазинов. </returns>
        public async Task<ICollection<ShopDto>> GetPagedAsync(int page, int pageSize)
        {
            ICollection<Shop> entities = await _shopRepository.GetPagedAsync(page, pageSize);
            return _mapper.Map<ICollection<Shop>, ICollection<ShopDto>>(entities);
        }

        //public async Task<IEnumerable<ShopInfoDto>> GetCourseInfosAsync(string fieldsToSelect)
        //{
        //    //var entities = await _shopRepository.GetShopInfosAsync(fieldsToSelect);
        //    return _mapper.Map<IEnumerable<CourseInfo>, IEnumerable<ShopInfoDto>>(entities);
        //}
    }
}