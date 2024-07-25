using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Interfaces
{
	public interface IPedidoRepository
	{
        Task AddAsync(Pedido pedido);
		Task<Pedido> GetByIdAsync(int id);
		Task<List<Pedido>> GetAllAsync();
        Task UpdateAsync(Pedido pedido);
        Task DeleteAsync(int id);
	}
}
