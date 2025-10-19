namespace AppSorvesanWeb.DTOs;

public class PedidoResumoDTO
{
    public Guid Id { get; set; }
    public int NumeroPedido { get; set; }
    public string NomeCliente { get; set; }
    public string Status { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTimeOffset CriadoEm { get; set; }
}
