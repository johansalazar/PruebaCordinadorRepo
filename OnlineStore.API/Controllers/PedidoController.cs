using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Commands;
using OnlineStore.Application.Query;

namespace OnlineStore.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PedidoController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PedidoController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/pedidos
		[HttpGet]
		public async Task<IActionResult> ListarPedidos()
		{
            var query = new GetAllPedidosQuery();
            var pedidos = await _mediator.Send(query);
            return Ok(pedidos);
        }

		// GET: api/pedidos/{id}
		[HttpGet("{id}")]
		public async Task<IActionResult> ObtenerPedido(int id)
		{
			var pedido = await _mediator.Send(new GetPedidoByIdQuery(id));
			if (pedido == null)
			{
				return NotFound();
			}
			return Ok(pedido);
		}

		// POST: api/pedidos
		[HttpPost]
		public async Task<IActionResult> CrearPedido([FromBody] CrearPedidoCommand command)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var pedidoId = await _mediator.Send(command);
			return CreatedAtAction(nameof(ObtenerPedido), new { id = pedidoId }, command);
		}

		// PUT: api/pedidos/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> ActualizarPedido(int id, [FromBody] ActualizarPedidoCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}

			await _mediator.Send(command);
			return NoContent();
		}

		// DELETE: api/pedidos/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> EliminarPedido(int id)
		{
			await _mediator.Send(new EliminarPedidoCommand(id));
			return NoContent();
		}
	}
}
