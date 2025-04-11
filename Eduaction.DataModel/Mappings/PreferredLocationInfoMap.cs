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
    public class PreferredLocationInfoMap
    {
        public PreferredLocationInfoMap(EntityTypeBuilder<PreferredLocation> entity)
        {
            entity
      .HasNoKey()
              .ToTable("PreferredLocation");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.City).WithMany()
                        .HasForeignKey(d => d.CityId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PreferredLocation_CityMaster");

            entity.HasOne(d => d.Student).WithMany()
                        .HasForeignKey(d => d.StudentId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PreferredLocation_StudentEntryModule");
        }
    }
}
