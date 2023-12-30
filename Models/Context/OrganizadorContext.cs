using Microsoft.EntityFrameworkCore;

namespace AgendamentoDeTarefas.Models.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options) { }

        public DbSet<Tarefas> Tarefas { get; set; }
    }
}
