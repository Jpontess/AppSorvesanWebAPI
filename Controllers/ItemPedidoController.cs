using AppSorvesanWeb.DTOs;
using AppSorvesanWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppSorvesanWeb.Controllers;

[ApiController]
[Route("/pedidos/{pedidoId}/Itens")]
public class ItemPedidoController : Controller
{
    private readonly IItemPedidoService _itemPedido;

    public ItemPedidoController(IItemPedidoService itemPedido)
    {
        _itemPedido = itemPedido;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarItem(Guid pedidoId, [FromBody] ItemPedidoDTO itemDto)
    {
        if(itemDto == null)
        {
            return BadRequest("Os dados do item não pode ser nulos.");
        }

        var itemCriado = await _itemPedido.CriarItemDoPedido(pedidoId, itemDto);

        if(itemCriado == null)
        {
            return NotFound($"Pedido com ID {pedidoId} não foi encotrado");
        }
        return Ok(itemCriado);
    }
}
