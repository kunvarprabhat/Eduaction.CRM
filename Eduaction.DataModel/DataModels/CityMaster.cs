using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class CityMaster
{
    public int Id { get; set; }

    public int StateId { get; set; }

    public string CityName { get; set; } = null!;

    public string CityCode { get; set; } = null!;

    public string? Remark { get; set; }

    public int AddedBy { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<CollegeMaster> CollegeMasters { get; set; } = new List<CollegeMaster>();

    public virtual StateMaster State { get; set; } = null!;

    public virtual ICollection<StudentEntryModule> StudentEntryModules { get; set; } = new List<StudentEntryModule>();
}
