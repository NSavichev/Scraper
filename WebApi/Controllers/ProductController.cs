using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts.Product;
using WebApi.Models.Product;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, ILogger<ProductController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
        {
            var lessonDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<ProductDto, ProductModel>(lessonDto));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingProductModel creatingLessonDto)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingProductModel, CreatingProductDto>(creatingLessonDto)));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, UpdatingProductModel creatingLessonDto)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingProductModel, UpdatingProductDto>(creatingLessonDto));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
        {
            return Ok(_mapper.Map<List<ProductModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
    }
}