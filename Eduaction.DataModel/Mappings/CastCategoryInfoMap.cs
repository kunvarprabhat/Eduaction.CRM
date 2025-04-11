using Eduaction.DataModel.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eduaction.DataModel.Mappings
{
    public class CastCategoryInfoMap
    {
        public CastCategoryInfoMap(EntityTypeBuilder<CastCategory> entity)
        {
            entity.ToTable("CastCategory");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.CastCode).HasMaxLength(10);
            entity.Property(e => e.CastName).HasMaxLength(150);
            entity.Property(e => e.Ipaddress).HasMaxLength(250).HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(500);
        }
    }
}
