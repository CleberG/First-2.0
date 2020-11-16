using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First2._0.Application.Models.HistoricoModel;
using First2._0.Application.Services.HistoricoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First2._0.Web.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
    public class HistoricoController : Controller
    {
        private readonly IHistoricoService _historicoService;
        
        public HistoricoController(IHistoricoService historicoService)
        {
            _historicoService = historicoService;
        }
        [HttpPost]
        public async Task<IActionResult> Create ([FromBody] HistoricoRequestModel request)
        {
            await _historicoService.Create(request);
            return NoContent();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] HistoricoRequestModel request)
        {
            await _historicoService.Update(id, request);
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _historicoService.Delete(id);
            return NoContent();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<HistoricoResponseModel> GetById([FromRoute] Guid id)
        {
            return await _historicoService.GetById(id);
        }
        [HttpGet]
        public async Task<IList<HistoricoResponseModel>> GetAll()
        {
            return await _historicoService.GetAll();
        }
    }

}
