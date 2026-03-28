using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts.Shop;
using WebApi.Models.Shop;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController: ControllerBase
    {
        private readonly IShopService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<ShopController> _logger;

        public ShopController(IShopService service, ILogger<ShopController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(_mapper.Map<ShopModel>(await _service.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingShopModel shopModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingShopDto>(shopModel)));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, UpdatingShopModel shopModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingShopModel, UpdatingShopDto>(shopModel));
            return Ok();
        }
        
        
        [HttpPut("WithProducts")]
        public async Task<IActionResult> EditWithProductsAsync(int id, UpdatingShopWithProductModel shopModel)
        {
            await _service.UpdatingWithProductsAsync(id, _mapper.Map<UpdatingShopWithProductModel, UpdatingShopWithProductsDto>(shopModel));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        
        [HttpPost("list")]
        public async Task<IActionResult> GetListAsync(ShopFilterModel filterModel)
        {
            var filterDto = _mapper.Map<ShopFilterModel, ShopFilterDto>(filterModel);
            return Ok(_mapper.Map<List<ShopModel>>(await _service.GetPagedAsync(filterDto)));
        }
        
        //[HttpPost("info/{fieldsToSelect}")]
        //public async Task<IEnumerable<ProductInfoModel>> GetCourseInfosAsync(string fieldsToSelect)
        //{
        //    return _mapper.Map<List<ProductInfoModel>>(await _service.GetCourseInfosAsync(fieldsToSelect));
        //}
    }
}