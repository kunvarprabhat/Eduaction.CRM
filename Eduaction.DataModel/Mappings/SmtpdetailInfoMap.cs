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
    public class SmtpdetailInfoMap
    {
        public SmtpdetailInfoMap(EntityTypeBuilder<Smtpdetail> entity)
        {
            entity.ToTable("SMTPDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.EncryptionType).HasMaxLength(50);
            entity.Property(e => e.FromAddress).HasMaxLength(150);
            entity.Property(e => e.FromName).HasMaxLength(150);
            entity.Property(e => e.Ipaddress)
                        .HasMaxLength(50)
                        .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Smtphost)
                        .HasMaxLength(150)
                        .HasColumnName("SMTPHost");
            entity.Property(e => e.Smtppassword)
                        .HasMaxLength(50)
                        .HasColumnName("SMTPPassword");
            entity.Property(e => e.Smtpport).HasColumnName("SMTPPort");
            entity.Property(e => e.Smtptoken)
                        .HasMaxLength(50)
                        .HasColumnName("SMTPToken");
            entity.Property(e => e.Smtpusername)
                        .HasMaxLength(50)
                        .HasColumnName("SMTPUsername");
        }
    }
}
