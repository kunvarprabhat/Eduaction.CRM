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
    public class RefreshTokenInfoMap
    {
        public RefreshTokenInfoMap(EntityTypeBuilder<RefreshToken> entity) 
        {
            entity.HasKey(e => e.TokenId);

            entity.ToTable("RefreshToken");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.Token).HasMaxLength(500);

            entity.HasOne(d => d.Employee).WithMany(p => p.RefreshTokens)
                        .HasForeignKey(d => d.EmployeeId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RefreshToken_EmployeeMaster");
        }
    }
}
