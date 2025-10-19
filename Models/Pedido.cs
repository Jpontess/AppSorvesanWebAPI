using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppSorvesanWeb.Models;

public partial class Pedido
{
    public Guid Id { get; set; }

    public int NumeroPedido { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório!")]
    [MaxLength(60)]
    public string NomeCliente { get; set; } = null!;

    [Required(ErrorMessage = "Telefone é obrigatório")]
    [MaxLength(15)]
    public string TelefoneCliente { get; set; } = null!;

    public string? Observacoes { get; set; }

    public string Status { get; set; } = null!;

    public decimal ValorTotal { get; set; }

    public DateTimeOffset CriadoEm { get; set; }

    public DateTimeOffset AtualizadoEm { get; set; }

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
}
