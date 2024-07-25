using AutoMapper;
using MediatR;
using OnlineStore.Application.Dtos;
using OnlineStore.Application.Exceptions;
using OnlineStore.Application.Query;
using OnlineStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Handlers
{
	public class GetPedidoByIdQueryHandler : IRequestHandler<GetPedidoByIdQuery, PedidoDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetPedidoByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<PedidoDto> Handle(GetPedidoByIdQuery request, CancellationToken cancellationToken)
		{
			var pedido = await _unitOfWork.PedidoRepository.GetByIdAsync(request.Id);
			if (pedido == null)
			{
				// Opcional: Lanzar una excepción o retornar un error
				throw new NotFoundException("Pedido no encontrado");
			}

			return _mapper.Map<PedidoDto>(pedido);
		}
	}
}
