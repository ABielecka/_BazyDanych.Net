using DatabaseW.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Property_rental.Models.Mapping
{
    public class Wyposazenie_nieruchomosciMap : EntityTypeConfiguration<Wyposazenie_nieruchomosci>
    {
        public Wyposazenie_nieruchomosciMap()
        {
            HasKey(k => k.IdWyposazeniaNieruchomosci);
            Property(k => k.IdWyposazeniaNieruchomosci).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable("WYPOSAZENIE_NIERUCHOMOSCI");
            Property(k => k.IdWyposazeniaNieruchomosci).HasColumnName("ID");

            HasRequired(k => k.Wyposazenie).WithMany().Map(k => k.MapKey("ID_WYPOSAZENIA_N")).WillCascadeOnDelete(false);
        }
    }
}
