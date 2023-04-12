using Microsoft.EntityFrameworkCore;
using modulo1_Semana09.Models;



namespace modulo1_Semana09.Context
{
    public class SemanaContext : DbContext
    {
        public SemanaContext(DbContextOptions<SemanaContext> options) : base(options)
        {
            
        }
        public DbSet<SemanaModel> Semana { get; set; } 
    }
}
