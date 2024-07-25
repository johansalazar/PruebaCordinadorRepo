using MediatR;
using OnlineStore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Commands
{
	public class CrearPedidoCommand : IRequest<int>
	{
		public string? Cliente { get; set; }
		public List<ProductoDto>? Productos { get; set; }
	}
}
