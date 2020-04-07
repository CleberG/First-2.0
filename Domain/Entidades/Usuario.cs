namespace Domain.Entidades
{
    public class Usuario : EntityBase
    {
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public bool Ativo { get; set; }


        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
            Ativo = true;
        }

        public void Update(string nome, string email)
        {
            Nome = nome;
            Email = email;
            Ativo = true;
        }

        public void Desabilitar()
        {
            Ativo = false;
        }
    }
}
