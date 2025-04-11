namespace Eduaction.DataModel.DataModels;

public partial class ThirdPartyMaster
{
    public int Id { get; set; }

    public string PartyName { get; set; } = null!;

    public string? PartyCode { get; set; }

    public string? Remark { get; set; }

    public int AddedBy { get; set; }

    public DateTime AddedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public bool IsActive { get; set; }
}
