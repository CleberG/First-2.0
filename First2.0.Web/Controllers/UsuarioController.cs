using First2._0.Application.Models.UsuarioModel;
using First2._0.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace First2._0.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioRequestModel request)
        {
            await _usuarioService.Create(request);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UsuarioRequestModel request)
        {
            await _usuarioService.Update(id, request);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _usuarioService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<UsuarioResponseModel> GetById([FromRoute] Guid id)
        {
            return await _usuarioService.GetById(id);
        }

        [HttpGet]
        public async Task<IList<UsuarioResponseModel>> GetAll()
        {
            return await _usuarioService.GetAll();
        }
    }
}