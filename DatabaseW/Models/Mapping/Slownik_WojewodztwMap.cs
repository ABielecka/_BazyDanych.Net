using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace DatabaseW.Models.Mapping
{
    class Slownik_WojewodztwMap : EntityTypeConfiguration<Slownik_Wojewodztw>
    {
        public Slownik_WojewodztwMap()
        {
            HasKey(k => k.IdWojewodztwa);
            Property(k => k.IdWojewodztwa).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(k => k.NazwaWojewodztwa).IsRequired().HasMaxLength(20).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            ToTable("SL_WOJEWODZTWA");
            Property(k => k.IdWojewodztwa).HasColumnName("ID");
            Property(k => k.NazwaWojewodztwa).HasColumnName("NAZWA");
        }
    }
}
