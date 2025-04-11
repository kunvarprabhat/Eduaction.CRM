using Microsoft.EntityFrameworkCore;
using Eduaction.DataModel.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Eduaction.DataModel.Mappings
{
    public class CityMasterInfoMap
    {
        public CityMasterInfoMap(EntityTypeBuilder<CityMaster> entity)
        {
            entity.ToTable("CityMaster");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.CityCode).HasMaxLength(10);
            entity.Property(e => e.CityName).HasMaxLength(150);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(250)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.HasOne(d => d.State).WithMany(p => p.CityMasters)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CityMaster_StateMaster");
        }
    }
}
