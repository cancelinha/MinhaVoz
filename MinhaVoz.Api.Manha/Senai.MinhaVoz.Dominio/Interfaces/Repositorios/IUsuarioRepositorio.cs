using System;
using System.Collections.Generic;
using Senai.MinhaVoz.Dominio.Entidades;


namespace Senai.MinhaVoz.Dominio.Interfaces.Repositorios
{
	public interface IUsuarioRepositorio
	{
		Usuario EfetuarLogin(string email, string senha);
	}
}
