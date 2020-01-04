using ClinicaGAP.Models;
using System.Data.Entity.ModelConfiguration;

namespace ClinicaGAP.Persistence.EntityConfigurations
{
    public class TipoCitaConfiguration : EntityTypeConfiguration<TIPO_CITA>
    {
        public TipoCitaConfiguration()
        {
            HasKey(c => new { c.ID_TIPO_CITA });

            Property(c => c.DESCRIPCION)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.ESTADO)
                .IsRequired();
            
            //HasMany(c => c.CITA)
            //   .WithMany(t => t.DESCRIPCION)
            //   .Map(m =>
            //   {
            //       m.ToTable("CourseTags");
            //       m.MapLeftKey("CourseId");
            //       m.MapRightKey("TagId");
            //   });
        }
    }
}