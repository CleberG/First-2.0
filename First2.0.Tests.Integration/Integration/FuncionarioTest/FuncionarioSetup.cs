using Fisrt2._0.Domain;
using Fisrt2._0.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace First2._0.Tests.Integration.Integration.FuncionarioTest
{
    public class FuncionarioSetup
    {
        private static FuncionarioSetup _instancia;

        public Funcionario CreateFuncionario { get; set; }
        public Funcionario DesativarFuncionario { get; set; }
        public Funcionario AtualizarFuncionario { get; set; }
        public Funcionario BuscarFuncionarioPorId { get; set; }

        private FuncionarioSetup(DbContext dbContext)
        {
            Task.FromResult(Seed(dbContext));
        }

        public static FuncionarioSetup GetInstance(DbContext dbContext)
        {
            if (_instancia == null)
            {
                _instancia = new FuncionarioSetup(dbContext);
            }

            return _instancia;
        }

        public async Task Seed(DbContext _context)
        {
            var funcionario = await _context.AddAsync(CriarFuncionario("cf", TipoFuncionario.Funcionario));
            CreateFuncionario = funcionario.Entity;

            var desativarFuncionario = await _context.AddAsync(CriarFuncionario("cfdf", TipoFuncionario.Funcionario));
            DesativarFuncionario = desativarFuncionario.Entity;
            
            var atualizarFuncionario = await _context.AddAsync(CriarFuncionario("cfaf", TipoFuncionario.Funcionario));
            AtualizarFuncionario = atualizarFuncionario.Entity;
            
            var buscarFuncionarioPorId = await _context.AddAsync(CriarFuncionario("cfbfpi", TipoFuncionario.Funcionario));
            BuscarFuncionarioPorId = buscarFuncionarioPorId.Entity;

            await _context.SaveChangesAsync();
        }

        public Funcionario CriarFuncionario(string suffix, TipoFuncionario tipoFuncionario)
        {
            return new Funcionario($"Funcionario{suffix}", tipoFuncionario,
                $"Usuario{suffix}", $"Senha{suffix}", true);
        }
    }
}
