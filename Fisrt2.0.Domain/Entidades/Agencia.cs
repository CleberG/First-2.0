namespace Fisrt2._0.Domain.Entidades
{
    public class Agencia : EntidadeBase
    {
        public Agencia(string banco, string nome, string numero)
        {
            Banco = banco;
            Nome = nome;
            Numero = numero;
        }

        public void Editar(string banco, string nome, string numero)
        {
            Banco = banco;
            Nome = nome;
            Numero = numero;
        }

        public string Banco { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
    }
}
