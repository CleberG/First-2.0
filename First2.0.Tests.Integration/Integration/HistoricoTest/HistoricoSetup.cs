using First2._0.Application.Models.HistoricoModel;
using System.Threading.Tasks;
using Fisrt2._0.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace First2._0.Tests.Integration.Integration.HistoricoTest
{
    public class HistoricoSetup
    {
        private static HistoricoSetup _historicoInstance;
        private HistoricoSetup(DbContext dbContext)
        {
            Task.FromResult(Seed(dbContext));
        }
        public static HistoricoSetup GetInstance(DbContext dbContext)
        {
            if (_historicoInstance == null)
            {
                _historicoInstance = new HistoricoSetup(dbContext);
            }
            return _historicoInstance;
        }

        public Historico Historico { get; private set; }
        public async Task Seed(DbContext _context)
        {
            var historico = await _context.AddAsync(CriarHistorico("ufcu"));
            Historico = historico.Entity;

            await _context.SaveChangesAsync();
        }
        public Historico CriarHistorico(string suffix)
        {
            return new Historico($"Descricao{suffix}", true);
        }
        public HistoricoResponseDto BuscarHistorico()
        {
            return new HistoricoResponseDto()
            {
                Ativo = Historico.Ativo,
                Descricao = Historico.Descricao,
                Id = Historico.Id
            };
        }
    }
}
