using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DatabaseW.Models.Mapping
{
    class NieruchomosciMap : EntityTypeConfiguration<Nieruchomosci>
    {
        public NieruchomosciMap()
        {
            HasKey(k => k.IdNieruchomosci);
            Property(k => k.IdNieruchomosci).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(k => k.MiastoNieruchomosci).IsRequired().HasMaxLength(100);
            Property(k => k.UlicaNieruchomosci).IsRequired().HasMaxLength(100);
            Property(k => k.MetrazNieruchomosci).IsRequired();
            Property(k => k.OpisNieruchomosci).IsRequired();
            Property(k => k.CenaWynajmuNieruchomosci).IsRequired();
            Property(k => k.OkresWynajmuOd).IsRequired();
            Property(k => k.OkresWynajmuDo).IsOptional();
            Property(k => k.TypWynajmu).IsRequired().HasMaxLength(50);
            Property(k => k.Status).IsRequired();

            ToTable("NIERUCHOMOSCI");
            Property(k => k.IdNieruchomosci).HasColumnName("ID");
            Property(k => k.MiastoNieruchomosci).HasColumnName("MIASTO_NIERUCHOMOSCI");
            Property(k => k.UlicaNieruchomosci).HasColumnName("ULICA_NIERUCHOMOSCI");
            Property(k => k.MetrazNieruchomosci).HasColumnName("METRAZ");
            Property(k => k.OpisNieruchomosci).HasColumnName("OPIS");
            Property(k => k.CenaWynajmuNieruchomosci).HasColumnName("CENA");
            Property(k => k.OkresWynajmuOd).HasColumnName("OKRES_WYNAJMU_OD");
            Property(k => k.OkresWynajmuDo).HasColumnName("OKRES_WYNAJMU_DO");
            Property(k => k.TypWynajmu).HasColumnName("TYP_WYNAJMU");
            Property(k => k.Status).HasColumnName("STATUS");

            HasRequired(k => k.TypNieruchomosci).WithMany().Map(k => k.MapKey("TYP_NIERUCHOMOSCI")).WillCascadeOnDelete(false);
            HasRequired(k => k.WojewodztwoNieruchomosci).WithMany().Map(k => k.MapKey("WOJEWODZTWO_NIERUCHOMOSCI")).WillCascadeOnDelete(false);
            HasRequired(k => k.OsobaWynajmujaca).WithMany().Map(k => k.MapKey("ID_OSOBY_WYNAJMUJACEJ")).WillCascadeOnDelete(false);
            HasMany(k => k.Pokoje).WithRequired().Map(k => k.MapKey("ID_NIERUCHOMOSCI")).WillCascadeOnDelete(true);
            HasMany(k => k.Wyposazenie).WithRequired().Map(k => k.MapKey("ID_NIERUCHOMOSCI")).WillCascadeOnDelete(true);
        }
    }
}
