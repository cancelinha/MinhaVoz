using Senai.MinhaVoz.Dominio.Entidades;
using Senai.MinhaVoz.Dominio.Interfaces.Repositorios;
using Senai.MinhaVoz.Infra.Data.Repositorios;
using Xunit;

namespace Senai.MinhaVoz.Teste.XUnit.Repositorios
{
	public class UsuarioTest
	{
		private IUsuarioRepositorio _usuarioRepositorio;
		public UsuarioTest()
		{
			_usuarioRepositorio = new UsuarioRepositorio();
		}
		[Fact]
		public void UsuarioInvalido()
		{
			var retornaUsuario = _usuarioRepositorio.EfetuarLogin("test@teste.com", "12345");
			Assert.Null(retornaUsuario);
		}

		[Fact]
		public void senhaNaoInformada()
		{
			var retornaUsuario = _usuarioRepositorio.EfetuarLogin("tesyte@teste.com", "");
			Assert.Null(retornaUsuario);
		}
		[Fact]
		public void emailNaoInformado()
		{
			var retornaUsuario = _usuarioRepositorio.EfetuarLogin("", "12345");
			Assert.Null(retornaUsuario);
		}
		[Fact]
	public void usuarioValido()
		{
			var usuarioExistente = new Usuario()
				{
				Email = "jeff@admin.com",
				Senha = "12345"
				};

			var usuarioAtual = _usuarioRepositorio.EfetuarLogin(usuarioExistente.Email, usuarioExistente.Senha);
			Assert.Equal(usuarioExistente.Email, usuarioAtual.Email);
			Assert.Equal(usuarioExistente.Senha, usuarioAtual.Senha);
		}
	}
}