using AppSorvesanWeb.Data;
using AppSorvesanWeb.DTOs;
using AppSorvesanWeb.Models;

namespace AppSorvesanWeb.Services;

public class ItemPedidoService : IItemPedidoService
{
    private readonly SorveteriaContext _sorveteriaContext;

    public ItemPedidoService(SorveteriaContext sorveteriaContext)
    {
        _sorveteriaContext = sorveteriaContext;
    }

    public async Task<ItensPedido?> CriarItemDoPedido(Guid pedidoId, ItemPedidoDTO itemPedido)
    {
        var pedido = await _sorveteriaContext.Pedidos.FindAsync(pedidoId);

        if (pedido == null)
        {
            return null;
        }

        var novoItem = new ItensPedido
        {
            PedidoId = pedidoId,
            NomeProduto = itemPedido.NomeProduto,
            Quantidade = itemPedido.Quantidade,
            Preco = itemPedido.Preco,
            Customizacoes = itemPedido.Customizacoes
        };

        pedido.ValorTotal += (novoItem.Quantidade * novoItem.Preco);

        _sorveteriaContext.ItensPedidos.Add(novoItem);
        await _sorveteriaContext.SaveChangesAsync();

        return novoItem;
    }

}
