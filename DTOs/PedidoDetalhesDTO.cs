namespace AppSorvesanWeb.DTOs
{
    public class PedidoDetalhesDTO
    {
        public Guid Id { get; set; }
        public int NumeroDoPedido { get; set; }
        public string NomeDoCliente { get; set; }
        public string  TelefoneDoCliente { get; set; }
        public string? Observacoes { get; set; }
        public string Status { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTimeOffset CriadoEm { get; set; }

        public List<ItemPedidoDTO> Itens { get; set; } = new List<ItemPedidoDTO>();
    }
}
