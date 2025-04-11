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
    public class PreferredCollegeInfoMap
    {
        public PreferredCollegeInfoMap(EntityTypeBuilder<PreferredCollege> entity)
        {
            entity
        .HasNoKey()
                .ToTable("PreferredCollege");

            entity.Property(e => e.CollageId).HasColumnName("CollageID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Collage).WithMany()
                        .HasForeignKey(d => d.CollageId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PreferredCollege_CollegeMaster");

            entity.HasOne(d => d.Student).WithMany()
                        .HasForeignKey(d => d.StudentId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PreferredCollege_StudentEntryModule");
        }
    }
}
