using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts.ReportProduct;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models.ReportProduct;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportProductController: ControllerBase
    {
        private readonly IReportProductService _service;
        private readonly ILogger<ReportProductController> _logger;
        private readonly IMapper _mapper;

        public ReportProductController(IReportProductService service, ILogger<ReportProductController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
        {
            var lessonDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<ReportProductDto, ReportProductModel>(lessonDto));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingReportProductModel creatingLessonDto)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingReportProductModel, CreatingReportProductDto>(creatingLessonDto)));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, UpdatingReportProductModel creatingLessonDto)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingReportProductModel, UpdatingReportProductDto>(creatingLessonDto));
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
            return Ok(_mapper.Map<List<ReportProductModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
    }
}