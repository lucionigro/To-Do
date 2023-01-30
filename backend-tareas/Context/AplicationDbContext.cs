using backend_tareas.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_tareas.Context
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext (DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Tarea> Tareas { get; set; }
    }
}
