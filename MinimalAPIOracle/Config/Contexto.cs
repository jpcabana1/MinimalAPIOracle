using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Models;

namespace MinimalAPIOracle.Config
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Countries> Countries { get; set; }
    }
}
