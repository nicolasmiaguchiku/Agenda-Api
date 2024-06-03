using Microsoft.EntityFrameworkCore;
using AgendaApi.Entities;

namespace AgendaApi.Contexts
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Contatos> Contatos { get; set; }
    }
}
