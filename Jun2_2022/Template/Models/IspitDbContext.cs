using Microsoft.EntityFrameworkCore;
using Template.Models;

namespace Models
{
    public class IspitDbContext : DbContext
    {
        // DbSet...
        public DbSet<Dostava> Dostave {get;set;}

        public DbSet<Kompanija> Kompanije {get;set;}
        public DbSet<TipPrevoza> TipoviPrevoza {get;set;}
        public DbSet<Vozilo> Vozila {get;set;}

        public IspitDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
