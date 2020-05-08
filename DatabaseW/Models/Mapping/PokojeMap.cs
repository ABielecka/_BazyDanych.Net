using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DatabaseW.Models.Mapping
{
    public class PokojeMap : EntityTypeConfiguration<Pokoje>
    {
        public PokojeMap()
        {
            HasKey(k => k.IdPokoju);
            Property(k => k.IdPokoju).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(k => k.MetrazPokoju).IsRequired();
            Property(k => k.IloscOsobwPokoju).IsRequired();
            Property(k => k.Opis).IsRequired();
            Property(k => k.CenaWynajmuPokoju).IsRequired();
            Property(k => k.OkresWynajmuOd).IsRequired();
            Property(k => k.OkresWynajmuDo).IsOptional();
            Property(k => k.Status).IsRequired();

            ToTable("POKOJE");
            Property(k => k.IdPokoju).HasColumnName("ID");
            Property(k => k.MetrazPokoju).HasColumnName("METRAZ");
            Property(k => k.IloscOsobwPokoju).HasColumnName("MAX_ILOSC_OSOB");
            Property(k => k.Opis).HasColumnName("OPIS");
            Property(k => k.CenaWynajmuPokoju).HasColumnName("CENA");
            Property(k => k.OkresWynajmuOd).HasColumnName("OKRES_WYNAJMU_OD");
            Property(k => k.OkresWynajmuDo).HasColumnName("OKRES_WYNAJMU_DO");
            Property(k => k.Status).HasColumnName("STATUS");

            HasMany(k => k.Wyposazenie).WithRequired().Map(k => k.MapKey("ID_POKOJU")).WillCascadeOnDelete(true);
        }
    }
}
