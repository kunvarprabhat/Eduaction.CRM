using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class CollegeStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public string? StatusCode { get; set; }

    public string? Remark { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public int AddedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<StudentEntryModule> StudentEntryModules { get; set; } = new List<StudentEntryModule>();
}
