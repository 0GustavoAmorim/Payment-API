namespace payment_api_desafio.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public Decimal Valor { get; set; }
        public Vendedor Vendedor { get; set; }
        public virtual IEnumerable<Item> Itens { get; set; }
        public Status Status { get; set; }
    }
}