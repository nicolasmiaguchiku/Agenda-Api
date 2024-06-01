using Microsoft.EntityFrameworkcore;
using AgendaApi.Entities;
using System.Data.Entity;

namespace AgendaApi.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContext<AgendaContext> options): base(options)
        {

        }

        public DbSet<Contatos> Contatos { get; set; }
    }
}
