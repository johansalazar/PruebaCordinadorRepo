using MediatR;
using OnlineStore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Query
{
	public class GetPedidoByIdQuery : IRequest<PedidoDto>
	{
		public int Id { get; set; }
		public GetPedidoByIdQuery(int id)
		{
			Id = id;
		}
	}
}
