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
    public class CollageLeadProcessInfoMap
    {
        public CollageLeadProcessInfoMap(EntityTypeBuilder<CollageLeadProcess> entity)
        {
            entity.ToTable("CollageLeadProcess");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(250)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ProcessCode).HasMaxLength(10);
            entity.Property(e => e.ProcessDate).HasColumnType("datetime");
            entity.Property(e => e.ProcessName).HasMaxLength(150);
            entity.Property(e => e.Remark).HasMaxLength(500);

        }
    }
}
