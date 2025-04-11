using System;
using System.Collections.Generic;

namespace Eduaction.DataModel.DataModels;

public partial class StudentEntryModule
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string? Mobile { get; set; }

    public string AlternativeMobile { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public decimal Sscperc { get; set; }

    public decimal Hscperc { get; set; }

    public int GraduationIn { get; set; }

    public decimal? GraduationPerc { get; set; }

    public int CastId { get; set; }

    public int GenderId { get; set; }

    public int CityId { get; set; }

    public int StateId { get; set; }

    public int CollageStatusId { get; set; }

    public string Finance { get; set; } = null!;

    public string FullAddress { get; set; } = null!;

    public string? PreferredLocation { get; set; }

    public string? PreferedCollage { get; set; }

    public string? Area { get; set; }

    public string Pincode { get; set; } = null!;

    public string? Budget { get; set; }

    public string? FatherName { get; set; }

    public string? FatherOccupation { get; set; }

    public string? MotherName { get; set; }

    public DateTime? OfficeVisitDate { get; set; }

    public DateTime? Dob { get; set; }

    public string? Remark { get; set; }

    public int AddedBy { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<CallTracker> CallTrackers { get; set; } = new List<CallTracker>();

    public virtual CastCategory Cast { get; set; } = null!;

    public virtual CityMaster City { get; set; } = null!;

    public virtual CollegeStatus CollageStatus { get; set; } = null!;

    public virtual ICollection<FollowUp> FollowUps { get; set; } = new List<FollowUp>();

    public virtual GenderMaster Gender { get; set; } = null!;

    public virtual StateMaster State { get; set; } = null!;
}
