using Microsoft.EntityFrameworkCore;
using PruebaDesempeño.Models;

namespace PruebaDesempeño.Data;

public class MysqlDbContext : DbContext
{
   public MysqlDbContext(DbContextOptions<MysqlDbContext> options) : base(options){}

   public DbSet<Usuario> Usuario { get; set; } 
   public DbSet<EspacioDeportivo> EspacioDeportivo { get; set; }
   public DbSet<Reservas> Reservas { get; set; }
}
// MIGRACION 
//dotnet ef migrations add InitialCreate
// dotnet ef database update