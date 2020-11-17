using First2._0.Application.Models.HistoricoModel;
using System.Threading.Tasks;
using Fisrt2._0.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace First2._0.Tests.Integration.Integration.HistoricoTest
{
    public class HistoricoSetup
    {
        private static HistoricoSetup _historicoSetup;

        private HistoricoSetup(DbContext dbContext)
        {
            Task.FromResult(Seed(dbContext));
        }
        public static HistoricoSetup GetSetup(DbContext dbContext)
        {
            if (_historicoSetup == null)
            {
                _historicoSetup = new HistoricoSetup(dbContext);
            }
            return _historicoSetup;
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
        public HistoricoResponseModel BuscarHistorico()
        {
            return new HistoricoResponseModel()
            {
                Ativo = Historico.Ativo,
                Descricao = Historico.Descricao,
                Id = Historico.Id
            };
        }
    }
}
