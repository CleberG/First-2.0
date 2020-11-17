namespace Fisrt2._0.Domain.Entidades
{
    public class Historico :
        EntidadeBase
    {
        public string Descricao { get; protected set; }
        public bool Ativo { get; protected set; }

        public Historico(string descricao, bool ativo)
        {
            Descricao = descricao;
            Ativo = ativo;
        }
        public void Update(string descricao, bool ativo)
        {
            Descricao = descricao;
            Ativo = ativo;
        }

        public void Desabilitar()
        {
            Ativo = false;
        }
    }
}
