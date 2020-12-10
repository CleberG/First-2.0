using First2._0.Application.Models.FuncionarioModel;
using First2._0.Application.Services.Funcionarios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace First2._0.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FuncionarioRequestDto request)
        {
            await _funcionarioService.Create(request);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Disable([FromRoute] Guid id)
        {
            await _funcionarioService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<FuncionarioResponseDto>> GetAll()
        {
            return await _funcionarioService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<FuncionarioResponseDto> GetById([FromRoute] Guid id)
        {
            return await _funcionarioService.GetById(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] FuncionarioRequestDto request)
        {
            await _funcionarioService.Update(id, request);
            return Ok();
        }
    }
}