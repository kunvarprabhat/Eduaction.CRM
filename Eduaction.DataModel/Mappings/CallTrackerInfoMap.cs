using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Eduaction.DataModel.DataModels;

namespace Eduaction.DataModel.Mappings
{
    public class CallTrackerInfoMap
    {
        public  CallTrackerInfoMap(EntityTypeBuilder<CallTracker> entity)
        {
            entity.ToTable("CallTracker");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.FollowDate).HasColumnType("datetime");
            entity.Property(e => e.FollowTime).HasColumnType("datetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(250)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Student).WithMany(p => p.CallTrackers)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CallTracker_StudentEntryModule");
        }
    }
}
