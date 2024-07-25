using MediatR;
using OnlineStore.Application.Commands;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Handlers
{
	public class CrearPedidoCommandHandler : IRequestHandler<CrearPedidoCommand, int>
	{
		private readonly IUnitOfWork _unitOfWork;

		public CrearPedidoCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<int> Handle(CrearPedidoCommand request, CancellationToken cancellationToken)
		{
			var pedido = new Pedido(request.Cliente, request.Productos.Select(p => new Producto(p.Id, p.Nombre, p.Precio)).ToList());
			_unitOfWork.PedidoRepository.AddAsync(pedido);
			await _unitOfWork.SaveChangesAsync();
			return pedido.Id;
		}
	}
}
