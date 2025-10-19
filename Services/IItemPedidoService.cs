using AppSorvesanWeb.DTOs;
using AppSorvesanWeb.Models;

namespace AppSorvesanWeb.Services
{
    public interface IItemPedidoService
    {
        public Task<ItensPedido?> CriarItemDoPedido(Guid pedidoId, ItemPedidoDTO itemDoPedido);
    }
}
