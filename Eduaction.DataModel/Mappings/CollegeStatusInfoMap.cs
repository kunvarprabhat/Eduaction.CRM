using Eduaction.DataModel.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eduaction.DataModel.Mappings
{
    public class CollegeStatusInfoMap
    {
        public CollegeStatusInfoMap(EntityTypeBuilder<CollegeStatus> entity) 
        {
            entity.HasKey(e => e.Id).HasName("PK_College Status");
            entity.ToTable("CollegeStatus");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(250)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.StatusCode).HasMaxLength(10);
            entity.Property(e => e.StatusName).HasMaxLength(150);
        }
    }
}
