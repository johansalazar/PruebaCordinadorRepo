using MediatR;
using OnlineStore.Application.Commands;
using OnlineStore.Application.Exceptions;
using OnlineStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Handlers
{
	public class EliminarPedidoCommandHandler : IRequestHandler<EliminarPedidoCommand>
	{
		private readonly IUnitOfWork _unitOfWork;

		public EliminarPedidoCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(EliminarPedidoCommand request, CancellationToken cancellationToken)
		{
			var pedido = await _unitOfWork.PedidoRepository.GetByIdAsync(request.Id);
			if (pedido == null)
			{
				// Opcional: Lanzar una excepción o retornar un error
				throw new NotFoundException("Pedido no encontrado");
			}

			_unitOfWork.PedidoRepository.DeleteAsync(pedido.Id);
			await _unitOfWork.CommitAsync();

			return Unit.Value;
		}
	}
}
