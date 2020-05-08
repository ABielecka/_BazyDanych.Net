using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DatabaseW.Models.Mapping
{
    class Wyposazenie_pokojuMap : EntityTypeConfiguration<Wyposazenie_pokoju>
    {
        public Wyposazenie_pokojuMap()
        {
            HasKey(k => k.IdWyposazeniaPokoju);
            Property(k => k.IdWyposazeniaPokoju).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable("WYPOSAZENIE_POKOJU");
            Property(k => k.IdWyposazeniaPokoju).HasColumnName("ID");

            HasRequired(k => k.Wyposazenie).WithMany().Map(k => k.MapKey("ID_WYPOSAZENIA_P")).WillCascadeOnDelete(false);
        }
    }
}
