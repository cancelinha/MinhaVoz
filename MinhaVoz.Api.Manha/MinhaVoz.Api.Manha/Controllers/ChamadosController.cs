using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.MinhaVoz.Dominio.Entidades;
using Senai.MinhaVoz.Dominio.Interfaces.Repositorios;
using Senai.MinhaVoz.Infra.Data.Repositorios;
using Senai.MinhaVoz.Servico.ViewModels.Chamado;

namespace MinhaVoz.Api.Manha.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class ChamadosController : ControllerBase
	{
		private IChamadoRepositorio _chamadoRepositorio;

		public ChamadosController()
		{
			_chamadoRepositorio = new ChamadoRepositorio();
		}

		[HttpPost]
		[Route("/cadastrar")]
		public IActionResult Post(ChamadoViewMoldel chamado)
		{
			try
			{
				Chamado chamadoNovo = new Chamado()
				{
					Nome = chamado.Nome,
					Email = chamado.Email,
					Telefone = chamado.Telefone,
					Titulo = chamado.Titulo,
					Assunto = chamado.Assunto,
					Descricao = chamado.Descricao,
					Status = "Pendente",
					Data = chamado.Data
				};

				var chamadoRetorno = _chamadoRepositorio.Cadastrar(chamadoNovo);

				return Ok(chamadoRetorno);
			}
			catch (Exception ex)
			{
				return BadRequest(new { sucesso = false, mensagem = ex.Message });
			}
		}
		[HttpGet]
		[Authorize]
		[Route("/listar")]
		public IActionResult Listar()
		{
			try
			{
				return Ok(_chamadoRepositorio.Listar());
			}
			catch (System.Exception ex)
			{
				return BadRequest(new { sucesso = false, mensagem = ex.Message });
			}
		}

		[HttpGet("{id}")]
		[Authorize]
		public IActionResult BuscarPorId(int id)
		{
			try
			{
				var chamado = _chamadoRepositorio.BuscarPorId(id);
				if (chamado == null)
				{
					return NotFound(new { mensagem = "Chamado não encontrado." });
				}
				return Ok(chamado);
			} catch (Exception ex)
			{
				return BadRequest(new { sucesso = false, menagem = ex.Message });
			}
		}

		[HttpPut("editarstatus/{id}")]
		public IActionResult Put(int id, Chamado chamado)
		{
			chamado.Id = id;

			_chamadoRepositorio.EditarStatus(chamado);
			if (_chamadoRepositorio.EditarStatus(chamado) == null) { return NotFound(); }
			return Ok();

		}


	}
}