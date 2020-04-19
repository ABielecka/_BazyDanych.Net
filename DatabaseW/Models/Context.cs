using DatabaseW;
using DatabaseW.Models;
using DatabaseW.Models.Mapping;
using Oracle.ManagedDataAccess.Client;
using Property_rental.Models.Mapping;
using System.Data.Entity;

namespace Property_rental.Models
{
    public class Context : DbContext
    {
        static Context()
        {
            System.Data.Entity.Database.SetInitializer<Context>(null); //normalna praca
            //System.Data.Entity.Database.SetInitializer<Context>(new DropCreateDatabaseAlways<Context>()); //za kazdym razem usunie istniejace tabele z bazy danych i utworzy je od nowa
            //System.Data.Entity.Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>()); //jeżeli zmieni się coś w modelach to wywali całą bazę danych i zalozy od nowa
        }
        public Context() : base(new OracleConnection(App._conString), false)
        {
        }

        public DbSet<Osoby> Osobies { get; set; }
        public DbSet<Slownik_Wojewodztw> Slownik_Wojewodztws { get; set; }
        public DbSet<Nieruchomosci> Nieruchomoscis { get; set; }
        public DbSet<Pokoje> Pokojes { get; set; }
        public DbSet<Slownik_wyposazen> Slownik_Wyposazens { get; set; }
        public DbSet<Typ_nieruchomosci> Typ_Nieruchomoscis { get; set; }
        public DbSet<Najem> Najems { get; set; }
        public DbSet<Wyposazenie_nieruchomosci> Wyposazenie_Nieruchomoscis { get; set; }
        public DbSet<Wyposazenie_pokoju> Wyposazenie_Pokojus { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("PROPERTY_RENT");

            modelBuilder.Configurations.Add(new OsobyMap());
            modelBuilder.Configurations.Add(new Slownik_WojewodztwMap());
            modelBuilder.Configurations.Add(new NieruchomosciMap());
            modelBuilder.Configurations.Add(new PokojeMap());
            modelBuilder.Configurations.Add(new Slownik_wyposazenMap());
            modelBuilder.Configurations.Add(new Typ_nieruchomosciMap());
            modelBuilder.Configurations.Add(new NajemMap());
            modelBuilder.Configurations.Add(new Wyposazenie_nieruchomosciMap());
            modelBuilder.Configurations.Add(new Wyposazenie_pokojuMap());

        }
    }
}
