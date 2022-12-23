using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NicaBus.Models;

namespace NicaBus.Data
{
    public class NicaBusContext : DbContext
    {
        public NicaBusContext (DbContextOptions<NicaBusContext> options)
            : base(options)
        {
        }

        public DbSet<NicaBus.Models.Users> Users { get; set; } = default!;

        public DbSet<NicaBus.Models.DetallesViaje> DetallesViaje { get; set; }

        public DbSet<NicaBus.Models.MostrarRuta> MostrarRuta { get; set; }

        public DbSet<NicaBus.Models.Account> Account { get; set; }
    }
}
