using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppSorvesanWeb.Models;

public partial class ItensPedido
{
    public Guid Id { get; set; }

    public Guid PedidoId { get; set; }


    public string NomeProduto { get; set; } = null!;

    public int Quantidade { get; set; }

    public decimal Preco { get; set; }

    public string? Customizacoes { get; set; }

    public DateTimeOffset CriadoEm { get; set; }

    [JsonIgnore]
    public virtual Pedido Pedido { get; set; } = null!;
}
