using Microsoft.EntityFrameworkCore;

namespace atvCarros0609.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Veiculos> veiculos { get; set; }
    }
}