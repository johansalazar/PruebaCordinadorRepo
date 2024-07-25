using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Dtos
{
	public class PedidoDto
	{
		public int Id { get; set; }
		public string? ClienteId { get; set; }
		public List<ProductoDto>? Productos { get; set; }
		public int Total { get; set; }
		public DateTime Fecha { get; set; }

		public PedidoDto(string cliente, List<ProductoDto> productos)
		{
            ClienteId = cliente;
			Productos = productos;
			Fecha = DateTime.Now;
			CalcularTotal();
		}

		public void CalcularTotal()
		{
			Total = Productos.Sum(p => p.Precio);
		}
	}
}
