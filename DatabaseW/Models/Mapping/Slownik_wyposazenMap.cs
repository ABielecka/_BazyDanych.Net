using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DatabaseW.Models
{
    class Slownik_wyposazenMap : EntityTypeConfiguration<Slownik_wyposazen>
    {
        public Slownik_wyposazenMap()
        {
            HasKey(k => k.IdWyposazenia);
            Property(k => k.IdWyposazenia).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(k => k.Opis).IsRequired().HasMaxLength(100);

            ToTable("SL_WYPOSAZEN");
            Property(k => k.IdWyposazenia).HasColumnName("ID");
            Property(k => k.Opis).HasColumnName("OPIS");
        }
    }
}
