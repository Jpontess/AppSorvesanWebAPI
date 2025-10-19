using System.ComponentModel.DataAnnotations;

namespace AppSorvesanWeb.DTOs
{
    public class AtualizarPedidoDTO
    {
        [Required(ErrorMessage = "Status é um campo obrigatório")]
        public string? Status { get; set; }
        public string? Observacoes { get; set; }
    }
}
