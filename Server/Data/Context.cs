public class Context : DbContext
    {
        public DbSet<Personas>? Personas { get; set; }
        public DbSet<Aportes>? Aportes { get; set; }
        public DbSet<AportesDetalle>? AporteDetalles { get; set; }
        public DbSet<TiposAportes>? TiposAportes { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TiposAportes>().HasData(
                new TiposAportes { TipoAporteId = 1, Descripcion = "Pintura Bancos", Meta = 10000, Logrado = 0 },
                new TiposAportes { TipoAporteId = 2, Descripcion = "Reparacion Techo", Meta = 20000, Logrado = 0 },
                new TiposAportes { TipoAporteId = 3, Descripcion = "Mantenimiento Piscina", Meta = 30000, Logrado = 0 },
                new TiposAportes { TipoAporteId = 4, Descripcion = "Cambio Mesas", Meta = 40000, Logrado = 0 },
                new TiposAportes { TipoAporteId = 5, Descripcion = "Compra Cortinas", Meta = 50000, Logrado = 0 }
            );
        }
    }