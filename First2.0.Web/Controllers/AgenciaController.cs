using First2._0.Application.Models.AgenciaModel;
using First2._0.Application.Services.Agencias;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace First2._0.Web.Controllers
{
    public class AgenciaController : Controller
    {
        private readonly IAgenciaService _agenciaService;

        public AgenciaController(IAgenciaService agenciaService)
        {
            _agenciaService = agenciaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgenciaRequestModel request)
        {
            await _agenciaService.Create(request);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AgenciaRequestModel request)
        {
            await _agenciaService.Update(id, request);
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<AgenciaResponseModel> GetById([FromRoute] Guid id)
        {
            return await _agenciaService.GetById(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IList<AgenciaResponseModel>> GetAll()
        {
            return await _agenciaService.GetAll();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _agenciaService.Delete(id);
            return NoContent();
        }
    }
}