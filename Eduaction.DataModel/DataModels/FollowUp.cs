using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class FollowUp
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public DateTime? NextFollowUp { get; set; }

    public TimeOnly? FollowUp1 { get; set; }

    public string? Remark { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public int AddedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }

    public virtual StudentEntryModule Student { get; set; } = null!;
}
