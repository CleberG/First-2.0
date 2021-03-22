using First2._0.Application.Models.AgenciaModel;
using Fisrt2._0.Domain.Entidades;
using Fisrt2._0.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First2._0.Application.Services.Agencias
{
    public class AgenciaService : IAgenciaService
    {
        private readonly IAgenciaRepository _agenciaRepository;

        public AgenciaService(IAgenciaRepository agenciaRepository)
        {
            _agenciaRepository = agenciaRepository;
        }

        public async Task Create(AgenciaRequestModel request)
        {
            var agencia = new Agencia(request.Banco, request.Nome, request.Numero);
            await _agenciaRepository.Create(agencia);
        }

        public async Task Delete(Guid id)
        {
            var agencia = await _agenciaRepository.GetById(id);

            agencia.Desativar();

            await _agenciaRepository.Delete(id);
        }

        public async Task<IList<AgenciaResponseModel>> GetAll()
        {
            var response = _agenciaRepository.GetAll().ToList();

            return response.Select(x => new AgenciaResponseModel()
            {
                Banco = x.Banco,
                Nome = x.Nome,
                Numero = x.Numero
            }).ToList();
        }

        public async Task<AgenciaResponseModel> GetById(Guid id)
        {
            var response = await _agenciaRepository.GetById(id);

            return new AgenciaResponseModel()
            {
                Banco = response.Banco,
                Nome = response.Nome,
                Numero = response.Numero
            };
        }

        public async Task Update(Guid id, AgenciaRequestModel request)
        {
            var response = await _agenciaRepository.GetById(id);

            response.Editar(request.Banco, response.Nome, response.Numero);

            await _agenciaRepository.Update(id, response);
        }
    }
}
