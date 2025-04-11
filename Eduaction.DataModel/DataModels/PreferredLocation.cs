using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class PreferredLocation
{
    public int StudentId { get; set; }

    public int CityId { get; set; }

    public virtual CityMaster City { get; set; } = null!;

    public virtual StudentEntryModule Student { get; set; } = null!;
}
