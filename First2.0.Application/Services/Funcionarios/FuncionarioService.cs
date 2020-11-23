using First2._0.Application.Models.FuncionarioModel;
using First2._0.Application.Services.Base;
using First2._0.Application.Services.Notifications;
using Fisrt2._0.Domain;
using Fisrt2._0.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First2._0.Application.Services.Funcionarios
{
    public class FuncionarioService : AbstractService, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly INotificationService _notificationService;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, INotificationService notificationService)
        {
            _funcionarioRepository = funcionarioRepository;
            _notificationService = notificationService;
        }

        public async Task Create(FuncionarioRequestModel request)
        {
            var funcionario = new Funcionario(request.Nome, request.TipoFuncionario,
                request.Usuario, request.Senha, request.Ativo);

            if (funcionario.Invalid)
            {
                _notificationService.AddEntityNotifications(funcionario.ValidationResult);
                return;
            }

            await _funcionarioRepository.Create(funcionario);
        }

        public async Task Disable(Guid id)
        {
            var funcionario = await _funcionarioRepository.GetById(id);
            if (HasNotification<Funcionario>(funcionario, _notificationService))
            {
                return;
            }

            if (await _funcionarioRepository.VerificaSeFuncionarioExiste(funcionario.Nome, id))
            {
                _notificationService.AddNotification("Funcionario", "Funcionario não encontrado.");
                return;
            }

            funcionario.Desabilitar();
            await _funcionarioRepository.Update(id, funcionario);
        }

        public async Task<IList<FuncionarioResponseModel>> GetAll()
        {
            var funcionario = _funcionarioRepository.GetAll().ToList();

            return funcionario.Select(x => new FuncionarioResponseModel()
            {
                Id = x.Id,
                Nome = x.Nome,
                TipoFuncionario = x.TipoFuncionario,
                Usuario = x.Usuario,
                Senha = x.Senha,
                Ativo = x.Ativo,
            }).ToList();
        }

        public async Task<FuncionarioResponseModel> GetById(Guid id)
        {
            var funcionario = await _funcionarioRepository.GetById(id);

            if (HasNotification<Funcionario>(funcionario, _notificationService))
            {
                return null;
            }

            if (await _funcionarioRepository.VerificaSeFuncionarioExiste(funcionario.Nome, id))
            {
                _notificationService.AddNotification("Funcionario", "Funcionario não encontrado");
                return null;
            }

            return new FuncionarioResponseModel()
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                TipoFuncionario = funcionario.TipoFuncionario,
                Usuario = funcionario.Usuario,
                Senha = funcionario.Senha,
                Ativo = funcionario.Ativo,
            };
        }

        public async Task Update(Guid id, FuncionarioRequestModel request)
        {
            var funcionario = await _funcionarioRepository.GetById(id);
            if (HasNotification<Funcionario>(funcionario, _notificationService))
                return;

            if (await _funcionarioRepository.VerificaSeFuncionarioExiste(request.Nome, id))
            {
                _notificationService.AddNotification("Funcionario", "Já existe um funcionario com esse nome.");
                return;
            }

            funcionario.Update(request.Nome, funcionario.TipoFuncionario, funcionario.Usuario, funcionario.Senha);

            if (funcionario.Invalid)
            {
                _notificationService.AddEntityNotifications(funcionario.ValidationResult);
                return;
            }
            await _funcionarioRepository.Update(id, funcionario);
        }
    }
}
