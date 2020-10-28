namespace First2._0.Application.Models.UsuarioModel
{
    public abstract class UsuarioModelBase : ModelBase
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
