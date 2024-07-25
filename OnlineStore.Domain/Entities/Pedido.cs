using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
	public class Pedido
	{
		public int Id { get;  set; }
		public string? ClienteId { get;  set; }
		public List<Producto> Productos { get;  set; }
		public int Total { get;  set; }
		public DateTime Fecha { get;  set; }

        // Constructor sin parámetros (si es necesario)
        public Pedido()
        {
            // Inicializa la lista de productos si es necesario
            Productos = new List<Producto>();
        }

        public Pedido(string cliente, List<Producto> productos)
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
