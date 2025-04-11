using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public string RoleCode { get; set; } = null!;

    public string? Remark { get; set; }

    public int AddedBy { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<EmployeeMaster> Employees { get; set; } = new List<EmployeeMaster>();
}
