using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class CollageLeadProcess
{
    public int Id { get; set; }

    public string ProcessName { get; set; } = null!;

    public string? ProcessCode { get; set; }

    public int? OrderBy { get; set; }

    public DateTime ProcessDate { get; set; }

    public string? Remark { get; set; }

    public int AddedBy { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }
}
