using Microsoft.EntityFrameworkCore;

namespace _20180429.Models {
    public class BDadosContext : DbContext {
        public BDadosContext(DbContextOptions<BDadosContext> options) : base(options)
        {
            
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
    }
}