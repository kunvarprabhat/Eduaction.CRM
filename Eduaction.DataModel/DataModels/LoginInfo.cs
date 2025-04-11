using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class LoginInfo
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string LoginId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsFirstLogin { get; set; }

    public string? Remark { get; set; }

    public int AddedBy { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }

    public virtual EmployeeMaster Employee { get; set; } = null!;
}
