using System;
using System.Collections.Generic;
using DIO.MUSICAL.Interfaces;

namespace DIO.Series
{
	public class MusicalRepositorio : IRepositorio<MUSICAL>
	{
        private List<MUSICAL> listaSerie = new List<MUSICAL>();
		public void Atualiza(int id, MUSICAL objeto)
		{
			listaMusical[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaMusical[id].Excluir();
		}

		public void Insere(Musical objeto)
		{
			listaMusical.Add(objeto);
		}

		public List<Musical> Lista()
		{
			return listaMusical;
		}

		public int ProximoId()
		{
			return listaMusical.Count;
		}

		public Musical RetornaPorId(int id)
		{
			return listaMusical[id];
		}
	}
}