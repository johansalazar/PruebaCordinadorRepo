using MediatR;
using OnlineStore.Application.Dtos;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Query
{
	public class GetAllPedidosQuery : IRequest<List<PedidoDto>>
	{
	}
}
