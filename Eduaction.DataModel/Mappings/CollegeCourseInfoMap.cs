using Eduaction.DataModel.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eduaction.DataModel.Mappings
{
    public class CollegeCourseInfoMap
    {
        public CollegeCourseInfoMap(EntityTypeBuilder<CollegeCourse> entity)
        {
            entity.HasNoKey().ToTable("CollegeCourse");
            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.HasOne(d => d.College).WithMany()
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollegeCourse_CollegeMaster");
            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollegeCourse_CourseMaster");
        }
    }
}
