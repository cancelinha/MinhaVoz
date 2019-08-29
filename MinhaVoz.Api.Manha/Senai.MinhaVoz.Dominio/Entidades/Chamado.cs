using System;
using System.Collections.Generic;

namespace Senai.MinhaVoz.Dominio.Entidades
{
    public partial class Chamado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Titulo { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }
    }
}
