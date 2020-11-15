using First2._0.Application.Models.PessoaFisica;
using First2._0.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace First2._0.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaFisicaController : Controller
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;
        public PessoaFisicaController(IPessoaFisicaService pessoaFisicaService)
        {
            _pessoaFisicaService = pessoaFisicaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PessoaFisicaRequestModel request)
        {
            await _pessoaFisicaService.Create(request);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PessoaFisicaRequestModel request)
        {
            await _pessoaFisicaService.Update(id, request);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _pessoaFisicaService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<PessoaFisicaResponseModel> GetById([FromRoute] Guid id)
        {
            return await _pessoaFisicaService.GetById(id);
        }

        [HttpGet]
        public async Task<IList<PessoaFisicaResponseModel>> GetAll()
        {
            return await _pessoaFisicaService.GetAll();
        }
    }
}