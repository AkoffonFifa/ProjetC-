using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetC_.Models;

namespace ProjetC_.Data
{
    public class ProjetC_Context : DbContext
    {
        public ProjetC_Context (DbContextOptions<ProjetC_Context> options)
            : base(options)
        {
        }

        public DbSet<ProjetC_.Models.Anime> Anime { get; set; } = default!;

        public DbSet<ProjetC_.Models.Client>? Client { get; set; }

        public DbSet<ProjetC_.Models.Admin>? Admin { get; set; }

        public DbSet<ProjetC_.Models.Categorie>? Categorie { get; set; }
    }
}
