using System;
using System.Collections.Generic;

namespace Senai.MinhaVoz.Dominio.Entidades
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string NomeTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }


        public TipoUsuario NomeTipoUsuarioNavigation { get; set; }
    }
}
