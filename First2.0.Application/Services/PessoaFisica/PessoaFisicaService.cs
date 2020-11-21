using First2._0.Application.Models.PessoaFisica;
using Fisrt2._0.Domain.Entidades;
using Fisrt2._0.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First2._0.Application.Services
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository; 

        public PessoaFisicaService(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }

        public async Task Create(PessoaFisicaRequestModel request)
        {
            var pessoaFisica = new PessoaFisica(request.Nome, request.Email, request.CPF, request.DataNascimento, request.LimiteCredito,
                request.Complemento, request.Telefone, request.Cidade, request.Bairro, request.Numero, request.CEP, request.UF, request.Ativo);

            pessoaFisica.Validar();

            await _pessoaFisicaRepository.Create(pessoaFisica);
        }

        public async Task Delete(Guid id)
        {
            var pessoaFisica = await _pessoaFisicaRepository.GetById(id);

            pessoaFisica.Desabilitar();

            await _pessoaFisicaRepository.Update(id, pessoaFisica);

        }

        public async Task<IList<PessoaFisicaResponseModel>> GetAll()
        {
            var pessoaFisica = _pessoaFisicaRepository.GetAll().ToList();

            return pessoaFisica.Select(p => new PessoaFisicaResponseModel()
            {
                Id = p.Id,
                Nome = p.Nome,
                Email = p.Email,
                CPF = p.CPF,
                DataNascimento = p.DataNascimento,
                LimiteCredito = p.LimiteCredito,
                Complemento = p.Complemento,
                Telefone = p.Telefone,
                Cidade = p.Cidade,
                Bairro = p.Bairro,
                Numero = p.Numero,
                CEP = p.CEP,
                UF = p.UF,
                Ativo = p.Ativo
            }).ToList();
        }

        public async Task<PessoaFisicaResponseModel> GetById(Guid id)
        {
            var pessoaFisica = await _pessoaFisicaRepository.GetById(id);

            return new PessoaFisicaResponseModel()
            {
                Id = pessoaFisica.Id,
                Nome = pessoaFisica.Nome,
                Email = pessoaFisica.Email,
                CPF = pessoaFisica.CPF,
                DataNascimento = pessoaFisica.DataNascimento,
                LimiteCredito = pessoaFisica.LimiteCredito,
                Complemento = pessoaFisica.Complemento,
                Telefone = pessoaFisica.Telefone,
                Cidade = pessoaFisica.Cidade,
                Bairro = pessoaFisica.Bairro,
                Numero = pessoaFisica.Numero,
                CEP = pessoaFisica.CEP,
                UF = pessoaFisica.UF,
                Ativo = pessoaFisica.Ativo
            };
        }

        public async Task Update(Guid id, PessoaFisicaRequestModel request)
        {
            var pessoaFisica = await _pessoaFisicaRepository.GetById(id);

            pessoaFisica.Update(request.Nome, request.Email, request.CPF, request.DataNascimento, request.LimiteCredito,
                request.Complemento, request.Telefone, request.Cidade, request.Bairro, request.Numero, request.CEP, request.UF, request.Ativo);

            await _pessoaFisicaRepository.Update(id, pessoaFisica);
        }
    }
}
