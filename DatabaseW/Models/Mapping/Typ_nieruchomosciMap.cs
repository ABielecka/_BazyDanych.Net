using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DatabaseW.Models.Mapping
{
    public class Typ_nieruchomosciMap : EntityTypeConfiguration<Typ_nieruchomosci>
    {
        public Typ_nieruchomosciMap()
        {
            HasKey(k => k.IdTyp);
            Property(k => k.IdTyp).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(k => k.Opis).IsRequired().HasMaxLength(1000);

            ToTable("SL_TYP_NIERUCHOMOSCI");
            Property(k => k.IdTyp).HasColumnName("ID");
            Property(k => k.Opis).HasColumnName("TYP");
        }
    }
}
