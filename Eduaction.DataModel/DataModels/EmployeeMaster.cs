using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class EmployeeMaster
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string EmpCode { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string? Remark { get; set; }

    public int AddedBy { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<LoginInfo> LoginInfos { get; set; } = new List<LoginInfo>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
