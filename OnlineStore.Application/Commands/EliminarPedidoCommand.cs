using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Commands
{
	public class EliminarPedidoCommand : IRequest
	{
		public int Id { get; set; }

		public EliminarPedidoCommand(int id)
		{
			Id = id;
		}
	}
}
