using DatabaseW.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Property_rental.Models.Mapping
{
    public class OsobyMap : EntityTypeConfiguration<Osoby>
    {
        public OsobyMap()
        {
            HasKey(k => k.IdOsoby);
            Property(k => k.IdOsoby).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(k => k.Nazwisko).IsRequired().HasMaxLength(100);
            Property(k => k.Imie).IsRequired().HasMaxLength(50);
            Property(k => k.MiastoZamieszkania).IsRequired().HasMaxLength(100);
            Property(k => k.UlicaZamieszkania).IsRequired().HasMaxLength(100);
            Property(k => k.DataUrodzenia).IsOptional();
            Property(k => k.Telefon).IsRequired().HasMaxLength(15);

            ToTable("OSOBY");
            Property(k => k.IdOsoby).HasColumnName("ID");
            Property(k => k.Nazwisko).HasColumnName("NAZWISKO");
            Property(k => k.Imie).HasColumnName("IMIE");
            Property(k => k.MiastoZamieszkania).HasColumnName("MIASTO_ZAMIESZKANIA");
            Property(k => k.UlicaZamieszkania).HasColumnName("ULICA_ZAMIESZKANIA");
            Property(k => k.DataUrodzenia).HasColumnName("DATA_URODZENIA");
            Property(k => k.Telefon).HasColumnName("TELEFON");

            HasRequired(k => k.WojewodztwoZamieszkania).WithMany().Map(k => k.MapKey("WOJEWODZTWO_ZAMIESZKANIA")).WillCascadeOnDelete(false);
        }
    }
}
