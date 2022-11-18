using Microsoft.EntityFrameworkCore;
using payment_api_desafio.Models;

namespace payment_api_desafio.Context
{
    public class VendasContext : DbContext
    {
        public VendasContext(DbContextOptions<VendasContext> options) : base(options)
        {

        }   

        public DbSet<Venda> Venda {get; set;}
        public DbSet<Item> Item {get; set;}
        public DbSet<Vendedor> Vendedor {get; set;}
    }
}