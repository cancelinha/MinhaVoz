using Senai.MinhaVoz.Dominio.Interfaces.Repositorios;
using Senai.MinhaVoz.Infra.Data.Domains;
using System;
using System.Linq;

namespace Senai.MinhaVoz.Infra.Data.Repositorios
{
	public class UsuarioRepositorio : IUsuarioRepositorio
	{

		public Dominio.Entidades.Usuario EfetuarLogin(string email, string senha)
		{
			try
			{
				using (MinhaVozContext ctx = new MinhaVozContext())
				{
					return ctx.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}
	}
}
