using Senai.MinhaVoz.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MinhaVoz.Dominio.Interfaces.Repositorios
{
	public interface IChamadoRepositorio
	{
		List<Chamado> Listar();
        Chamado Cadastrar(Chamado chamado);
		Chamado BuscarPorId(int id);
		Chamado EditarStatus( Chamado chamado);


    }
}
