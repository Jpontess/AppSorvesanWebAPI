using AppSorvesanWeb.DTOs;
using AppSorvesanWeb.Models;

namespace AppSorvesanWeb.Services
{
    public interface IPedidoService
    {
        // Contrato que define um método para buscar todos os pedidos
        Task<IEnumerable<PedidoResumoDTO>> GetPedidos();


        Task<Pedido> CriarPedido(PedidosCreateDTOs pedidosDto);
        Task<bool> DeletarPedido(int numeroDoPedido);

        Task<Pedido?> AtualizarPedido(int numeroDoPedido, AtualizarPedidoDTO atualizarPedido);
        Task<PedidoDetalhesDTO?> GetPedidoPorId(Guid id);
    }
}
