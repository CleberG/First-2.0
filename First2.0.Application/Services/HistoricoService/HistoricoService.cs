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
        public async Task Create(HistoricoRequestDto request)
        {
            var historico = new Historico(request.Descricao, request.Ativo);
            historico.HistoricoValidate();
            await _historicoRepository.Create(historico);
        }

        public async Task Delete(Guid id)
        {
            var historico = await _historicoRepository.GetById(id);
            var verificaHistorico = _historicoRepository.VerificarExistencia(id);
            if (verificaHistorico == null)
            {
                throw new ArgumentException($"Não foi possível encontrar o histórico: {historico.Descricao}.", nameof(historico.Descricao));
            }
            historico.Desabilitar();
            await _historicoRepository.Update(id, historico);
        }

        public async Task<IList<HistoricoResponseDto>> GetAll()
        {
            var historicos = _historicoRepository
                .GetAll()
                .ToList();

            return historicos.Select(d => new HistoricoResponseDto()
            {
                Ativo = d.Ativo,
                Id = d.Id,
                Descricao = d.Descricao
            }).ToList();
        }

        public async Task<HistoricoResponseDto> GetById(Guid id)
        {
            var historico = await _historicoRepository.GetById(id);
            var verificaHistorico = _historicoRepository.VerificarExistencia(id);
            if (verificaHistorico == null)
            {
                throw new ArgumentException($"Não foi possível encontrar o histórico: {historico.Descricao}.", nameof(historico.Descricao));
            }
            return new HistoricoResponseDto()
            {
                Ativo = historico.Ativo,
                Id = historico.Id,
                Descricao = historico.Descricao

            };
        }

        public async Task Update(Guid id, HistoricoRequestDto request)
        {
            var historico = await _historicoRepository.GetById(id);
            var verificaHistorico = _historicoRepository.VerificarExistencia(id);
            if (verificaHistorico == null)
            {
                throw new ArgumentException($"Não foi possível encontrar o histórico: {historico.Descricao}.", nameof(historico.Descricao));
            }
            historico.Update(request.Descricao, request.Ativo);
            await _historicoRepository.Update(id, historico);
        }
    }
}
