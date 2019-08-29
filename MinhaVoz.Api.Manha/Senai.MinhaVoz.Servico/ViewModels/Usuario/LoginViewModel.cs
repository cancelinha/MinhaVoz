using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MinhaVoz.Servico.ViewModels.Usuario
{
	public class LoginViewModel
	{		
			[Required(ErrorMessage = "Informe o e-mail")]
			[StringLength(100, MinimumLength = 4, ErrorMessage = "O email deve ter no mínimo 4 caracteres")]
			public string Email { get; set; }

			[Required(ErrorMessage = "Informe a senha")]
			[StringLength(50, MinimumLength = 4, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
			public string Senha { get; set; }
	}
}
