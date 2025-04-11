using Eduaction.DataModel.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduaction.DataModel.Mappings
{
    public class SourceMasterInfoMap
    {
        public SourceMasterInfoMap(EntityTypeBuilder<SourceMaster> entity)
        {
            entity.ToTable("SourceMaster");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.Ipaddress)
                        .HasMaxLength(250)
                        .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(500);
            entity.Property(e => e.SourceCode).HasMaxLength(10);
            entity.Property(e => e.SourceName).HasMaxLength(150);
        }
    }
}
