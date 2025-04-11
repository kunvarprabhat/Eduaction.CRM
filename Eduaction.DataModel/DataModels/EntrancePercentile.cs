using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class EntrancePercentile
{
    public int StudentId { get; set; }

    public int EntranceId { get; set; }

    public decimal Percentile { get; set; }

    public virtual EntranceMaster Entrance { get; set; } = null!;

    public virtual StudentEntryModule Student { get; set; } = null!;
}
