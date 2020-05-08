using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DatabaseW.Models.Mapping
{
    class NajemMap : EntityTypeConfiguration<Najem>
    {
        public NajemMap()
        {
            HasKey(k => k.IdWynajmu);
            Property(k => k.IdWynajmu).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(k => k.WynajemOd).IsRequired();
            Property(k => k.WynajemDo).IsRequired();
            Property(k => k.UstalonaCenaNajmu).IsRequired();

            ToTable("NAJEM");
            Property(k => k.IdWynajmu).HasColumnName("ID");
            Property(k => k.WynajemOd).HasColumnName("NAJEM_OD");
            Property(k => k.WynajemDo).HasColumnName("NAJEM_DO");
            Property(k => k.UstalonaCenaNajmu).HasColumnName("CENA_NAJMU");

            HasRequired(k => k.OsobaNajmująca).WithMany().Map(k => k.MapKey("ID_OSOBY_NAJMUJACEJ")).WillCascadeOnDelete(false);
            HasRequired(k => k.Nieruchomosc).WithMany().Map(k => k.MapKey("ID_NIERUCHOMOSCI")).WillCascadeOnDelete(false);
            HasOptional(k => k.Pokoj).WithMany().Map(k => k.MapKey("ID_POKOJU")).WillCascadeOnDelete(false);
        }
    }
}
