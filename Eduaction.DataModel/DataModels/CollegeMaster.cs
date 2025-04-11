using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class CollegeMaster
{
    public int Id { get; set; }

    public string CollegeName { get; set; } = null!;

    public string? CollegeCode { get; set; }

    public string Location { get; set; } = null!;

    public int CityId { get; set; }

    public int StateId { get; set; }

    public string Address { get; set; } = null!;

    public string FeesStructure { get; set; } = null!;

    public string? Intake { get; set; }

    public string? Hostel { get; set; }

    public string? ApplicationForm { get; set; }

    public string? CourseHighlights { get; set; }

    public string? Complimentary { get; set; }

    public string AdmissionProcess { get; set; } = null!;

    public string? Placements { get; set; }

    public string EmailId { get; set; } = null!;

    public string? Remark { get; set; }

    public int AddedBy { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }

    public virtual CityMaster City { get; set; } = null!;

    public virtual StateMaster State { get; set; } = null!;
}
