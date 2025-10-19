using AppSorvesanWeb.DTOs;
using AppSorvesanWeb.Models;

namespace AppSorvesanWeb.Services
{
    public interface IPedidoService
    {
        // Contrato que define um método para buscar todos os pedidos
        Task<IEnumerable<Pedido>> GetPedidos();

        Task<Pedido?> PedidoPorId(Guid id);

        Task<Pedido> CriarPedido(PedidosCreateDTOs pedidosDto);
        Task<bool> DeletarPedido(int numeroDoPedido);

        Task<Pedido?> AtualizarPedido(int numeroDoPedido, AtualizarPedidoDTO atualizarPedido);
    }
}
