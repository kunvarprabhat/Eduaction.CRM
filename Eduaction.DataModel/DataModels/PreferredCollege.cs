using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class PreferredCollege
{
    public int StudentId { get; set; }

    public int CollageId { get; set; }

    public virtual CollegeMaster Collage { get; set; } = null!;

    public virtual StudentEntryModule Student { get; set; } = null!;
}
