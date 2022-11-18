namespace payment_api_desafio.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string NomeItem { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}