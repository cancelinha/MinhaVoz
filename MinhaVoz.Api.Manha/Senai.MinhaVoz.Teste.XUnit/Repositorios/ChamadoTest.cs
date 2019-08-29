using Senai.MinhaVoz.Dominio.Entidades;
using Senai.MinhaVoz.Dominio.Interfaces.Repositorios;
using Senai.MinhaVoz.Infra.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Senai.MinhaVoz.Teste.XUnit.Repositorios
{
	public class ChamadoTest
	{
		private IChamadoRepositorio _chamadoRepositorio;
		public ChamadoTest()
		{
			_chamadoRepositorio = new ChamadoRepositorio();
		}

		[Fact]
		public void CadastraChamado()
		{
			Chamado chamado = new Chamado()
			{
				Nome = "Jefferson",
				Email = "jeff@gmail.com",
				Telefone = "+55(11)127263827",
				Titulo = "Janela quebrada",
				Assunto = "Concerto",
				Descricao = "Janela está quebrada e nos dias de frio entra muito vento.",
				Status = "Pendente",
				Data = new System.DateTime(2019, 10, 9)
			};
			var chamadoRetorno = _chamadoRepositorio.Cadastrar(chamado);

			Assert.NotNull(chamadoRetorno);
			Assert.Equal(chamadoRetorno.Titulo, chamado.Titulo);
		}
		[Theory]
		[InlineData(4, 4)]
		public void BuscarPorId(int id, int experado)
		{
			var retornoChamado = _chamadoRepositorio.BuscarPorId(id);
			Assert.Equal(retornoChamado.Id, experado);
		}
	}
}
