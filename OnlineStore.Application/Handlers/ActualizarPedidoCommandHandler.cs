using MediatR;
using OnlineStore.Application.Commands;
using OnlineStore.Application.Exceptions;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Handlers
{
	public class ActualizarPedidoCommandHandler : IRequestHandler<ActualizarPedidoCommand>
	{
		private readonly IUnitOfWork _unitOfWork;

		public ActualizarPedidoCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(ActualizarPedidoCommand request, CancellationToken cancellationToken)
		{
			// Obtener el pedido existente
			var pedido = await _unitOfWork.PedidoRepository.GetByIdAsync(request.Id);
			if (pedido == null)
			{
				// Lanzar una excepción personalizada si el pedido no se encuentra
				throw new NotFoundException("Pedido no encontrado");
			}

			// Actualizar las propiedades del pedido
			
			pedido.Productos = request.Productos.Select(p => new Producto(p.Id, p.Nombre, p.Precio)).ToList(); // Proporcionar todos los argumentos necesarios
			pedido.Total = request.Total;
			pedido.Fecha = request.Fecha;

			// Aplicar los cambios
			_unitOfWork.PedidoRepository.AddAsync(pedido);
			await _unitOfWork.CommitAsync(); // Guardar cambios en la base de datos

			return Unit.Value;
		}
	}
}
