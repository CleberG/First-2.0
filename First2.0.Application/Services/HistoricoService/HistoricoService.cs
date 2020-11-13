using First2._0.Application.Models.HistoricoModel;
using Fisrt2._0.Domain.Entidades;
using Fisrt2._0.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First2._0.Application.Services.HistoricoService
{
    public class HistoricoService
        : IHistoricoService
    {
        private readonly IHistoricoRepository _historicoRepository;

        public HistoricoService(IHistoricoRepository historicoRepository)
        {
            _historicoRepository = historicoRepository;
        }
        public async Task Create(HistoricoRequestModel request)
        {
            var historico = new Historico(request.Descricao);
            await _historicoRepository.Create(historico);
        }

        public async Task Delete(Guid id)
        {
            var historico = await _historicoRepository.GetById(id);
            historico.Desabilitar();
            await _historicoRepository.Update(id, historico);
        }

        public async Task<IList<HistoricoResponseModel>> GetAll()
        {
            var historicos = _historicoRepository
                .GetAll()
                .ToList();
            return historicos.Select(d => new HistoricoResponseModel()
            {
                Ativo = d.Ativo,
                Id = d.Id,
                Descricao = d.Descricao
            }).ToList();
        }

        public async Task<HistoricoResponseModel> GetById(Guid id)
        {
            var historico = await _historicoRepository.GetById(id);
            return new HistoricoResponseModel()
            {
                Ativo = historico.Ativo,
                Id = historico.Id,
                Descricao = historico.Descricao

            };
        }

        public async Task Update(Guid id, HistoricoRequestModel request)
        {
            var verificaHistorico = _historicoRepository.VerificarExistencia(id);
            if (verificaHistorico == null)
            {
                // exception + mensagem 
            }
            var historico = await _historicoRepository.GetById(id);
            historico.Update(request.Descricao, request.Ativo);
            await _historicoRepository.Update(id, historico);
        }
    }
}
