using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                
        }
        public ApplicationDbContext()
        {

        }
        public DbSet<Serveur> Serveurs { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Consommation> Consommations { get; set; }
    }
}
