using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MinhaVoz.Servico.ViewModels.Chamado
{
    public class ChamadoViewMoldel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o seu telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o título do chamado")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Informe o assunto do chamado")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "Informe a descrição")]
        public string Descricao { get; set; }

        public string Status { get; set; }

        [Required(ErrorMessage = "Informe o título do pacote")]
        public DateTime Data { get; set; }
    }
}
