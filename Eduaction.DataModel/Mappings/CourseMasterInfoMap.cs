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
    public class CourseMasterInfoMap
    {
        public CourseMasterInfoMap(EntityTypeBuilder<CourseMaster> entity)
        {
            entity.ToTable("CourseMaster");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.CourseCode).HasMaxLength(10);
            entity.Property(e => e.CourseName).HasMaxLength(150);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(250)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(500);
        }
    }
}
