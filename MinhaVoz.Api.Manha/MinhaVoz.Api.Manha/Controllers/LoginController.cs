using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.MinhaVoz.Dominio.Entidades;
using Senai.MinhaVoz.Dominio.Interfaces.Repositorios;
using Senai.MinhaVoz.Infra.Data.Repositorios;
using Senai.MinhaVoz.Servico.ViewModels.Usuario;

namespace Senai.MinhaVoz.Web.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private IUsuarioRepositorio _usuarioRepositorio;

		public LoginController()
		{
			_usuarioRepositorio = new UsuarioRepositorio();
			
		}


		/// <summary>
		/// Efetua login na api 
		/// </summary>
		/// <param name="usuario">Dados do usuário</param>
		/// <remarks>
		/// Sample request:
		///
		///     POST /api/conta
		///     {
		///        "email": "adm@adm.com",
		///        "senha": "123"
		///     }
		///
		/// </remarks>
		/// <returns>Retorna um token</returns>
		/// <response code="400">Ocorreu um erro</response>
		/// <response code="404">Usuário não encontrado</response>   
		[HttpPost]
		public IActionResult Login(LoginViewModel usuario)
		{
			//Usuario usuarioRet = _usuarioRepositorio.EfetuarLogin(usuario.Email, usuario.Senha);
			try
			{
				var usuarioRetorno = _usuarioRepositorio.EfetuarLogin(usuario.Email, usuario.Senha);

				if (usuarioRetorno == null)
				{
					return NotFound(new { mensagem = "Email ou senha inválido" });
				}

				//Define os dados que serão fornecidos no token - PayLoad

				var claims = new[]
				{
					new Claim(JwtRegisteredClaimNames.Email, usuarioRetorno.Email),
					new Claim(JwtRegisteredClaimNames.Jti, usuarioRetorno.Id.ToString()),
					//new Claim("Administrador", usuario.Email),
				//new Claim(ClaimTypes.Role, usuarioRetorno.NomeTipoUsuarioNavigation.Nome),				
					//new Claim(ClaimTypes.Role,usuarioRetorno.NomeTipoUsuario.ToString())
				};

				// Chave de acesso do token
				var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("MinhaVoz-chave-autenticacao"));

				//Credenciais do Token - Header
				var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

				//Gera o token
				var token = new JwtSecurityToken(
					issuer: "MinhaVoz.WebApi",
					audience: "MinhaVoz.WebApi",
					claims: claims,
					expires: DateTime.Now.AddMinutes(30),
					signingCredentials: creds
				);

				//Retorna Ok com o Token
				return Ok(new
				{
					token = new JwtSecurityTokenHandler().WriteToken(token)
				});

			}
			catch (Exception ex)
			{
				return BadRequest(new { sucesso = false, mensagem = ex.Message });
			}
		}
	}
}