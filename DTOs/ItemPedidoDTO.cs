namespace AppSorvesanWeb.DTOs
{
    public class ItemPedidoDTO
    {

        public Guid Id { get; set; }
        public string  NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public string? Customizacoes { get; set; }
    }
}
