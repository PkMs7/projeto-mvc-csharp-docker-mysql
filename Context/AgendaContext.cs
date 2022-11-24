using exemploAPI2.Models;
using Microsoft.EntityFrameworkCore;

namespace exemploAPI2.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options){


        }

        public DbSet<Contato> Contatos{ get; set; }
    }
}