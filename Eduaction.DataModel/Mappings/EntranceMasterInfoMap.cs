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
    public class EntranceMasterInfoMap
    {
        public EntranceMasterInfoMap(EntityTypeBuilder<EntranceMaster> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_Entrance Master");

            entity.ToTable("EntranceMaster");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.EntranceCode).HasMaxLength(10);
            entity.Property(e => e.EntranceName).HasMaxLength(150);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(250)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(500);
        }
    }
}
