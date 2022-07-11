using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebService.Financeiro.Model;

namespace WebService.Financeiro.Data
{
    public class WebServiceFinanceiroContext : DbContext
    {
        public WebServiceFinanceiroContext (DbContextOptions<WebServiceFinanceiroContext> options)
            : base(options)
        {
        }
        public class WebServiceFinanceiroFactory : IDesignTimeDbContextFactory<WebServiceFinanceiroContext>
        {
            public WebServiceFinanceiroContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<WebServiceFinanceiroContext>();
                optionsBuilder.UseSqlServer("Server=WDSBRCBO-00036\\SQL2019;Database=WebServiceFinanceiro;User Id=sa;Password=_43690sa");

                return new WebServiceFinanceiroContext(optionsBuilder.Options);
            }
        }
        public DbSet<Gasto> Gastos { get; set; }
    }
}
