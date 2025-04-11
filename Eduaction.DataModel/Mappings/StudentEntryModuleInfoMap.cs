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
    public class StudentEntryModuleInfoMap
    {
        public StudentEntryModuleInfoMap(EntityTypeBuilder<StudentEntryModule> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_Student Entry Module");

            entity.ToTable("StudentEntryModule");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.AlternativeMobile).HasMaxLength(10);
            entity.Property(e => e.Area).HasMaxLength(150);
            entity.Property(e => e.Budget).HasMaxLength(150);
            entity.Property(e => e.CastId).HasColumnName("CastID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CollageStatusId).HasColumnName("CollageStatusID");
            entity.Property(e => e.Dob)
                        .HasColumnType("datetime")
                        .HasColumnName("DOB");
            entity.Property(e => e.EmailId)
                        .HasMaxLength(150)
                        .HasColumnName("EmailID");
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.FatherOccupation).HasMaxLength(150);
            entity.Property(e => e.Finance).HasMaxLength(50);
            entity.Property(e => e.FullAddress).HasMaxLength(500);
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.GraduationPerc).HasColumnType("decimal(2, 2)");
            entity.Property(e => e.Hscperc)
                        .HasColumnType("decimal(2, 2)")
                        .HasColumnName("HSCPerc");
            entity.Property(e => e.Ipaddress)
                        .HasMaxLength(250)
                        .HasColumnName("IPAddress");
            entity.Property(e => e.Mobile).HasMaxLength(10);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.MotherName).HasMaxLength(50);
            entity.Property(e => e.OfficeVisitDate).HasColumnType("datetime");
            entity.Property(e => e.Pincode).HasMaxLength(6);
            entity.Property(e => e.PreferedCollage).HasMaxLength(150);
            entity.Property(e => e.PreferredLocation).HasMaxLength(150);
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.Sscperc)
                        .HasColumnType("decimal(2, 2)")
                        .HasColumnName("SSCPerc");
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.StudentName).HasMaxLength(150);

            entity.HasOne(d => d.Cast).WithMany(p => p.StudentEntryModules)
                        .HasForeignKey(d => d.CastId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_StudentEntryModule_CastCategory");

            entity.HasOne(d => d.City).WithMany(p => p.StudentEntryModules)
                        .HasForeignKey(d => d.CityId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_StudentEntryModule_CityMaster");

            entity.HasOne(d => d.CollageStatus).WithMany(p => p.StudentEntryModules)
                        .HasForeignKey(d => d.CollageStatusId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_StudentEntryModule_CollegeStatus");

            entity.HasOne(d => d.Gender).WithMany(p => p.StudentEntryModules)
                        .HasForeignKey(d => d.GenderId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_StudentEntryModule_GenderMaster");

            entity.HasOne(d => d.State).WithMany(p => p.StudentEntryModules)
                        .HasForeignKey(d => d.StateId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_StudentEntryModule_StateMaster");
        }
    }
}
