using AppSorvesanWeb.DTOs;
using AppSorvesanWeb.Models;
using AppSorvesanWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppSorvesanWeb.Controllers;

[ApiController]
[Route("/[controller]")]
public class PedidosController : Controller
{
    private readonly IPedidoService _pedidoService;
    
    public PedidosController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pedido>>> ListaDePedidos()
    {
        var pedidos = await _pedidoService.GetPedidos();

        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pedido>> PedidosPorId(Guid id)
    {
        var pedidos = await _pedidoService.PedidoPorId(id);
        if (pedidos == null)
        {
            return NotFound();
        }
        
        return Ok(pedidos);
    }

    [HttpPost]
    public async Task<ActionResult<Pedido>> CriarPedido([FromBody] PedidosCreateDTOs pedidos)
    {
        if(pedidos == null)
        {
            return BadRequest();
        }
        try
        {
            var pedidoCriado = await _pedidoService.CriarPedido(pedidos);
            return CreatedAtAction(nameof(PedidosPorId), new { id = pedidoCriado.Id }, pedidoCriado );
        }
        catch (Exception ex)
        {
            return Json(ex.Message + "\n" + ex.InnerException);
        }
    }

    [HttpDelete("{numeroDoPedido}")]
    public async Task<ActionResult> DeletarPedido(int numeroDoPedido)
    {
        try
        {
           
            var pedidos = await _pedidoService.DeletarPedido(numeroDoPedido);

            if (!pedidos)
            {
                return NotFound($"Pedido com o número {numeroDoPedido} não encotrado");
            }


            return NoContent();
        }
        catch(Exception ex)
        {
            return NotFound(ex.Message + ex.InnerException); 
        }
    }


    [HttpPut("{numeroDoPedido}")]
    public async Task<IActionResult> AtualizarPedido (int numeroDoPedido, [FromBody] AtualizarPedidoDTO pedido)
    {
        if (pedido == null)
        {
            return BadRequest("Os dados para a atualização não pode ser nulos!!");
        }

        var pedidoAtualizados = await _pedidoService.AtualizarPedido(numeroDoPedido, pedido);

        if(pedidoAtualizados == null)
        {
            return NotFound($"o pedido com este número {numeroDoPedido} não foi encontrado");
        }
        return Ok(pedidoAtualizados);
    }
}
