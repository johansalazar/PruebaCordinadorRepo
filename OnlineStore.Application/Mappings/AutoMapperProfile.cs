using AutoMapper;
using OnlineStore.Application.Dtos;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Mappings
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Pedido, PedidoDto>();
            CreateMap<Producto, ProductoDto>();

            // Otros mapeos si los hay...
        }
	}
}
