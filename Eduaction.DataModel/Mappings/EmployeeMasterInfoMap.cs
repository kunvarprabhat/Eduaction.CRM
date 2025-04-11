using Eduaction.DataModel.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eduaction.DataModel.Mappings
{
    public class EmployeeMasterInfoMap
    {
        public EmployeeMasterInfoMap(EntityTypeBuilder<EmployeeMaster> entity)
        {
            entity.ToTable("EmployeeMaster");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.EmailId)
                        .HasMaxLength(150)
                        .HasColumnName("EmailID");
            entity.Property(e => e.EmpCode).HasMaxLength(10);
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.Ipaddress)
                        .HasMaxLength(250)
                        .HasColumnName("IPAddress");
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.MiddleName).HasMaxLength(10);
            entity.Property(e => e.MobileNo).HasMaxLength(10);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(500);

            entity.HasMany(d => d.Roles).WithMany(p => p.Employees)
                        .UsingEntity<Dictionary<string, object>>(
                            "LoginRole",
                            r => r.HasOne<Role>().WithMany()
                                .HasForeignKey("RoleId")
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_LoginRole_Role"),
                            l => l.HasOne<EmployeeMaster>().WithMany()
                                .HasForeignKey("EmployeeId")
                                .OnDelete(DeleteBehavior.ClientSetNull)
                                .HasConstraintName("FK_LoginRole_EmployeeMaster"),
                            j =>
                            {
                                j.HasKey("EmployeeId", "RoleId");
                                j.ToTable("LoginRole");
                                j.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");
                                j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");
                            });
        }
    }
}
