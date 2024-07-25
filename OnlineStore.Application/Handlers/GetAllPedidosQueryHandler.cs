using AutoMapper;
using MediatR;
using OnlineStore.Application.Dtos;
using OnlineStore.Application.Query;
using OnlineStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Handlers
{
	public class GetAllPedidosQueryHandler : IRequestHandler<GetAllPedidosQuery, List<PedidoDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllPedidosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<List<PedidoDto>> Handle(GetAllPedidosQuery request, CancellationToken cancellationToken)
		{
			var pedidos = await _unitOfWork.PedidoRepository.GetAllAsync();
			return _mapper.Map<List<PedidoDto>>(pedidos);
		}
	}
}
