using System;
using System.Collections.Generic;
using System.Text;

namespace First2._0.Application.Models.UsuarioModel
{
    public class UsuarioModelBase
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
