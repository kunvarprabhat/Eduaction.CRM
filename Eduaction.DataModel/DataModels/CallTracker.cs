using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class CallTracker
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int RemarkAddBy { get; set; }

    public string? Remark { get; set; }

    public DateTime? FollowDate { get; set; }

    public DateTime FollowTime { get; set; }

    public int AddedBy { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }

    public virtual StudentEntryModule Student { get; set; } = null!;
}
