using Eduaction.DataModel.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduaction.DataModel.Mappings
{
    public class FollowUpInfoMap
    {
        public FollowUpInfoMap(EntityTypeBuilder<FollowUp> entity)
        {
            entity.ToTable("FollowUp");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.FollowUp1).HasColumnName("FollowUp");
            entity.Property(e => e.Ipaddress)
                        .HasMaxLength(250)
                        .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NextFollowUp).HasColumnType("datetime");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Student).WithMany(p => p.FollowUps)
                        .HasForeignKey(d => d.StudentId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FollowUp_StudentEntryModule");
        }
    }
}
