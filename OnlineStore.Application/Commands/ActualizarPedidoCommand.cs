using MediatR;
using OnlineStore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Commands
{
	public class ActualizarPedidoCommand : IRequest
	{
		public int Id { get; set; }
		public string? Cliente { get; set; }
		public List<ProductoDto>? Productos { get; set; }
		public int Total { get; set; }
		public DateTime Fecha { get; set; }
	}
}
