using Senai.MinhaVoz.Dominio.Entidades;
using Senai.MinhaVoz.Dominio.Interfaces.Repositorios;
using Senai.MinhaVoz.Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MinhaVoz.Infra.Data.Repositorios
{
	public class ChamadoRepositorio : IChamadoRepositorio
	{
        public Chamado Cadastrar(Chamado chamado)
        {
            try
            {
                using (MinhaVozContext ctx = new MinhaVozContext())
                {
                    ctx.Chamado.Add(chamado);
                    ctx.SaveChanges();
                    return chamado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Chamado> Listar()
		{
			try
			{
				using (MinhaVozContext ctx = new MinhaVozContext())
				{
					return ctx.Chamado.ToList();
				}
			}catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Chamado BuscarPorId(int id)
		{
			try
			{
				using (MinhaVozContext ctx = new MinhaVozContext())
				{
					return ctx.Chamado.Find(id);
				}
			}catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Chamado EditarStatus(Chamado chamado)
		{
			using (MinhaVozContext ctx = new MinhaVozContext())
			{


				Chamado chamadoExiste = ctx.Chamado.Find(chamado.Id);

				if (chamadoExiste != null)
				{
					chamadoExiste.Status = chamado.Status;
					ctx.Chamado.Update(chamadoExiste);
					ctx.SaveChanges();

					return chamadoExiste;
				}

				return null;
			}
		}
	}
}
