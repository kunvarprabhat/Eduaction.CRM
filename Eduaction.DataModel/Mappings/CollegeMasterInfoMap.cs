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
    public class CollegeMasterInfoMap
    {
        public CollegeMasterInfoMap(EntityTypeBuilder<CollegeMaster> entity)
        {
            entity.ToTable("CollegeMaster");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.AdmissionProcess).HasMaxLength(150);
            entity.Property(e => e.ApplicationForm).HasMaxLength(150);
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CollegeCode).HasMaxLength(10);
            entity.Property(e => e.CollegeName).HasMaxLength(150);
            entity.Property(e => e.Complimentary).HasMaxLength(150);
            entity.Property(e => e.CourseHighlights).HasMaxLength(150);
            entity.Property(e => e.EmailId)
                .HasMaxLength(150)
                .HasColumnName("EmailID");
            entity.Property(e => e.FeesStructure).HasMaxLength(150);
            entity.Property(e => e.Hostel).HasMaxLength(150);
            entity.Property(e => e.Intake).HasMaxLength(150);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(250)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Location).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Placements).HasMaxLength(150);
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.StateId).HasColumnName("StateID");

            entity.HasOne(d => d.City).WithMany(p => p.CollegeMasters)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollegeMaster_CityMaster");

            entity.HasOne(d => d.State).WithMany(p => p.CollegeMasters)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollegeMaster_StateMaster");
        }
    }
}
