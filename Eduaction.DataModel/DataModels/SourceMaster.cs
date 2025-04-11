using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class SourceMaster
{
    public int Id { get; set; }

    public string SourceName { get; set; } = null!;

    public string? SourceCode { get; set; }

    public string? Remark { get; set; }

    public int AddedBy { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }
}
