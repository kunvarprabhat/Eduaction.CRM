using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class StateMaster
{
    public int Id { get; set; }

    public string StateName { get; set; } = null!;

    public string StateCode { get; set; } = null!;

    public string? Remark { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public int AddedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<CityMaster> CityMasters { get; set; } = new List<CityMaster>();

    public virtual ICollection<CollegeMaster> CollegeMasters { get; set; } = new List<CollegeMaster>();

    public virtual ICollection<StudentEntryModule> StudentEntryModules { get; set; } = new List<StudentEntryModule>();
}
