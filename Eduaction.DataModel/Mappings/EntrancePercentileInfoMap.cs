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
    public class EntrancePercentileInfoMap
    {
        public EntrancePercentileInfoMap(EntityTypeBuilder<EntrancePercentile> entity)
        {
            entity
                    .HasNoKey()
                    .ToTable("EntrancePercentile");

            entity.Property(e => e.EntranceId).HasColumnName("EntranceID");
            entity.Property(e => e.Percentile).HasColumnType("decimal(2, 2)");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Entrance).WithMany()
                .HasForeignKey(d => d.EntranceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EntrancePercentile_EntranceMaster");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EntrancePercentile_StudentEntryModule");
        }
    }
}
